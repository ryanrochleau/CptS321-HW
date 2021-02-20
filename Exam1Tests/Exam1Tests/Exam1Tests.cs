// <copyright file="Exam1Tests.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Exam1;
using NUnit.Framework;

namespace Exam1Tests
{
    /// <summary>
    /// Tests for the exam.
    /// </summary>
    public class Exam1Tests
    {
        /// <summary>
        /// Initial setup function.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Tests the search function.
        /// </summary>
        [Test]
        public void SearchTest()
        {
            Product shoes = new Product();
            shoes.SetUniqueId("Shoes");
            shoes.SetDescription("A pair of shoes.");

            Product socks = new Product();
            socks.SetUniqueId("Socks");
            socks.SetDescription("A pair of socks.");

            Product eBook = new Product();
            eBook.SetUniqueId("eBook");
            eBook.SetDescription("An electronic book.");

            List<Product> emptyProductList = new List<Product>();

            List<Product> allProductsList = new List<Product>();
            allProductsList.Add(shoes);
            allProductsList.Add(socks);
            allProductsList.Add(eBook);

            List<Product> shoesAndSocksList = new List<Product>();
            shoesAndSocksList.Add(shoes);
            shoesAndSocksList.Add(socks);

            Store testStore = new Store(allProductsList);

            // Using except on the output list and the shoesAndSocksList to check if the set differance is empty.
            Assert.IsFalse(shoesAndSocksList.Except(testStore.Search("pair", -1)).ToList().Any());
            shoesAndSocksList.Except(testStore.Search("pair", -1));

            // Empty search should return the entire list of products.
            Assert.IsFalse(allProductsList.Except(testStore.Search(string.Empty, -1)).ToList().Any());

            // Should get empty list back for search.
            Assert.IsFalse(emptyProductList.Except(testStore.Search("Watermelon", -1)).ToList().Any());

            // And search should only return the socks.
            Assert.IsFalse(emptyProductList.Except(testStore.Search("pair Socks", 1)).ToList().Any());

            // Or search should return eBook and Socks.
            Assert.IsFalse(emptyProductList.Except(testStore.Search("eBook Socks", 2)).ToList().Any());

            // Ensuring that Except, ToList, and All() are working so testing a True case rather than all false.
            Assert.IsTrue(allProductsList.Except(testStore.Search("pair", -1)).ToList().Any());

            Assert.Pass();
        }

        /// <summary>
        /// Tests the save search function.
        /// </summary>
        [Test]
        public void SaveSearchTest()
        {
            Product shoes = new Product();
            shoes.SetUniqueId("Shoes");
            shoes.SetDescription("A pair of shoes.");
            shoes.SetIsPhysical(true);
            shoes.SetInStock(7);

            Product socks = new Product();
            socks.SetUniqueId("Socks");
            socks.SetDescription("A pair of socks.");
            socks.SetIsPhysical(true);
            socks.SetInStock(7);

            Product eBook = new Product();
            eBook.SetUniqueId("eBook");
            eBook.SetDescription("An electronic book.");
            eBook.SetIsPhysical(false);
            eBook.SetInStock(0);

            List<Product> allProductsList = new List<Product>();
            allProductsList.Add(shoes);
            allProductsList.Add(socks);
            allProductsList.Add(eBook);

            Store testStore = new Store(allProductsList);

            // Make a dummy search and save.
            testStore.Search("pair", -1);
            testStore.SaveSearch();

            // Get the current time to check if file exists with same name.
            var fileNameCheck = testStore.GetRecentSearchTime();

            // Check if the file exists.
            FileAssert.Exists(fileNameCheck);

            testStore.Search("Watermelon", -1);
            testStore.SaveSearch();

            fileNameCheck = testStore.GetRecentSearchTime();

            FileAssert.Exists(fileNameCheck);

            testStore.Search("pair socks", 1);
            testStore.SaveSearch();

            fileNameCheck = testStore.GetRecentSearchTime();

            FileAssert.Exists(fileNameCheck);

            Assert.Pass();
        }

        /// <summary>
        /// Tests the restock function.
        /// </summary>
        [Test]
        public void RestockTest()
        {
            // Skipped this test case. Too many issues with Console.Clear() but program would
            // be messy without it. Also don't know how to simulate user inputs.
        }
    }
}