// <copyright file="Square.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace MidTerm2
{
    /// <summary>
    /// Class representing a Square shape.
    /// </summary>
    internal class Square : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// Constructor the shape Square.
        /// </summary>
        /// <param name="type">New type for the shape.</param>
        /// <param name="size">New size for the shape.</param>
        /// <param name="character">New character for the shape.</param>
        public Square(string type, double size, char character)
            : base(type, size, character)
        {
        }

        /// <summary>
        /// Calculates the area of a square which is size^2.
        /// </summary>
        /// <returns>The area of the square.</returns>
        public override double GetArea()
        {
            return Math.Round(Math.Pow(this.GetSize(), 2), 2, MidpointRounding.AwayFromZero);
        }
    }
}
