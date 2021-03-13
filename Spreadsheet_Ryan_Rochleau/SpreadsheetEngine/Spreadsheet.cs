// <copyright file="Spreadsheet.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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

            // Set actual text is what fired the event.
            // Need to check if the text has '=' as first char.
            if (cell.GetActualText()[0] != '=')
            {
                cell.SetTextValue(cell.GetActualText());
            }
            else
            {
                cell.SetTextValue(this.FindCellText(cell.GetActualText()));

                PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(cell.GetColumnIndex().ToString() + ',' + cell.GetRowIndex().ToString() + ',' + cell.GetTextValue().ToString());

                this.PropertyChanged(this, eventArgs);
            }
        }
    }
}
