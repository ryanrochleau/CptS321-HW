// <copyright file="UnitTest1.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using NUnit.Framework;
using MidTerm2;

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
            midTermProgram.setDefaultSize('c', 3);
            midTermProgram.setDefaultSize('t', 4);

            // Circle Square Triangle Circle
            string input = "c s t c";

            midTermProgram.createSequence(input);

            // Returns the current sequence of shapes as a list
            Shape[] shapes = midTermProgram.getCurrentSequence();

            // Circle
            Assert.AreEqual(shapes[0].getType(), "Circle");
            Assert.AreEqual(shapes[0].getSize(), 3);
            Assert.AreEqual(shapes[0].getCharacter(), 'c');
            Assert.AreEqual(shapes[0].getArea(), 28.27);

            // Square
            Assert.AreEqual(shapes[1].getType(), "Square");
            Assert.AreEqual(shapes[1].getSize(), 6);
            Assert.AreEqual(shapes[1].getCharacter(), 's');
            Assert.AreEqual(shapes[1].getArea(), 36);

            // Triangle
            Assert.AreEqual(shapes[2].getType(), "Triangle");
            Assert.AreEqual(shapes[2].getSize(), 9);
            Assert.AreEqual(shapes[2].getCharacter(), 't');
            Assert.AreEqual(shapes[2].getArea(), 35.07);

            // Circle
            Assert.AreEqual(shapes[3].getType(), "Circle");
            Assert.AreEqual(shapes[3].getSize(), 12);
            Assert.AreEqual(shapes[3].getCharacter(), 'c');
            Assert.AreEqual(shapes[3].getArea(), 452.39);
        }

        /// <summary>
        /// Tests that the default sizes of shapes is updated properly.
        /// </summary>
        [Test]
        public void MidTermTestDefaultSize()
        {
            MidTermProgram midTermProgram = new MidTermProgram();

            // Setting default size of circles to 3
            midTermProgram.setDefaultSize('c', 3);
            midTermProgram.setDefaultSize('t', 4);

            // Checking default sizes of shapes.
            Assert.AreEqual(midTermProgram.getDefaultSize('c'), 3);
            Assert.AreEqual(midTermProgram.getDefaultSize('s'), 1);
            Assert.AreEqual(midTermProgram.getDefaultSize('t'), 4);
        }

        /// <summary>
        /// Tests adding a shape to a sequence in the history.
        /// This is for modifying the history.
        /// </summary>
        [Test]
        public void MidTermTestAddToSequence()
        {
            MidTermProgram midTermProgram = new MidTermProgram();

            midTermProgram.setDefaultSize('c', 3);

            // Circle Square Triangle Circle
            string input = "c s t c";

            midTermProgram.createSequence(input);

            midTermProgram.setCurrentSequence(0);

            midTermProgram.addToSequence('t');

            Shape[] shapes = midTermProgram.getCurrentSequence();

            Assert.AreEqual(shapes[4].getType(), "Triangle");
            Assert.AreEqual(shapes[4].getSize(), 15);
            Assert.AreEqual(shapes[4].getCharacter(), 't');
            Assert.AreEqual(shapes[4].getArea(), 97.43);
        }

        /// <summary>
        /// Tests changing a shape to another shape in a sequence.
        /// This is for modifying the history.
        /// </summary>
        [Test]
        public void MidTermTestChangeShape()
        {
            MidTermProgram midTermProgram = new MidTermProgram();

            midTermProgram.setDefaultSize('c', 3);

            // Circle Square Triangle Circle
            string input = "c s t c";

            midTermProgram.createSequence(input);

            midTermProgram.setCurrentSequence(0);

            Shape[] shapes = midTermProgram.getCurrentSequence();

            Assert.AreEqual(shapes[0].getType(), "Circle");
            Assert.AreEqual(shapes[0].getSize(), 3);
            Assert.AreEqual(shapes[0].getCharacter(), 'c');
            Assert.AreEqual(shapes[0].getArea(), 28.27);

            // Change first shape to triangle
            midTermProgram.changeShape(0, 't');

            shapes = midTermProgram.getCurrentSequence();

            Assert.AreEqual(shapes[0].getType(), "Triangle");
            Assert.AreEqual(shapes[0].getSize(), 3);
            Assert.AreEqual(shapes[0].getCharacter(), 't');
            Assert.AreEqual(shapes[0].getArea(), 3.90);
        }

        /// <summary>
        /// Tests deleting a shape from a sequence and ensuring the
        /// sizes are updated properly. This is for modifying the history.
        /// </summary>
        [Test]
        public void MidTermTestRemoveShape()
        {
            MidTermProgram midTermProgram = new MidTermProgram();

            midTermProgram.setDefaultSize('c', 3);

            // Circle Square Triangle Circle
            string input = "c s t c";

            midTermProgram.createSequence(input);

            midTermProgram.setCurrentSequence(0);

            Shape[] shapes = midTermProgram.getCurrentSequence();

            Assert.AreEqual(shapes[0].getType(), "Circle");
            Assert.AreEqual(shapes[0].getSize(), 3);
            Assert.AreEqual(shapes[0].getCharacter(), 'c');
            Assert.AreEqual(shapes[0].getArea(), 28.27);

            // Deleting the first circle so square should be first
            midTermProgram.deleteShape(0);

            shapes = midTermProgram.getCurrentSequence();

            // Square is now first and has base size 1. So sequence should be
            // updated accordingly.
            Assert.AreEqual(shapes[0].getType(), "Square");
            Assert.AreEqual(shapes[0].getSize(), 1);
            Assert.AreEqual(shapes[0].getCharacter(), 's');
            Assert.AreEqual(shapes[0].getArea(), 1);

            Assert.AreEqual(shapes[1].getType(), "Triangle");
            Assert.AreEqual(shapes[1].getSize(), 2);
            Assert.AreEqual(shapes[1].getCharacter(), 't');
            Assert.AreEqual(shapes[1].getArea(), 1.73);
        }
    }
}