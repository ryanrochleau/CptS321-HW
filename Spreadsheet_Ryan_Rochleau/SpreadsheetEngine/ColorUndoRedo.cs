// <copyright file="ColorUndoRedo.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// Class for undo/redo of colors. Uses a list of cells since
    /// we can select multiple and change their colors all at once.
    /// </summary>
    public class ColorUndoRedo : IUndoRedoInterface
    {
        /// <summary>
        /// New color of all the cells.
        /// </summary>
        private uint newColor;

        /// <summary>
        /// Previous colors of the cells.
        /// </summary>
        private List<uint> prevColors;

        /// <summary>
        /// List of all cells that were changed.
        /// </summary>
        private List<Cell> cells;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorUndoRedo"/> class.
        /// </summary>
        /// <param name="cells">List of all cells being changed.</param>
        /// <param name="prevColors">Previous colors of the cells.</param>
        /// <param name="newColor">New color for the cells.</param>
        public ColorUndoRedo(List<Cell> cells, List<uint> prevColors, uint newColor)
        {
            this.cells = cells;
            this.prevColors = prevColors;
            this.newColor = newColor;
        }

        /// <summary>
        /// Implements undo for color.
        /// </summary>
        public void InterfaceUndo()
        {
            // Undoing a change means reverting the color of each cell
            // back to its original color.
            for (int i = 0; i < this.cells.Count; i++)
            {
                this.cells[i].SetColor(this.prevColors[i]);
            }
        }

        /// <summary>
        /// Implements redo for color.
        /// </summary>
        public void InterfaceRedo()
        {
            // Redoing means setting the cells original colors back to
            // the new color.
            foreach (Cell oldCell in this.cells)
            {
                oldCell.SetColor(this.newColor);
            }
        }
    }
}
