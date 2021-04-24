// <copyright file="ArithemticTreeTests.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CptS321;
using NUnit.Framework;

namespace ArithemticTreeTests
{
    /// <summary>
    /// Testing class.
    /// </summary>
    public class ArithemticTreeTests
    {
        /// <summary>
        /// Setup function for tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Tests tree using addition.
        /// </summary>
        [Test]
        public void TestAddition()
        {
            ExpressionTree testTree;

            testTree = new ExpressionTree("1+3+5+7+9");
            Assert.AreEqual(testTree.Evaluate(), 25);

            testTree = new ExpressionTree("A+B+C");
            testTree.SetVariable("A", 1);
            testTree.SetVariable("B", 2);
            testTree.SetVariable("C", 3);
            double testValue = testTree.Evaluate();
            Assert.AreEqual(testTree.Evaluate(), 6);

            testTree = new ExpressionTree("1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1");
            Assert.AreEqual(testTree.Evaluate(), 40);

            Assert.Pass();
        }

        /// <summary>
        /// Tests tree using subtraction.
        /// </summary>
        [Test]
        public void TestSubtraction()
        {
            ExpressionTree testTree;

            testTree = new ExpressionTree("9-6");
            Assert.AreEqual(testTree.Evaluate(), 3);

            testTree = new ExpressionTree("A-B-C");
            testTree.SetVariable("A", 1);
            testTree.SetVariable("B", 2);
            testTree.SetVariable("C", 3);
            Assert.AreEqual(testTree.Evaluate(), -4);

            testTree = new ExpressionTree("1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1");
            Assert.AreEqual(testTree.Evaluate(), -40);

            Assert.Pass();
        }

        /// <summary>
        /// Tests tree using multiplication.
        /// </summary>
        [Test]
        public void TestMultiplication()
        {
            ExpressionTree testTree;

            testTree = new ExpressionTree("9*6");
            Assert.AreEqual(testTree.Evaluate(), 54);

            testTree = new ExpressionTree("A*B*C");
            testTree.SetVariable("A", 1);
            testTree.SetVariable("B", 2);
            testTree.SetVariable("C", 4);
            Assert.AreEqual(testTree.Evaluate(), 8);

            testTree = new ExpressionTree("1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1");
            Assert.AreEqual(testTree.Evaluate(), 1);

            Assert.Pass();
        }

        /// <summary>
        /// Tests tree using division.
        /// </summary>
        [Test]
        public void TestDivision()
        {
            ExpressionTree testTree;

            testTree = new ExpressionTree("9/3");
            Assert.AreEqual(testTree.Evaluate(), 3);

            testTree = new ExpressionTree("C/B/A");
            testTree.SetVariable("A", 1);
            testTree.SetVariable("B", 2);
            testTree.SetVariable("C", 4);
            Assert.AreEqual(testTree.Evaluate(), 2);

            testTree = new ExpressionTree("1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1");
            Assert.AreEqual(testTree.Evaluate(), 1);

            Assert.Pass();
        }

        /// <summary>
        /// Tests tree using generic expression will multiple
        /// unique operators.
        /// </summary>
        [Test]
        public void TestGeneric()
        {
            ExpressionTree testTree;

            testTree = new ExpressionTree("2*(4+5)");
            Assert.AreEqual(testTree.Evaluate(), 18);

            testTree = new ExpressionTree("4+(5-3*2)+1");
            Assert.AreEqual(testTree.Evaluate(), 4);

            testTree = new ExpressionTree("(19-1)/2");
            Assert.AreEqual(testTree.Evaluate(), 9);

            testTree = new ExpressionTree("((((((((((2+3)*(4-1))))))))))");
            Assert.AreEqual(testTree.Evaluate(), 15);

            testTree = new ExpressionTree("A2*B2");
            testTree.SetVariable("A2", 5);
            testTree.SetVariable("B2", 2);
            Assert.AreEqual(testTree.Evaluate(), 10);

            testTree = new ExpressionTree("B2+(5-3*A2)+1");
            testTree.SetVariable("A2", 7);
            testTree.SetVariable("B2", 3);
            Assert.AreEqual(testTree.Evaluate(), -12);

            testTree = new ExpressionTree("3.2+5.4");
            Assert.AreEqual(testTree.Evaluate(), 8.6000000000000014d);

            Assert.Pass();
        }

