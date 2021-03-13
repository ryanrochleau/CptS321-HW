// <copyright file="Cell.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.ComponentModel;

namespace CptS321
{
    /// <summary>
    /// Abstract class representing a cell.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Literal string of what is in the cell.
        /// </summary>
        private protected string actualText;

        /// <summary>
        /// Evaluated value of the text.
        /// </summary>
        private protected string textValue;

        /// <summary>
        /// Row of the cell.
        /// </summary>
        private int rowIndex;

        /// <summary>
        /// Column of the cell.
        /// </summary>
        private int columnIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// Constructor cell.
        /// </summary>
        /// <param name="row">Row of the cell.</param>
        /// <param name="column">Column of the cell.</param>
        public Cell(int row, int column)
        {
            this.rowIndex = row;
            this.columnIndex = column;
            this.actualText = string.Empty;
            this.textValue = string.Empty;
        }

        /// <summary>
        /// PropertyChangedEventHandler for notifying when a cell changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Getter for RowIndex.
        /// </summary>
        /// <returns>Returns RowIndex integer.</returns>
        public int GetRowIndex()
        {
            return this.rowIndex;
        }

        /// <summary>
        /// Getter for ColumnIndex.
        /// </summary>
        /// <returns>Returns ColumnIndex integer.</returns>
        public int GetColumnIndex()
        {
            return this.columnIndex;
        }

        /// <summary>
        /// Getter for the actual text string.
        /// </summary>
        /// <returns>Returns the actualText string.</returns>
        public string GetActualText()
        {
            return this.actualText;
        }

        /// <summary>
        /// Sets the actualText and notifies that a property has changed if it's a new value.
        /// </summary>
        /// <param name="newText">New string input value.</param>
        public void SetActualText(string newText)
        {
            Console.WriteLine("Inside SetActualText Function");
            if (this.actualText == newText)
            {
                return;
            }
            else
            {
                this.actualText = newText;

                PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs("ActualText");

                this.PropertyChanged(this, eventArgs);
            }
        }

        /// <summary>
        /// Setter for textValue string.
        /// </summary>
        /// <param name="newTextValue">newTextValue string.</param>
        public void SetTextValue(string newTextValue)
        {
            this.textValue = newTextValue;
        }

        /// <summary>
        /// Getter for textValue string.
        /// </summary>
        /// <returns>textValue string.</returns>
        public string GetTextValue()
        {
            return this.textValue;
        }
    }
}
