namespace HW2.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests for HW2 functions.
    /// </summary>
    public class HW2Tests
    {
        /// <summary>
        /// Initial setup function.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Tests the hashset implementation.
        /// </summary>
        [Test]
        public void HashSetTest()
        {
            List<int> emptyList = new List<int>();
            List<int> oneDistinctList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            ThreeDistinct firstDistinct = new ThreeDistinct();
            ThreeDistinct firstDistinctEmpty = new ThreeDistinct(emptyList);
            ThreeDistinct firstDistinctOne = new ThreeDistinct(oneDistinctList);

            Assert.AreEqual(firstDistinct.HashSetMethod(), (firstDistinct.GetList()).Distinct());
            Assert.AreEqual(firstDistinctEmpty.HashSetMethod(), (firstDistinct.GetList()).Distinct());
            Assert.AreEqual(firstDistinctOne.HashSetMethod(), (firstDistinct.GetList()).Distinct());

            Assert.Pass();
        }

        /// <summary>
        /// Tests the O(1) storage implementation.
        /// </summary>
        public void BigOOneTest()
        {
            List<int> emptyList = new List<int>();
            List<int> oneDistinctList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            ThreeDistinct secondDistinct = new ThreeDistinct();
            ThreeDistinct secondDistinctEmpty = new ThreeDistinct(emptyList);
            ThreeDistinct secondDistinctOne = new ThreeDistinct(oneDistinctList);

            Assert.AreEqual(secondDistinct.BigOOneMethod(), (secondDistinct.GetList()).Distinct());
            Assert.AreEqual(secondDistinctEmpty.BigOOneMethod(), (secondDistinct.GetList()).Distinct());
            Assert.AreEqual(secondDistinctOne.BigOOneMethod(), (secondDistinct.GetList()).Distinct());

            Assert.Pass();
        }

        /// <summary>
        /// Tests the sorted list implementation.
        /// </summary>
        public void SortedTest()
        {
            List<int> emptyList = new List<int>();
            List<int> oneDistinctList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            ThreeDistinct thirdDistinct = new ThreeDistinct();
            ThreeDistinct thirdDistinctEmpty = new ThreeDistinct(emptyList);
            ThreeDistinct thirdDistinctOne = new ThreeDistinct(oneDistinctList);

            Assert.AreEqual(thirdDistinct.SortedMethod(), (thirdDistinct.GetList()).Distinct());
            Assert.AreEqual(thirdDistinctEmpty.SortedMethod(), (thirdDistinct.GetList()).Distinct());
            Assert.AreEqual(thirdDistinctOne.SortedMethod(), (thirdDistinct.GetList()).Distinct());

            Assert.Pass();
        }
    }
}