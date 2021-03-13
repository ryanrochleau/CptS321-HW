// <copyright file="SpreadsheetCell.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// Class that inheritis from our abstract class Cell.
    /// </summary>
    public class SpreadsheetCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// Constructor for SpreadsheetCell.
        /// </summary>
        /// <param name="row">Row for cell.</param>
        /// <param name="col">Column for cell.</param>
        public SpreadsheetCell(int row, int col)
            : base(row, col)
        {
        }
    }
}