        /// <summary>
        /// Test function to test the spreadsheet and ensure
        /// each cell is being properly evaluated and updated
        /// when other cells are being updated.
        /// </summary>
        [Test]
        public void TestSpreadsheet()
        {
            // Getting some cells to test with.
            Spreadsheet spreadsheet = new Spreadsheet(15, 15);
            SpreadsheetCell cellA1 = (SpreadsheetCell)spreadsheet.GetCell(0, 0);
            SpreadsheetCell cellA2 = (SpreadsheetCell)spreadsheet.GetCell(1, 0);
            SpreadsheetCell cellA3 = (SpreadsheetCell)spreadsheet.GetCell(2, 0);

            cellA1.SetActualText("42");
            cellA2.SetActualText("=A1");

            Assert.AreEqual(cellA1.GetTextValue(), cellA2.GetTextValue());

            cellA3.SetActualText("=A2*4-7");

            Assert.AreEqual(cellA3.GetTextValue(), "161");

            cellA1.SetActualText("13");

            Assert.AreEqual(cellA1.GetTextValue(), cellA2.GetTextValue());
            Assert.AreEqual(cellA3.GetTextValue(), "45");

            cellA2.SetActualText("53");
            cellA3.SetActualText("=A2/53*(4-7+5)");

            Assert.AreEqual(cellA3.GetTextValue(), "2");

            Assert.Pass();
        }

        /// <summary>
        /// Test function to test the undo and redo on text.
        /// </summary>
        [Test]
        public void TestUndoRedo()
        {
            Spreadsheet spreadsheet = new Spreadsheet(15, 15);
            SpreadsheetCell cellA1 = (SpreadsheetCell)spreadsheet.GetCell(0, 0);

            cellA1.SetActualText("42");
            TextUndoRedo undo = new TextUndoRedo(cellA1, string.Empty, "42");
            spreadsheet.AddUndo(undo);

            cellA1.SetActualText("73");
            undo = new TextUndoRedo(cellA1, "42", "73");
            spreadsheet.AddUndo(undo);

            spreadsheet.Undo();

            Assert.AreEqual(cellA1.GetTextValue(), "42");

            spreadsheet.Redo();

            Assert.AreEqual(cellA1.GetTextValue(), "73");

            spreadsheet.Undo();
            spreadsheet.Undo();

            Assert.AreEqual(cellA1.GetTextValue(), string.Empty);
        }

        /// <summary>
        /// Test function for testing undo and redo on color.
        /// </summary>
        [Test]
        public void TestUndoRedoColor()
        {
            Spreadsheet spreadsheet = new Spreadsheet(15, 15);
            SpreadsheetCell cellA1 = (SpreadsheetCell)spreadsheet.GetCell(0, 0);
            SpreadsheetCell cellA2 = (SpreadsheetCell)spreadsheet.GetCell(1, 0);
            List<Cell> cellList = new List<Cell>();
            List<uint> oldcolors = new List<uint>();

            oldcolors.Add(cellA1.GetColor());
            oldcolors.Add(cellA2.GetColor());

            cellA1.SetColor(0x4BCD3A9A);
            cellA2.SetColor(0x4BCD3A9A);

            cellList.Add(cellA1);
            cellList.Add(cellA2);

            ColorUndoRedo undo = new ColorUndoRedo(cellList, oldcolors, 0x4BCD3A9A);

            spreadsheet.AddUndo(undo);

            spreadsheet.Undo();

            Assert.AreEqual(cellA1.GetColor(), 0xFFFFFFFF);

            spreadsheet.Redo();

            Assert.AreEqual(cellA1.GetColor(), 0x4BCD3A9A);
        }

