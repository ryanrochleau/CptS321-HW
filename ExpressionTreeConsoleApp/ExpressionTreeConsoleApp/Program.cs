// <copyright file="Program.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Text.RegularExpressions;
using CptS321;

namespace ExpressionTreeConsoleApp
{
    /// <summary>
    /// Main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args">Arguments provided to main at runtime.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression: ");
            string userInput = Console.ReadLine();

            string variableName;
            double variableValue;

            int option;

            ExpressionTree expressionTree = new ExpressionTree(userInput);

            while (true)
            {
                Console.WriteLine(string.Format("Menu (current expression is {0})", userInput));
                Console.WriteLine(" 1. Enter a new expression");
                Console.WriteLine(" 2. Set a variable value");
                Console.WriteLine(" 3. Evaluate tree");
                Console.WriteLine(" 4. Quit");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter an expression: ");
                        userInput = Console.ReadLine();
                        expressionTree = new ExpressionTree(userInput);
                        break;

                    case 2:
                        Console.WriteLine("Enter a variable name");
                        variableName = Console.ReadLine();
                        Console.WriteLine("Enter a double value");
                        variableValue = Convert.ToInt32(Console.ReadLine());
                        expressionTree.SetVariable(variableName, variableValue);
                        break;

                    case 3: Console.WriteLine(string.Format("{0}", expressionTree.Evaluate())); Console.ReadKey();  break;

                    case 4: return;
                }

                Console.Clear();
            }
        }
    }
}
