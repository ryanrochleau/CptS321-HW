// <copyright file="Program.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Exam1
{
    /// <summary>
    /// Main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Standard main function.
        /// </summary>
        /// <param name="args">Inputs from terminal.</param>
        public static void Main(string[] args)
        {
            // Setting up some sample products
            Product shoes = new Product();
            shoes.SetUniqueId("Shoes");
            shoes.SetDescription("A pair of shoes.");
            shoes.SetIsPhysical(true);
            shoes.SetInStock(7);

            Product socks = new Product();
            socks.SetUniqueId("Socks");
            socks.SetDescription("A pair of socks.");
            socks.SetIsPhysical(true);
            socks.SetInStock(6);

            Product redBall = new Product();
            redBall.SetUniqueId("Red Ball");
            redBall.SetDescription("A red ball.");
            redBall.SetIsPhysical(true);
            redBall.SetInStock(5);

            Product eBook = new Product();
            eBook.SetUniqueId("eBook");
            eBook.SetDescription("An electronic book.");
            eBook.SetIsPhysical(false);
            eBook.SetInStock(0);

            Product visualStudio = new Product();
            visualStudio.SetUniqueId("Visual Studio");
            visualStudio.SetDescription("Copy of Visual Studio");
            visualStudio.SetIsPhysical(false);
            visualStudio.SetInStock(0);

            List<Product> allProductsList = new List<Product>();
            allProductsList.Add(shoes);
            allProductsList.Add(socks);
            allProductsList.Add(eBook);
            allProductsList.Add(redBall);

            Store testStore = new Store(allProductsList);

            // Run the program
            testStore.RunProgram();
        }
    }
}
