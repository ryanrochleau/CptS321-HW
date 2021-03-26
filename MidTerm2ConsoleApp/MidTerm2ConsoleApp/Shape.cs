using System;
using System.Collections.Generic;
using System.Text;

namespace MidTerm2
{
    /// <summary>
    /// Abstract class representing a shape.
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Type of the shape which is the name of the shape
        /// as a string. i.e. "Circle".
        /// </summary>
        private string type;

        /// <summary>
        /// Size of the shape as a double.
        /// </summary>
        private double size;

        /// <summary>
        /// Character representing the shape. i.e.
        /// Circle is 'c'.
        /// </summary>
        private char character;

        /// <summary>
        /// Computes the area of the shape.
        /// </summary>
        /// <returns>Area of the shape as a double.</returns>
        public abstract double GetArea();

        /// <summary>
        /// Gets the type of the shape.
        /// </summary>
        /// <returns>The type of the shape as a string.</returns>
        public new abstract string GetType();

        /// <summary>
        /// Sets the type of the shape.
        /// </summary>
        /// <param name="type">The new type of the shape.</param>
        public abstract void SetType(string type);

        /// <summary>
        /// Gets the size of the shape.
        /// </summary>
        /// <returns>Size of the shape as a double.</returns>
        public abstract double GetSize();

        /// <summary>
        /// Sets the size of the shape.
        /// </summary>
        /// <param name="size">New size for the shape.</param>
        public abstract void SetSize(double size);

        /// <summary>
        /// Gets the character representing the shape.
        /// </summary>
        /// <returns>A character representing the shape.</returns>
        public abstract string GetCharacter();

        /// <summary>
        /// Sets the character for the shape.
        /// </summary>
        /// <param name="character">A new character for the shape.</param>
        public abstract void SetCharacter(char character);
    }
}