        /// <summary>
        /// Testing the load and save functionality of the spreadsheet.
        /// </summary>
        [Test]
        public void TestSaveLoad()
        {
            Spreadsheet spreadsheet = new Spreadsheet(15, 15);
            SpreadsheetCell cellA1 = (SpreadsheetCell)spreadsheet.GetCell(0, 0);
            SpreadsheetCell cellA2 = (SpreadsheetCell)spreadsheet.GetCell(1, 0);
            string pathName = Path.GetTempFileName();
            FileStream fs = File.Open(pathName, FileMode.Open, FileAccess.Write, FileShare.None);

            cellA1.SetColor(0x4BCD3A9A);
            cellA2.SetColor(0x7ACA2A9D);

            cellA1.SetActualText("42");
            cellA2.SetActualText("=A1");

            spreadsheet.Save(fs);
            fs.Close();

            // Reset the spreadsheet
            spreadsheet = new Spreadsheet(15, 15);
            cellA1 = (SpreadsheetCell)spreadsheet.GetCell(0, 0);
            cellA2 = (SpreadsheetCell)spreadsheet.GetCell(1, 0);

            Assert.AreNotEqual(cellA1.GetTextValue(), "42");
            Assert.AreNotEqual(cellA2.GetTextValue(), "42");
            Assert.AreNotEqual(cellA2.GetActualText(), "=A1");
            Assert.AreNotEqual(cellA1.GetColor(), 0x4BCD3A9A);
            Assert.AreNotEqual(cellA2.GetColor(), 0x7ACA2A9D);

            fs = File.Open(pathName, FileMode.Open, FileAccess.Read, FileShare.None);

            spreadsheet.Load(fs);
            fs.Close();

            Assert.AreEqual(cellA1.GetTextValue(), "42");
            Assert.AreEqual(cellA2.GetTextValue(), "42");
            Assert.AreEqual(cellA2.GetActualText(), "=A1");
            Assert.AreEqual(cellA1.GetColor(), 0x4BCD3A9A);
            Assert.AreEqual(cellA2.GetColor(), 0x7ACA2A9D);
        }

        /// <summary>
        /// Tests to ensure invalid cells are changed to either bad reference or circular reference.
        /// </summary>
        [Test]
        public void TestInvalidCells()
        {
            Spreadsheet spreadsheet = new Spreadsheet(15, 15);
            SpreadsheetCell cellA1 = (SpreadsheetCell)spreadsheet.GetCell(0, 0);
            SpreadsheetCell cellA2 = (SpreadsheetCell)spreadsheet.GetCell(1, 0);
            SpreadsheetCell cellB1 = (SpreadsheetCell)spreadsheet.GetCell(0, 1);
            SpreadsheetCell cellB2 = (SpreadsheetCell)spreadsheet.GetCell(1, 1);

            cellA1.SetActualText("=A1");

            Assert.AreEqual(cellA1.GetTextValue(), "!(self reference)");

            cellA1.SetActualText("=B1*2");
            cellB1.SetActualText("=B2*3");
            cellB2.SetActualText("=A2*4");
            cellA2.SetActualText("=A1*5");

            Assert.AreEqual(cellA2.GetTextValue(), "!(circular reference)");

            cellA2.SetActualText("=6+Cell*27");

            Assert.AreEqual(cellA2.GetTextValue(), "!(bad reference)");

            // Ensure A2 text value isn't bad reference before we use it to test again.
            cellA2.SetActualText("50");
            Assert.AreNotEqual(cellA2.GetTextValue(), "!(bad reference)");

            cellA2.SetActualText("=B90");
            Assert.AreEqual(cellA2.GetTextValue(), "!(bad reference)");
        }
    }
}