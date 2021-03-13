using NUnit.Framework;

namespace ArithemticTreeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAddition()
        {
            ExpressionTree testTree;

            testTree = new ExpressionTree("1+3+5+7+9");
            Assert.AreEqual(testTree.Evaluate(), 25);

            testTree = new ExpressionTree("A+B+C");
            testTree.AddVariable("A", 1);
            testTree.AddVariable("B", 2);
            testTree.AddVariable("C", 3);
            Assert.AreEqual(testTree.Evaluate(), 6);

            testTree = new ExpressionTree("1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1+1");
            Assert.AreEqual(testTree.Evaluate(), 40);


            Assert.Pass();
        }

        public void TestSubtraction()
        {
            ExpressionTree testTree;

            testTree = new ExpressionTree("9-6");
            Assert.AreEqual(testTree.Evaluate(), 3);

            testTree = new ExpressionTree("A-B-C");
            testTree.AddVariable("A", 1);
            testTree.AddVariable("B", 2);
            testTree.AddVariable("C", 3);
            Assert.AreEqual(testTree.Evaluate(), -4);

            testTree = new ExpressionTree("1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1-1");
            Assert.AreEqual(testTree.Evaluate(), -40);


            Assert.Pass();
        }

        public void TestMultiplication()
        {
            ExpressionTree testTree;

            testTree = new ExpressionTree("9*6");
            Assert.AreEqual(testTree.Evaluate(), 54);

            testTree = new ExpressionTree("A*B*C");
            testTree.AddVariable("A", 1);
            testTree.AddVariable("B", 2);
            testTree.AddVariable("C", 4);
            Assert.AreEqual(testTree.Evaluate(), 8);

            testTree = new ExpressionTree("1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1*1");
            Assert.AreEqual(testTree.Evaluate(), 1);


            Assert.Pass();
        }

        public void TestDivision()
        {
            ExpressionTree testTree;

            testTree = new ExpressionTree("9/3");
            Assert.AreEqual(testTree.Evaluate(), 3);

            testTree = new ExpressionTree("C/B/A");
            testTree.AddVariable("A", 1);
            testTree.AddVariable("B", 2);
            testTree.AddVariable("C", 4);
            Assert.AreEqual(testTree.Evaluate(), 2);

            testTree = new ExpressionTree("1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1");
            Assert.AreEqual(testTree.Evaluate(), 1);


            Assert.Pass();
        }
    }
}