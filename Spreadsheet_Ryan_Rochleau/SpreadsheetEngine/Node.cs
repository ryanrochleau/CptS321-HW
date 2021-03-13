// <copyright file="Node.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// Base class for a node in the expression tree.
    /// </summary>
    internal abstract class Node
    {
        /// <summary>
        /// Evaluates the value of the node depending on what type of node it is.
        /// All except variable should evaluate to a double.
        /// </summary>
        /// <returns>The value of the expressiontree that
        /// this node is the root of as a double.</returns>
        public abstract double Evaluate();
    }
}
