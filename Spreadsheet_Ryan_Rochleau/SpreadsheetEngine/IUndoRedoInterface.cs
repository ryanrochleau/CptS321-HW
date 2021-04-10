// <copyright file="UndoRedoInterface.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// Interface for undo/redo.
    /// </summary>
    public interface IUndoRedoInterface
    {
        /// <summary>
        /// Undo function for the interface which
        /// the other undo/redo commands will
        /// implement.
        /// </summary>
        void InterfaceUndo();

        /// <summary>
        /// Redo function for the interface which
        /// the other undo/redo commands will
        /// implement.
        /// </summary>
        void InterfaceRedo();
    }
}
