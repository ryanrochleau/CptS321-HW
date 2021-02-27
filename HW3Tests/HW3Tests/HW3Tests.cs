using NUnit.Framework;
using HW3;

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
            Form1 testForm = new Form1();
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
            testForm.LoadFromFile();
            Assert.AreEqual(testForm.GetTextBoxText(), emptyTextString);

            // Loading from fullTestFileString.
            testForm.LoadFromFile();
            Assert.AreEqual(testForm.GetTextBoxText(), fullTestFileString);

            // Loading from fullTestFileStringTwo.
            testForm.LoadFromFile();
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
            Assert.Pass();
        }
    }
}