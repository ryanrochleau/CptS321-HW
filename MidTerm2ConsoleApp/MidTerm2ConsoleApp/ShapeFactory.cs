// <copyright file="ShapeFactory.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace MidTerm2
{
    /// <summary>
    /// Factory class for producing Shape objects.
    /// </summary>
    internal class ShapeFactory
    {
        /// <summary>
        /// Returns a shape given a character and a size.
        /// </summary>
        /// <param name="character">The character representing the shape.</param>
        /// <param name="size">The size of the shape.</param>
        /// <returns>The shape that is requested.</returns>
        public Shape GetShape(char character, double size)
        {
            switch (character)
            {
                case 'c': return new Circle("Circle", size, character);
                case 's': return new Square("Square", size, character);
                case 't': return new Triangle("Triangle", size, character);
                default: throw new ArgumentException(string.Format("{0} Is an invalid shape.", character));
            }
        }
    }
}
