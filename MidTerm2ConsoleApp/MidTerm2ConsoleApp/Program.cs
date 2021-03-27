// <copyright file="Program.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;

namespace MidTerm2
{
    /// <summary>
    /// Main program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function of the program.
        /// </summary>
        /// <param name="args">Inputs to the program.</param>
        public static void Main(string[] args)
        {
            MidTermProgram midTermProgram = new MidTermProgram();
            midTermProgram.SetDefaultSize('c', 5);

            midTermProgram.CreateSequence("c t c s s c t");

            //midTermProgram.ListShapes();

            midTermProgram.FilterShapes('>', 400);
        }
    }
}
