// <copyright file="Spreadsheet.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Xml;

namespace CptS321
{
    /// <summary>
    /// Class for the spreadsheet.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// 2D array of cells.
        /// </summary>
        private Cell[,] cellArray;

        /// <summary>
        /// Number of columns in the spreadsheet.
        /// </summary>
        private int columnCount;

        /// <summary>
        /// Number of rows in the spreadsheet.
        /// </summary>
        private int rowCount;

        /// <summary>
        /// Stack for all undo operations.
        /// </summary>
        private Stack<IUndoRedoInterface> undoStack = new Stack<IUndoRedoInterface>();

        /// <summary>
        /// Stack for all redo operations.
        /// </summary>
        private Stack<IUndoRedoInterface> redoStack = new Stack<IUndoRedoInterface>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// Constructor for spreadsheet.
        /// </summary>
        /// <param name="rows">Number of rows in the spreadsheet.</param>
        /// <param name="cols">Number of columns in the spreadsheet.</param>
        public Spreadsheet(int rows, int cols)
        {
            this.cellArray = new SpreadsheetCell[rows, cols];
            this.rowCount = rows;
            this.columnCount = cols;

            // Allocating space for a new SpreadsheetCell at each location in the 2D array.
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.cellArray[i, j] = new SpreadsheetCell(i, j);
                    this.cellArray[i, j].PropertyChanged += this.CellPropertyChanged;
                }
            }
        }

        /// <summary>
        /// PropertyChangedEventHandler for notifying when a cell changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Getter for column count.
        /// </summary>
        /// <returns>Returns number of columns in spreadsheet.</returns>
        public int GetColumnCount()
        {
            return this.columnCount;
        }

        /// <summary>
        /// Getter for row count.
        /// </summary>
        /// <returns>Returns the number of rows in spreadsheet.</returns>
        public int GetRowCount()
        {
            return this.rowCount;
        }

        /// <summary>
        /// Sets the column count of the spreadsheet.
        /// </summary>
        /// <param name="newColCount">New column count int.</param>
        public void SetColumnCount(int newColCount)
        {
            this.columnCount = newColCount;
        }

        /// <summary>
        /// Sets the row count of the spreadsheet.
        /// </summary>
        /// <param name="newRowCount">New row count int.</param>
        public void SetRowCount(int newRowCount)
        {
            this.rowCount = newRowCount;
        }

        /// <summary>
        /// Gets a cell at the location passed in.
        /// </summary>
        /// <param name="row">Row where the cell is located.</param>
        /// <param name="col">Column where the cell is located.</param>
        /// <returns>A Cell at the location given.</returns>
        public Cell GetCell(int row, int col)
        {
            return this.cellArray[row, col];
        }

        /// <summary>
        /// Gets the text value in the cell pointed to by the input string.
        /// </summary>
        /// <param name="inputText">String which points to cell.</param>
        /// <returns>String of text value that was in the cell pointed to by inputText.</returns>
        public string FindCellText(string inputText)
        {
            // Format of the inputText would be something like =A6
            return this.GetCell(Convert.ToInt32(inputText.Substring(2)) - 1, Convert.ToInt32(inputText[1]) - 65).GetTextValue();
        }

        /// <summary>
        /// Event to be fired when cell properties change.
        /// </summary>
        /// <param name="sender">The cell that is invoking the event.</param>
        /// <param name="e">Event argument given when cell invokes event.</param>
        public void CellPropertyChanged(object sender, EventArgs e)
        {
            SpreadsheetCell cell = sender as SpreadsheetCell;
            PropertyChangedEventArgs args = e as PropertyChangedEventArgs;

            // Set actual text is what fired the event.
            // Need to check if the text has '=' as first char.
            if (args.PropertyName == "Color")
            {
                PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(cell.GetColumnIndex().ToString() + ',' + cell.GetRowIndex().ToString() + ',' + "COLOR:" + cell.GetColor());

                this.PropertyChanged(this, eventArgs);
            }

            if (cell.GetActualText() == string.Empty)
            {
                cell.SetTextValue(string.Empty);

                PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(cell.GetColumnIndex().ToString() + ',' + cell.GetRowIndex().ToString() + ',' + cell.GetTextValue().ToString());

                this.PropertyChanged(this, eventArgs);
            }
            else
            {
                if (cell.GetActualText()[0] != '=')
                {
                    cell.SetTextValue(cell.GetActualText());

                    PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(cell.GetColumnIndex().ToString() + ',' + cell.GetRowIndex().ToString() + ',' + cell.GetTextValue().ToString());

                    this.PropertyChanged(this, eventArgs);
                }
                else
                {
                    // Create tree with expression.
                    cell.CreateCellTree(cell.GetActualText().Substring(1));
                    Dictionary<string, double> variableDictionary = cell.GetVariableDictionary();

                    foreach (KeyValuePair<string, double> pair in variableDictionary.ToList())
                    {
                        cell.AddCellToTree(this.GetCell(Convert.ToInt32(pair.Key.Substring(1)) - 1, (int)pair.Key[0] - 65));
                    }

                    cell.SetTextValue(cell.EvaluateCell());

                    PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(cell.GetColumnIndex().ToString() + ',' + cell.GetRowIndex().ToString() + ',' + cell.GetTextValue().ToString());

                    this.PropertyChanged(this, eventArgs);
                }
            }
        }

        /// <summary>
        /// Adds an undo onto the undo stack.
        /// </summary>
        /// <param name="undo">New undo to add to the stack.</param>
        public void AddUndo(IUndoRedoInterface undo)
        {
            this.undoStack.Push(undo);

            if (this.undoStack.Count == 1)
            {
                // Unlock the undo button.
                PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs("BeginUndo");
                this.PropertyChanged(undo, eventArgs);
            }
        }

        /// <summary>
        /// Undo function. Invoked propertychanged when the buttons should
        /// be locked/unlocked.
        /// </summary>
        public void Undo()
        {
            this.undoStack.Peek().InterfaceUndo();
            this.redoStack.Push(this.undoStack.Pop());

            // Stack was empty.
            if (this.redoStack.Count == 1)
            {
                // Unlock the redo button.
                PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs("BeginRedo");
                this.PropertyChanged(this.redoStack.Peek(), eventArgs);
            }

            if (this.undoStack.Count == 0)
            {
                // Lock the undo.
                PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs("StopUndo");
                this.PropertyChanged(this.redoStack.Peek(), eventArgs);
            }
        }

        /// <summary>
        /// Redo function. Invoked propertychanged when the buttons should
        /// be locked/unlocked.
        /// </summary>
        public void Redo()
        {
            this.redoStack.Peek().InterfaceRedo();
            this.undoStack.Push(this.redoStack.Pop());

            if (this.undoStack.Count == 1)
            {
                // Unlock the undo button.
                PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs("BeginUndo");
                this.PropertyChanged(this.undoStack.Peek(), eventArgs);
            }

            if (this.redoStack.Count == 0)
            {
                // Lock the redo button.
                PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs("StopRedo");
                this.PropertyChanged(this.undoStack.Peek(), eventArgs);
            }
        }

        /// <summary>
        /// Saves the current state of the spreadsheet.
        /// </summary>
        /// <param name="fs">The file stream to save the file to.</param>
        public void Save(Stream fs)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create(fs, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("spreadsheet");

            foreach (var i in Enumerable.Range(0, this.rowCount))
            {
                foreach (var j in Enumerable.Range(0, this.columnCount))
                {
                    Cell cell = this.GetCell(i, j);

                    // Cell is not a base cell
                    if (cell.GetColor() != 0xFFFFFFFF || cell.GetActualText() != string.Empty)
                    {
                        writer.WriteStartElement("cell");

                        writer.WriteStartElement("row");
                        writer.WriteString(cell.GetRowIndex().ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("col");
                        writer.WriteString(cell.GetColumnIndex().ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("text");
                        writer.WriteString(cell.GetActualText());
                        writer.WriteEndElement();

                        writer.WriteStartElement("color");
                        writer.WriteString(cell.GetColor().ToString());
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                    }
                }
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        /// <summary>
        /// Loads the xml file from the given file stream.
        /// </summary>
        /// <param name="fs">The xml filestream.</param>
        public void Load(Stream fs)
        {
            Cell cell;
            int row = 0, col = 0, count = 0;
            string text = string.Empty;
            uint color = 0xFFFFFFFF;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.IgnoreWhitespace = true;

            XmlReader reader = XmlReader.Create(fs, settings);

            reader.ReadStartElement("spreadsheet");
            reader.ReadStartElement("cell");

            do
            {
                while (count != 4)
                {
                    switch (reader.Name)
                    {
                        case "row": row = Convert.ToInt32(reader.ReadElementContentAsString()); count++; break;
                        case "col": col = Convert.ToInt32(reader.ReadElementContentAsString()); count++; break;
                        case "text": text = reader.ReadElementContentAsString(); count++; break;
                        case "color": color = Convert.ToUInt32(reader.ReadElementContentAsString()); count++; break;
                        case "cell": reader.Read(); break;
                        default: reader.ReadElementContentAsString(); break;
                    }
                }

                if (count == 4)
                {
                    cell = this.GetCell(row, col);

                    cell.SetActualText(text);

                    cell.SetColor(Convert.ToUInt32(color));

                    count = 0;
                }
            }
            while (reader.ReadToFollowing("cell"));

            reader.Close();
        }

        /// <summary>
        /// Resets the stacks of the spreadsheet.
        /// </summary>
        public void ClearStacks()
        {
            this.redoStack = new Stack<IUndoRedoInterface>();
            this.undoStack = new Stack<IUndoRedoInterface>();
        }

        /// <summary>
        /// Checks whether or not he cell violates the CheckOnSheet or CheckSelfReference
        /// checks.
        /// </summary>
        /// <param name="cell">The cell to check.</param>
        /// <returns>True if the cell is fine. False if the cell violates any check.</returns>
        private bool CheckValidCell(Cell cell)
        {
            Dictionary<string, double> variablesDictionary = cell.GetVariableDictionary();

            string cellName = string.Empty;
            cellName += Convert.ToChar(cell.GetColumnIndex());
            cellName += Convert.ToString(cell.GetRowIndex());

            foreach (KeyValuePair<string, double> entry in variablesDictionary)
            {
                if (!this.CheckOnSheet(entry.Key))
                {
                    cell.SetTextValue("!(bad reference)");
                    return false;
                }
                else if (entry.Key == cellName)
                {
                    // This handles the case that the cell has direct references to itself and not through other cells.
                    cell.SetTextValue("!(self reference)");
                    return false;
                }
                else if (!this.CheckSelfReference(entry.Key, cellName))
                {
                    // This handles the case that the cell has a reference to itself but through other cells.
                    cell.SetTextValue("!(self reference)");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the cell contains valid cells as the input.
        /// </summary>
        /// <param name="cell">The string name of the cell.</param>
        /// <returns>True if the cell passes and false if it doesn't.</returns>
        private bool CheckOnSheet(string cell)
        {
            int row = Convert.ToInt32(cell.Substring(1)) - 1;
            int col = Convert.ToInt32(cell[0]) - 65;

            if (row < 50 && col < 26)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the checkCell is referenced at all in any of the currentCells
        /// variables.
        /// </summary>
        /// <param name="currentCell">String name of the current cell.</param>
        /// <param name="checkCell">String name of the cell we are checking for.</param>
        /// <returns>True if no self references and false otherwise.</returns>
        private bool CheckSelfReference(string currentCell, string checkCell)
        {
            Cell curCell = this.GetCell(Convert.ToInt32(currentCell.Substring(1)) - 1, Convert.ToInt32(currentCell[0]) - 65);
            Dictionary<string, double> variablesDictionary = curCell.GetVariableDictionary();

            // Checking all variables in the currentCell variable dictionary for checkCell.
            foreach (KeyValuePair<string, double> entry in variablesDictionary)
            {
                // checkCell is present in the dictionary so there is a self reference.
                if (entry.Key == checkCell)
                {
                    return false;
                }

                // Check the trees of all cells in the currentCells tree.
                return this.CheckSelfReference(entry.Key,checkCell);
            }

            return true;
        }
    }
}
