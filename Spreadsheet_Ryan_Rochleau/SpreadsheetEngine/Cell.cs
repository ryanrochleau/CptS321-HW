// <copyright file="Cell.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.ComponentModel;

namespace SpreadsheetEngine
{
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
        /// PropertyChangedEventHandler for notifying when a cell changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}
