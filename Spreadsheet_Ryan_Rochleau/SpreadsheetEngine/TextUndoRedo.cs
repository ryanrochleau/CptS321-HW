// <copyright file="TextUndoRedo.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// Undo/redo for text.
    /// </summary>
    public class TextUndoRedo : IUndoRedoInterface
    {
        /// <summary>
        /// Old text of the cell before change.
        /// </summary>
        private string oldActualText;

        /// <summary>
        /// New text of the cell.
        /// </summary>
        private string newActualText;

        /// <summary>
        /// The cell being changed.
        /// </summary>
        private Cell mainCell;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextUndoRedo"/> class.
        /// Constructor for the TextUndoRedo which takes a cell,
        /// the cells old text, and the cells new text.
        /// </summary>
        /// <param name="cell">The cell being changed.</param>
        /// <param name="oldActualText">The old text of the cell.</param>
        /// <param name="newActualText">The new text of the cell.</param>
        public TextUndoRedo(Cell cell, string oldActualText, string newActualText)
        {
            this.mainCell = cell;
            this.oldActualText = oldActualText;
            this.newActualText = newActualText;
        }

        /// <summary>
        /// Implements undo for text.
        /// </summary>
        public void InterfaceUndo()
        {
            // Undoing a change means reverting the text back to the old text.
            this.mainCell.SetActualText(this.oldActualText);
        }

        /// <summary>
        /// Implements redo for text.
        /// </summary>
        public void InterfaceRedo()
        {
            // Redoing means setting the cells text to the new text.
            this.mainCell.SetActualText(this.newActualText);
        }
    }
}
