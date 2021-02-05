// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW1
{
    using System;

    /// <summary>
    /// The main program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function of the program.
        /// </summary>
        /// <param name="args">A string array.</param>
        private static void Main(string[] args)
        {
            string inputString;

            inputString = Console.ReadLine();

            string[] subs = inputString.Split(' ');
            int[] inputIntegers = Array.ConvertAll(subs, int.Parse);

            BST newBST = new BST();

            foreach (var num in inputIntegers)
            {
                newBST.InsertNode(num);
            }

            newBST.PrintInSortedOrder();
            Console.WriteLine(newBST.GetNodeCount());
            Console.WriteLine(newBST.GetTreeLevelCount());
        }
    }
}
