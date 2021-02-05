// <copyright file="BST.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class represent a binary search tree.
    /// </summary>
    internal class BST
    {
        private BSTNode root;

        /// <summary>
        /// Initializes a new instance of the <see cref="BST"/> class.
        /// Constructor for BST.
        /// </summary>
        public BST()
        {
            this.root = null;
        }

        /// <summary>
        /// Inserts a node into the binary search tree.
        /// </summary>
        /// <param name="inputData">An integer.</param>
        public void InsertNode(int inputData)
        {
            BSTNode newNode = new BSTNode(inputData);

            if (this.root == null)
            {
                this.root = newNode;
                return;
            }
            else
            {
                BSTNode traversalNode = this.root, parentNode = this.root;

                // Loop until we find an empty spot
                while (true)
                {
                    parentNode = traversalNode;

                    // Check for identical values
                    if (inputData == parentNode.GetData())
                    {
                        return;
                    }

                    // Input value is less than the current value
                    // so go left
                    if (inputData < parentNode.GetData())
                    {
                        traversalNode = parentNode.GetLeftNode();

                        if (traversalNode == null)
                        {
                            parentNode.SetLeftNode(newNode);
                            return;
                        }
                    }

                    // Input value is greater than the current value
                    // so go right
                    else
                    {
                        traversalNode = parentNode.GetRightNode();

                        if (traversalNode == null)
                        {
                            parentNode.SetRightNode(newNode);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Public function to print tree in order.
        /// Passes root into recursive PrintInSortedOrder function.
        /// </summary>
        public void PrintInSortedOrder()
        {
            this.PrintInSortedOrder(this.root);
        }

        /// <summary>
        /// Get the level count of the BST.
        /// </summary>
        /// <returns>Returns the level of the BST.</returns>
        public int GetTreeLevelCount()
        {
            return this.GetTreeLevelCount(this.root);
        }

        /// <summary>
        /// Gets the count of nodes in the binary search tree.
        /// </summary>
        /// <returns>The number of nodes in the BST as an integer.</returns>
        public int GetNodeCount()
        {
            return this.GetNodeCount(this.root);
        }

        /// <summary>
        /// Calculate the theoretical level count of
        /// a BST given its node count.
        /// </summary>
        /// <returns>
        /// Returns the theoretical level count
        /// of a BST.
        /// </returns>
        public int GetTheoreticalLevelCount()
        {
            return (int)Math.Ceiling(Math.Log2(this.GetNodeCount() + 1));
        }

        /// <summary>
        /// Main program which does everything for Homework 1.
        /// </summary>
        public void RunProgram()
        {
            string inputString;

            Console.WriteLine("Input a string of numbers delimited by a single space.");
            inputString = Console.ReadLine();

            string[] subs = inputString.Split(' ');
            int[] inputIntegers = Array.ConvertAll(subs, int.Parse);

            foreach (var num in inputIntegers)
            {
                this.InsertNode(num);
            }

            Console.WriteLine("\n" + "In Order");
            this.PrintInSortedOrder();

            Console.WriteLine("\n" + "Node Count: " + this.GetNodeCount() + "\n");

            Console.WriteLine("Levels: " + this.GetTreeLevelCount() + "\n");

            Console.WriteLine("Theoretical Levels: " + this.GetTheoreticalLevelCount() + "\n");
        }

        /// <summary>
        /// Recursive function that traverses and prints the BST.
        /// </summary>
        /// <param name="inputNode">The current BSTNode.</param>
        private void PrintInSortedOrder(BSTNode inputNode)
        {
            // In order traversal of list
            if (inputNode != null)
            {
                this.PrintInSortedOrder(inputNode.GetLeftNode());

                Console.WriteLine(inputNode.GetData() + " ");

                this.PrintInSortedOrder(inputNode.GetRightNode());
            }
        }

        /// <summary>
        /// Recursive function for counting the number of node in the BST.
        /// </summary>
        /// <param name="inputNode">The current BSTNode.</param>
        /// <returns>Returns the count of child nodes and itself.</returns>
        private int GetNodeCount(BSTNode inputNode)
        {
            int count = 1;
            if (inputNode == null)
            {
                return 0;
            }

            // Get count of nodes on left
            if (inputNode.GetLeftNode() != null)
            {
                count += this.GetNodeCount(inputNode.GetLeftNode());
            }

            // Get count of nodes on right
            if (inputNode.GetRightNode() != null)
            {
                count += this.GetNodeCount(inputNode.GetRightNode());
            }

            return count;
        }

        /// <summary>
        /// Main function which calculates the level of the BST.
        /// </summary>
        /// <param name="inputNode">The current node.</param>
        /// <returns>Returns the level of the current node.</returns>
        private int GetTreeLevelCount(BSTNode inputNode)
        {
            int leftLevel, rightLevel;
            if (inputNode == null)
            {
                return 0;
            }

            leftLevel = this.GetTreeLevelCount(inputNode.GetLeftNode());
            rightLevel = this.GetTreeLevelCount(inputNode.GetRightNode());

            if (leftLevel > rightLevel)
            {
                return leftLevel + 1;
            }
            else
            {
                return rightLevel + 1;
            }
        }
    }
}
