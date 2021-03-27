﻿// <copyright file="MidTermProgram.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace MidTerm2
{
    /// <summary>
    /// Main program class for the MidTerm.
    /// </summary>
    public class MidTermProgram
    {
        /// <summary>
        /// Shape factory.
        /// </summary>
        private ShapeFactory shapeFactory = new ShapeFactory();

        /// <summary>
        /// Dictionary for the base values of each shape type.
        /// </summary>
        private Dictionary<char, double> baseValuesDictionary = new Dictionary<char, double>();

        /// <summary>
        /// A list of all sequences, each a list of their own, that have been created.
        /// </summary>
        private List<List<Shape>> history = new List<List<Shape>>();

        /// <summary>
        /// The current sequence we are on as an index to the list history.
        /// </summary>
        private int currentIndex = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="MidTermProgram"/> class.
        /// Constructor for the class. Instantiates the base
        /// values dictionary.
        /// </summary>
        public MidTermProgram()
        {
            this.baseValuesDictionary.Add('c', 1);
            this.baseValuesDictionary.Add('s', 1);
            this.baseValuesDictionary.Add('t', 1);
        }

        /// <summary>
        /// Sets the default size for a shape.
        /// </summary>
        /// <param name="shape">The shape whose defauly size we are modifying.</param>
        /// <param name="size">The new default size for the shape.</param>
        public void SetDefaultSize(char shape, double size)
        {
            try
            {
                this.baseValuesDictionary.Add(shape, size);
            }
            catch (ArgumentException)
            {
                this.baseValuesDictionary[shape] = size;
            }
        }

        /// <summary>
        /// Gets the default size of a shape.
        /// </summary>
        /// <param name="shape">The shape whose default size we want.</param>
        /// <returns>The default size of the shape.</returns>
        public double GetDefaultSize(char shape)
        {
            return this.baseValuesDictionary[shape];
        }

        /// <summary>
        /// Creates a sequence of shapes.
        /// </summary>
        /// <param name="sequence">A string representing the sequence of shapes to be made.</param>
        public void CreateSequence(string sequence)
        {
            sequence = sequence.Replace(" ", string.Empty);
            char[] shapes = sequence.ToCharArray();
            List<Shape> shapeList = new List<Shape>();
            int multiplier = 2;

            foreach (char shape in shapes)
            {
                if (shapeList.Count == 0)
                {
                    shapeList.Add(this.shapeFactory.GetShape(shape, this.GetDefaultSize(shape)));
                }
                else
                {
                    shapeList.Add(this.shapeFactory.GetShape(shape, this.GetDefaultSize(shapeList[0].GetCharacter()) * multiplier));
                    multiplier++;
                }
            }

            this.history.Add(shapeList);

            this.currentIndex = this.history.Count - 1;
        }

        /// <summary>
        /// Sets the current sequence we are actively modifying.
        /// </summary>
        /// <param name="index">The index of the list.</param>
        public void SetCurrentSequence(int index)
        {
            if (index >= 0 && index < this.history.Count)
            {
                this.currentIndex = index;
            }
            else
            {
                this.currentIndex = -1;
            }
        }

        /// <summary>
        /// Retrieves a list of shapes.
        /// </summary>
        /// <returns>A list of shapes at the current index.</returns>
        public List<Shape> GetCurrentSequence()
        {
            return this.history[this.currentIndex];
        }

        /// <summary>
        /// Adds a shape to the current sequence.
        /// </summary>
        /// <param name="shape">The character shape that needs to be entered.</param>
        public void AddToSequence(char shape)
        {
            // Adding a shape using shapefactory to the current list of shapes.
            this.history[this.currentIndex].Add(this.shapeFactory.GetShape(shape, (this.history[this.currentIndex].Count + 1) * this.history[this.currentIndex][0].GetSize()));
        }

        /// <summary>
        /// Changes the shape at index to the shape being passed in. Makes sure to update
        /// sizes accordingly.
        /// </summary>
        /// <param name="index">The index of the shape to be replaced.</param>
        /// <param name="shape">The new shape.</param>
        public void ChangeShape(int index, char shape)
        {
            if (index != 0)
            {
                this.history[this.currentIndex][0] = this.shapeFactory.GetShape(shape, this.history[this.currentIndex][0].GetSize());
            }
            else
            {
                this.history[this.currentIndex][0] = this.shapeFactory.GetShape(shape, this.history[this.currentIndex][0].GetSize());
                this.UpdateSizes();
            }
        }

        /// <summary>
        /// Deletes a shape in the current sequence list.
        /// </summary>
        /// <param name="index">The index of the shape to be deleted.</param>
        public void DeleteShape(int index)
        {
            this.history[this.currentIndex].RemoveAt(index);
            this.UpdateSizes();
        }

        /// <summary>
        /// Prints all shapes in the history with extra detail.
        /// This fulfills bullet point 2 on the doc.
        /// </summary>
        public void ListShapes()
        {
            int count = 1;
            foreach (List<Shape> shapes in this.history)
            {
                Console.WriteLine(string.Format("********** Sequence {0} **********", count));
                foreach (Shape shape in shapes)
                {
                    Console.WriteLine(string.Format("[Shape: {0} - Size: {1} - Character: {2}]", shape.GetType(), shape.GetSize(), shape.GetCharacter()));
                }

                Console.WriteLine(string.Empty);
                count++;
            }
        }

        /// <summary>
        /// Prints all shapes in the history but just the types.
        /// This fulfills bullet point 3 on the doc.
        /// </summary>
        public void ListHistory()
        {
            int count = 1;
            foreach (List<Shape> shapes in this.history)
            {
                Console.WriteLine(string.Format("********** Sequence {0} **********", count));
                foreach (Shape shape in shapes)
                {
                    Console.WriteLine(string.Format("{0}",shape.GetType()));
                }

                Console.WriteLine(string.Empty);
                count++;
            }
        }

        /// <summary>
        /// Updates the sizes of all shapes in the current list.
        /// </summary>
        private void UpdateSizes()
        {
            bool first = true;
            int index = 0;
            foreach (Shape shape in this.history[this.currentIndex])
            {
                if (first)
                {
                    // Since it is the first element, set its size to its default size.
                    this.history[this.currentIndex][index].SetSize(this.GetDefaultSize(this.history[this.currentIndex][index].GetCharacter()));
                    first = false;
                }
                else
                {
                    this.history[this.currentIndex][index].SetSize(this.history[this.currentIndex][0].GetSize() * (index + 1));
                }

                index++;
            }
        }
    }
}
