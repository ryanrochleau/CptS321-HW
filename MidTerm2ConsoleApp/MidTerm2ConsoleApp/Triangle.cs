// <copyright file="Triangle.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace MidTerm2
{
    /// <summary>
    /// Class representing the Triangle shape.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// Constructor for the Triangle shape.
        /// </summary>
        /// <param name="type">New type for the shape.</param>
        /// <param name="size">New size for the shape.</param>
        /// <param name="character">New character for the shape.</param>
        public Triangle(string type, double size, char character)
            : base(type, size, character)
        {
        }

        /// <summary>
        /// Calculates the area of a equilateral triangle which is
        /// sqrt(3)/4 * size^2.
        /// </summary>
        /// <returns>The area of the triangle as a double to 2 decimal places.</returns>
        public override double GetArea()
        {
            return Math.Round(Math.Sqrt(3) / 4 * Math.Pow(this.GetSize(), 2), 2, MidpointRounding.AwayFromZero);
        }
    }
}
