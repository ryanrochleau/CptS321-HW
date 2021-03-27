// <copyright file="Program.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections;

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
            int option = 1;
            int editOption = -1;
            char shapeCharacter;
            string userInput = string.Empty;

            while (option != 8 && option > 0 && option < 9)
            {
                Console.Clear();
                Console.WriteLine("Enter an option listed below:");
                Console.WriteLine("1) Enter a new sequence");
                Console.WriteLine("2) Change the default size of a shape");
                Console.WriteLine("3) List all shapes with added detail");
                Console.WriteLine("4) List all shapes with less detail");
                Console.WriteLine("5) Modify the history");
                Console.WriteLine("6) Get the total area of a sequence");
                Console.WriteLine("7) Filter shape area");
                Console.WriteLine("8) Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1: Console.Clear();
                        Console.WriteLine("Enter a new sequence (i.e. \"c s c t s s\"): ");
                        midTermProgram.CreateSequence(Console.ReadLine());
                        break;
                    case 2: Console.Clear();
                        Console.WriteLine("Enter a shape character: ");
                        shapeCharacter = Convert.ToChar(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Enter the default size: ");
                        midTermProgram.SetDefaultSize(shapeCharacter, Convert.ToDouble(Console.ReadLine()));
                        break;
                    case 3: Console.Clear();
                        midTermProgram.ListShapes();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 4: Console.Clear();
                        midTermProgram.ListHistory();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 5: Console.Clear();
                        Console.WriteLine("Enter an option listed below:");
                        Console.WriteLine("1) Add a shape to a sequence");
                        Console.WriteLine("2) Remove a shape from a sequence");
                        Console.WriteLine("3) Replace a shape from a sequence");
                        editOption = Convert.ToInt32(Console.ReadLine());
                        switch (editOption)
                        {
                            case 1: Console.Clear();
                                midTermProgram.ListShapes();
                                Console.WriteLine("Enter which sequence you want to edit:");
                                midTermProgram.SetCurrentSequence(Convert.ToInt32(Console.ReadLine()) - 1);
                                Console.Clear();
                                midTermProgram.ListShapesIndivList(midTermProgram.GetCurrentSequence());
                                Console.WriteLine("What shape would you like to add (s,c,t)?");
                                midTermProgram.AddToSequence(Convert.ToChar(Console.ReadLine()));
                                Console.Clear();
                                midTermProgram.ListShapesIndivList(midTermProgram.GetCurrentSequence());
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            case 2: Console.Clear();
                                midTermProgram.ListShapes();
                                Console.WriteLine("Enter which sequence you want to edit:");
                                midTermProgram.SetCurrentSequence(Convert.ToInt32(Console.ReadLine()) - 1);
                                Console.Clear();
                                midTermProgram.ListShapesIndivList(midTermProgram.GetCurrentSequence());
                                Console.WriteLine("What shape would you like to delete?");
                                editOption = Convert.ToInt32(Console.ReadLine());
                                midTermProgram.DeleteShape(editOption - 1);
                                Console.Clear();
                                midTermProgram.ListShapesIndivList(midTermProgram.GetCurrentSequence());
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            case 3: Console.Clear();
                                midTermProgram.ListShapes();
                                Console.WriteLine("Enter which sequence you want to edit:");
                                midTermProgram.SetCurrentSequence(Convert.ToInt32(Console.ReadLine()) - 1);
                                Console.Clear();
                                midTermProgram.ListShapesIndivList(midTermProgram.GetCurrentSequence());
                                Console.WriteLine("What shape would you like to replace?");
                                editOption = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                midTermProgram.ListShapesIndivList(midTermProgram.GetCurrentSequence());
                                Console.WriteLine("What shape would you like to insert (s,c,t)?");
                                midTermProgram.ChangeShape(editOption - 1, Convert.ToChar(Console.ReadLine()));
                                Console.Clear();
                                midTermProgram.ListShapesIndivList(midTermProgram.GetCurrentSequence());
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case 6: Console.Clear();
                        midTermProgram.ListShapes();
                        Console.WriteLine("Enter which sequence you want the total area of:");
                        editOption = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.Clear();
                        midTermProgram.GetTotalArea(editOption);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 7: Console.Clear();
                        Console.WriteLine("Enter a comparison method (<,>,or =): ");
                        shapeCharacter = Convert.ToChar(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Enter a value to compare by: ");
                        editOption = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        midTermProgram.FilterShapes(shapeCharacter, editOption);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 8: return;
                }
            }
        }
    }
}
