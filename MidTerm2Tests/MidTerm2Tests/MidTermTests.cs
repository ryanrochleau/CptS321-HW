// <copyright file="MidTermTests.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System.Collections.Generic;
using MidTerm2;
using NUnit.Framework;

namespace MidTermTests
{
    /// <summary>
    /// Class for NUnit tests.
    /// </summary>
    public class MidTermTests
    {
        /// <summary>
        /// Setup function for tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Tests the creating of a sequence. Creates a sequence from a string,
        /// gets the sequence, and then checks that each shape is correct.
        /// </summary>
        [Test]
        public void MidTermTestSequence()
        {
            MidTermProgram midTermProgram = new MidTermProgram();

            // Setting default size of circles to 3
            midTermProgram.SetDefaultSize('c', 3);
            midTermProgram.SetDefaultSize('t', 4);

            // Circle Square Triangle Circle
            string input = "c s t c";

            midTermProgram.CreateSequence(input);

            // Returns the current sequence of shapes as a list
            List<Shape> shapes = midTermProgram.GetCurrentSequence();

            // Circle
            Assert.AreEqual(shapes[0].GetType(), "Circle");
            Assert.AreEqual(shapes[0].GetSize(), 3);
            Assert.AreEqual(shapes[0].GetCharacter(), 'c');
            Assert.AreEqual(shapes[0].GetArea(), 28.27);

            // Square
            Assert.AreEqual(shapes[1].GetType(), "Square");
            Assert.AreEqual(shapes[1].GetSize(), 6);
            Assert.AreEqual(shapes[1].GetCharacter(), 's');
            Assert.AreEqual(shapes[1].GetArea(), 36);

            // Triangle
            Assert.AreEqual(shapes[2].GetType(), "Triangle");
            Assert.AreEqual(shapes[2].GetSize(), 9);
            Assert.AreEqual(shapes[2].GetCharacter(), 't');
            Assert.AreEqual(shapes[2].GetArea(), 35.07);

            // Circle
            Assert.AreEqual(shapes[3].GetType(), "Circle");
            Assert.AreEqual(shapes[3].GetSize(), 12);
            Assert.AreEqual(shapes[3].GetCharacter(), 'c');
            Assert.AreEqual(shapes[3].GetArea(), 452.39);
        }

        /// <summary>
        /// Tests that the default sizes of shapes is updated properly.
        /// </summary>
        [Test]
        public void MidTermTestDefaultSize()
        {
            MidTermProgram midTermProgram = new MidTermProgram();

            // Setting default size of circles to 3
            midTermProgram.SetDefaultSize('c', 3);
            midTermProgram.SetDefaultSize('t', 4);

            // Checking default sizes of shapes.
            Assert.AreEqual(midTermProgram.GetDefaultSize('c'), 3);
            Assert.AreEqual(midTermProgram.GetDefaultSize('s'), 1);
            Assert.AreEqual(midTermProgram.GetDefaultSize('t'), 4);
        }

        /// <summary>
        /// Tests adding a shape to a sequence in the history.
        /// This is for modifying the history.
        /// </summary>
        [Test]
        public void MidTermTestAddToSequence()
        {
            MidTermProgram midTermProgram = new MidTermProgram();

            midTermProgram.SetDefaultSize('c', 3);

            // Circle Square Triangle Circle
            string input = "c s t c";

            midTermProgram.CreateSequence(input);

            midTermProgram.SetCurrentSequence(0);

            midTermProgram.AddToSequence('t');

            List<Shape> shapes = midTermProgram.GetCurrentSequence();

            Assert.AreEqual(shapes[4].GetType(), "Triangle");
            Assert.AreEqual(shapes[4].GetSize(), 15);
            Assert.AreEqual(shapes[4].GetCharacter(), 't');
            Assert.AreEqual(shapes[4].GetArea(), 97.43);
        }

        /// <summary>
        /// Tests changing a shape to another shape in a sequence.
        /// This is for modifying the history.
        /// </summary>
        [Test]
        public void MidTermTestChangeShape()
        {
            MidTermProgram midTermProgram = new MidTermProgram();

            midTermProgram.SetDefaultSize('c', 3);

            // Circle Square Triangle Circle
            string input = "c s t c";

            midTermProgram.CreateSequence(input);

            midTermProgram.SetCurrentSequence(0);

            List<Shape> shapes = midTermProgram.GetCurrentSequence();

            Assert.AreEqual(shapes[0].GetType(), "Circle");
            Assert.AreEqual(shapes[0].GetSize(), 3);
            Assert.AreEqual(shapes[0].GetCharacter(), 'c');
            Assert.AreEqual(shapes[0].GetArea(), 28.27);

            // Change first shape to triangle
            midTermProgram.ChangeShape(0, 't');

            shapes = midTermProgram.GetCurrentSequence();

            Assert.AreEqual(shapes[0].GetType(), "Triangle");
            Assert.AreEqual(shapes[0].GetSize(), 3);
            Assert.AreEqual(shapes[0].GetCharacter(), 't');
            Assert.AreEqual(shapes[0].GetArea(), 3.90);
        }

        /// <summary>
        /// Tests deleting a shape from a sequence and ensuring the
        /// sizes are updated properly. This is for modifying the history.
        /// </summary>
        [Test]
        public void MidTermTestRemoveShape()
        {
            MidTermProgram midTermProgram = new MidTermProgram();

            midTermProgram.SetDefaultSize('c', 3);

            // Circle Square Triangle Circle
            string input = "c s t c";

            midTermProgram.CreateSequence(input);

            midTermProgram.SetCurrentSequence(0);

            List<Shape> shapes = midTermProgram.GetCurrentSequence();

            Assert.AreEqual(shapes[0].GetType(), "Circle");
            Assert.AreEqual(shapes[0].GetSize(), 3);
            Assert.AreEqual(shapes[0].GetCharacter(), 'c');
            Assert.AreEqual(shapes[0].GetArea(), 28.27);

            // Deleting the first circle so square should be first
            midTermProgram.DeleteShape(0);

            shapes = midTermProgram.GetCurrentSequence();

            // Square is now first and has base size 1. So sequence should be
            // updated accordingly.
            Assert.AreEqual(shapes[0].GetType(), "Square");
            Assert.AreEqual(shapes[0].GetSize(), 1);
            Assert.AreEqual(shapes[0].GetCharacter(), 's');
            Assert.AreEqual(shapes[0].GetArea(), 1);

            Assert.AreEqual(shapes[1].GetType(), "Triangle");
            Assert.AreEqual(shapes[1].GetSize(), 2);
            Assert.AreEqual(shapes[1].GetCharacter(), 't');
            Assert.AreEqual(shapes[1].GetArea(), 1.73);
        }
    }
}