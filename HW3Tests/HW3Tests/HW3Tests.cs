// <copyright file="HW3Tests.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System.IO;
using System.Text;
using System.Windows.Forms;
using HW3;
using NUnit.Framework;

namespace HW3Tests
{
    /// <summary>
    /// Tests for homework 3.
    /// </summary>
    public class HW3Tests
    {
        /// <summary>
        /// Initial setup function.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Tests the fibonacci reader.
        /// </summary>
        [Test]
        public void FibonacciTest()
        {
            FibonacciTextReader testFibTextReaderTwenty = new FibonacciTextReader(25);
            FibonacciTextReader testFibTextReaderFive = new FibonacciTextReader(5);
            FibonacciTextReader testFibTextReaderThirteen = new FibonacciTextReader(13);

            string firstTwentyFibNumbers = "1: 0\r\n2: 1\r\n3: 1\r\n4: 2\r\n5: 3\r\n6: 5\r\n7: 8\r\n8: 13\r\n9: 21\r\n10: 34\r\n11: 55\r\n12: 89\r\n13: 144\r\n14: 233\r\n15: 377\r\n"
                + "16: 610\r\n17: 987\r\n18: 1597\r\n19: 2584\r\n20: 4181\r\n21: 6765\r\n22: 10946\r\n23: 17711\r\n24: 28657\r\n25: 46368\r\n";
            string firstFiveFibNumbers = "1: 0\r\n2: 1\r\n3: 1\r\n4: 2\r\n5: 3\r\n";
            string firstThirteenFibNumbers = "1: 0\r\n2: 1\r\n3: 1\r\n4: 2\r\n5: 3\r\n6: 5\r\n7: 8\r\n8: 13\r\n9: 21\r\n10: 34\r\n11: 55\r\n12: 89\r\n13: 144\r\n";

            Assert.AreEqual(firstTwentyFibNumbers, testFibTextReaderTwenty.ReadToEnd());
            Assert.AreEqual(firstFiveFibNumbers, testFibTextReaderFive.ReadToEnd());
            Assert.AreEqual(firstThirteenFibNumbers, testFibTextReaderThirteen.ReadToEnd());
            Assert.Pass();
        }

        /// <summary>
        /// Tests loading from a file.
        /// </summary>
        [Test]
        public void LoadFromFileTest()
        {
            Form1 testForm = new Form1();

            string emptyTextString = string.Empty;
            string fullTestFileString = "Test text file used in the LoadFromFileTest test.";
            string fullTestFileStringTwo = "Second test text file used in the LoadFromFileTest test.";

            // Loading the empty file first.
            testForm.LoadFile("emptyTestFile.txt");
            Assert.AreEqual(testForm.GetTextBoxText(), emptyTextString);

            // Loading from fullTestFileString.
            testForm.LoadFile("fullTestFile.txt");
            Assert.AreEqual(testForm.GetTextBoxText(), fullTestFileString);

            // Loading from fullTestFileStringTwo.
            testForm.LoadFile("fullTestFileTwo.txt");
            Assert.AreEqual(testForm.GetTextBoxText(), fullTestFileStringTwo);

            Assert.Pass();
        }

        /// <summary>
        /// Tests saving to a file.
        /// </summary>
        [Test]
        public void SaveFileTest()
        {
            Form1 testForm = new Form1();
            string testInputText = "This is test text used for testing the save file.";
            string testText = "This is test text used for testing the save file.\r\n";
            string testTextFileTitle = "SaveFileTestText.txt";

            testForm.SetTextBoxText(testInputText);
            testForm.SaveFile("SaveFileTestText.txt");
            StreamReader newStreamWriter = new StreamReader(testTextFileTitle);

            Assert.AreEqual(testText, newStreamWriter.ReadToEnd());

            Assert.Pass();
        }
    }
}