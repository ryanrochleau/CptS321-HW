// <copyright file="Circle.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace MidTerm2
{
    /// <summary>
    /// Class representing a circle shape.
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// Constructor for the Circle shape.
        /// </summary>
        /// <param name="type">New type for the shape.</param>
        /// <param name="size">New size for the shape.</param>
        /// <param name="character">New character for the shape.</param>
        public Circle(string type, double size, char character)
            : base(type, size, character)
        {
        }

        /// <summary>
        /// Calculates the area of a circle which is pi * r^2.
        /// </summary>
        /// <returns>The area of a circle as a double.</returns>
        public override double GetArea()
        {
            return Math.Round(Math.Pow(this.GetSize(), 2) * Math.PI, 2, MidpointRounding.AwayFromZero);
        }
    }
}
