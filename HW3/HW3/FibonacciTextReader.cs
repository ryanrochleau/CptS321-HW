// <copyright file="FibonacciTextReader.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HW3
{
    /// <summary>
    /// Custom TextReader which overrides Readline and ReadToEnd
    /// to deliver fibonacci numbers.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        /// <summary>
        /// The number of fibonacci lines.
        /// </summary>
        private int maxLines = -1;

        /// <summary>
        /// Numbers of calls made by ReadLine. Used for special
        /// case of first and second numbers.
        /// </summary>
        private int callsMade = 0;

        /// <summary>
        /// The first of the last two values for calculating a
        /// fibonacci number.
        /// </summary>
        private System.Numerics.BigInteger firstLastValue = 0;

        /// <summary>
        /// The second of the last two values for calculating a
        /// fibonacci number.
        /// </summary>
        private System.Numerics.BigInteger secondLastValue = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// Constructor which takes in an integer indicating how many
        /// fibonacci numbers are to be calculated.
        /// </summary>
        /// <param name="newMax">Number of fibonacci numbers to calculate.</param>
        public FibonacciTextReader(int newMax)
        {
            this.maxLines = newMax;
        }

        /// <summary>
        /// Calculates and returns the next fibonacci number as a string.
        /// </summary>
        /// <returns>A string which is the next fibonacci number in the sequence.</returns>
        public override string ReadLine()
        {
            if (this.callsMade == 0)
            {
                this.callsMade++;
                return 0.ToString();
            }
            else if (this.callsMade == 1)
            {
                this.callsMade++;
                return 1.ToString();
            }
            else
            {
                System.Numerics.BigInteger returnValue = this.firstLastValue + this.secondLastValue;
                this.firstLastValue = this.secondLastValue;
                this.secondLastValue = returnValue;

                this.callsMade++;
                return returnValue.ToString();
            }
        }

        /// <summary>
        /// Appends n fibonacci numbers to a StringBuilder and then returns that stringbuilder
        /// as a string.
        /// </summary>
        /// <returns>A string of all fibonacci numbers.</returns>
        public override string ReadToEnd()
        {
            StringBuilder stringBuilder = new StringBuilder(string.Empty);
            for (int i = 0; i < this.maxLines; i++)
            {
                stringBuilder.Append((i + 1).ToString() + ": " + this.ReadLine() + "\r\n");
            }

            return stringBuilder.ToString();
        }
    }
}
