// <copyright file="HW2Tests.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HW2.Tests
{
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

            // Standard random array
            Assert.AreEqual(firstDistinct.HashSetMethod(), firstDistinct.GetList().Distinct().Count());

            // Empty array
            Assert.AreEqual(firstDistinctEmpty.HashSetMethod(), firstDistinctEmpty.GetList().Distinct().Count());

            // Array with only one unique value but many entries
            Assert.AreEqual(firstDistinctOne.HashSetMethod(), firstDistinctOne.GetList().Distinct().Count());

            Assert.Pass();
        }

        /// <summary>
        /// Tests the O(1) storage implementation.
        /// </summary>
        [Test]
        public void BigOOneTest()
        {
            List<int> emptyList = new List<int>();
            List<int> oneDistinctList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            ThreeDistinct secondDistinct = new ThreeDistinct();
            ThreeDistinct secondDistinctEmpty = new ThreeDistinct(emptyList);
            ThreeDistinct secondDistinctOne = new ThreeDistinct(oneDistinctList);

            // Standard random array
            Assert.AreEqual(secondDistinct.BigOOneMethod(), secondDistinct.GetList().Distinct().Count());

            // Empty array
            Assert.AreEqual(secondDistinctEmpty.BigOOneMethod(), secondDistinctEmpty.GetList().Distinct().Count());

            // Array with only one unique value but many etries
            Assert.AreEqual(secondDistinctOne.BigOOneMethod(), secondDistinctOne.GetList().Distinct().Count());

            Assert.Pass();
        }

        /// <summary>
        /// Tests the sorted list implementation.
        /// </summary>
        [Test]
        public void SortedTest()
        {
            List<int> emptyList = new List<int>();
            List<int> oneDistinctList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            ThreeDistinct thirdDistinct = new ThreeDistinct();
            ThreeDistinct thirdDistinctEmpty = new ThreeDistinct(emptyList);
            ThreeDistinct thirdDistinctOne = new ThreeDistinct(oneDistinctList);

            // Standard random array
            Assert.AreEqual(thirdDistinct.SortedMethod(), thirdDistinct.GetList().Distinct().Count());

            // Empty array
            Assert.AreEqual(thirdDistinctEmpty.SortedMethod(), thirdDistinctEmpty.GetList().Distinct().Count());

            // Array with only one unique value but many entries
            Assert.AreEqual(thirdDistinctOne.SortedMethod(), thirdDistinctOne.GetList().Distinct().Count());

            Assert.Pass();
        }
    }
}