// <copyright file="Exam1Tests.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

namespace Exam1Tests
{
    using NUnit.Framework;

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
            Product Shoes = new Product();
            Shoes.SetID("Shoes");
            Shoes.SetDescription("A pair of shoes.");

            Product Socks = new Product();
            Socks.SetID("Socks");
            Socks.SetDescription("A pair of socks.");

            Product eBook = new Product();
            eBook.SetID("eBook");
            eBook.SetDescription("An electronic book.");

            List<Product> emptyProductList = new List<Product>;

            List<Product> allProductsList = new List<Product>;
            allProductsList.Add(Shoes);
            allProductsList.Add(Socks);
            allProductsList.Add(eBook);

            List<Product> shoesAndSocksList = new List<Product>;
            allProductsList.Add(Shoes);
            allProductsList.Add(Socks);

            Store testStore = new Store();
            testStore.SetProducts(allProductsList);

            // Using except on the output list and the shoesAndSocksList to check if the set differance is empty.
            Assert.IsFalse(shoesAndSocksList.Except(testStore.Search("pair", string.Empty)).ToList().Any());

            // Empty search should return the entire list of products.
            Assert.IsFalse(allProductsList.Except(testStore.Search(string.Empty, string.Empty)).ToList().Any());

            // Should get empty list back for search.
            Assert.IsFalse(emptyProductList.Except(testStore.Search("Watermelon", string.Empty)).ToList().Any());

            // And search should only return the socks.
            Assert.IsFalse(emptyProductList.Except(testStore.Search("pair Socks", "And")).ToList().Any());

            // Or search should return eBook and Socks.
            Assert.IsFalse(emptyProductList.Except(testStore.Search("eBook Socks", "Or")).ToList().Any());

            Assert.Pass();
        }

        /// <summary>
        /// Tests the save search function.
        /// </summary>
        [Test]
        public void SaveSearchTest()
        {
            Product Shoes = new Product();
            Shoes.SetID("Shoes");
            Shoes.SetDescription("A pair of shoes.");

            Product Socks = new Product();
            Socks.SetID("Socks");
            Socks.SetDescription("A pair of socks.");

            Product eBook = new Product();
            eBook.SetID("eBook");
            eBook.SetDescription("An electronic book.");

            List<Product> emptyProductList = new List<Product>;

            List<Product> allProductsList = new List<Product>;
            allProductsList.Add(Shoes);
            allProductsList.Add(Socks);
            allProductsList.Add(eBook);

            List<Product> shoesAndSocksList = new List<Product>;
            allProductsList.Add(Shoes);
            allProductsList.Add(Socks);

            Store testStore = new Store();
            testStore.SetProducts(allProductsList);

            // Make a dummy search.
            testStore.Search("pair", string.Empty);
            var fileNameCheck = testStore.GetRecentSearchTime();

            Assert.Pass();
        }

        /// <summary>
        /// Tests the restock function.
        /// </summary>
        [Test]
        public void RestockTest()
        {
            Product Shoes = new Product();
            Shoes.SetID("Shoes");
            Shoes.SetDescription("A pair of shoes.");
            Shoes.SetIsPhysical(true);
            Shoes.SetInStock(2);

            Product Socks = new Product();
            Socks.SetID("Socks");
            Socks.SetDescription("A pair of socks.");
            Socks.SetIsPhysical(true);
            Socks.SetInStock(3);

            Product eBook = new Product();
            eBook.SetID("eBook");
            eBook.SetDescription("An electronic book.");
            eBook.SetIsPhysical(false);
            eBook.SetInStock(0)

            List<Product> emptyProductList = new List<Product>;

            List<Product> allProductsList = new List<Product>;
            allProductsList.Add(Shoes);
            allProductsList.Add(Socks);
            allProductsList.Add(eBook);

            List<Product> shoesAndSocksList = new List<Product>;
            allProductsList.Add(Shoes);
            allProductsList.Add(Socks);

            Store testStore = new Store();
            testStore.SetProducts(allProductsList);



            Assert.Pass();
        }
    }
}