using NUnit.Framework;
using HW3;
using System.Text;
using System.IO;

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
            FibonacciTextReader testFibTextReaderTwenty = new FibonacciTextReader(20);
            FibonacciTextReader testFibTextReaderFive = new FibonacciTextReader(5);
            FibonacciTextReader testFibTextReaderThirteen = new FibonacciTextReader(13);

            string firstTwentyFibNumbers = "1: 0\r\n2: 1\r\n3: 2\r\n4: 3\r\n5: 5\r\n6: 8\r\n7: 13\r\n8: 21\r\n9: 34\r\n10: 55\r\n11: 89\r\n12: 144\r\n13: 233\r\n14: 377\r\n14: 377\r\n"
                + "15: 610\r\n16: 987\r\n17: 1597\r\n18: 2584\r\n19: 4184\r\n20: 6765\r\n21: 10946\r\n22: 17711\r\n23: 28657\r\n24: 46368\r\n25: 46368\r\n";
            string firstFiveFibNumbers = "1: 0\r\n2: 1\r\n3: 2\r\n4: 3\r\n5: 5\r\n";
            string firstThirteenFibNumbers = "1: 0\r\n2: 1\r\n3: 2\r\n4: 3\r\n5: 5\r\n6: 8\r\n7: 13\r\n8: 21\r\n9: 34\r\n10: 55\r\n11: 89\r\n12: 144\r\n13: 233\r\n";

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
            string testText = "This is test text used for testing the save file.";
            string testTextFileTitle = "SaveFileTestText.txt";

            testForm.SetTextBoxText(testText);
            testForm.SaveFile();
            StreamReader newStreamWriter = new StreamReader(testTextFileTitle);

            Assert.AreEqual(testText, newStreamWriter.ReadToEnd());

            Assert.Pass();
        }
    }
}