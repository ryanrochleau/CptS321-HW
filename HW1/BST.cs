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

                while (true)
                {
                    parentNode = traversalNode;

                    if (inputData < this.root.GetData())
                    {
                        traversalNode = parentNode.GetLeftNode();

                        if (traversalNode == null)
                        {
                            parentNode.SetLeftNode(newNode);
                            return;
                        }
                    }
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
        /// Recursive function that traverses and prints the BST.
        /// </summary>
        /// <param name="inputNode">The current BSTNode.</param>
        private void PrintInSortedOrder(BSTNode inputNode)
        {
            if (inputNode != null)
            {
                this.PrintInSortedOrder(inputNode.GetLeftNode());

                Console.WriteLine(inputNode.GetData() + " ");

                this.PrintInSortedOrder(inputNode.GetRightNode());
            }
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
        /// Recursive function for counting the number of node in the BST.
        /// </summary>
        /// <param name="inputNode">The current BSTNode.</param>
        /// <returns>Returns the count of child nodes and itself</returns>
        private int GetNodeCount(BSTNode inputNode)
        {
            int count = 1;
            if (inputNode == null)
            {
                return 0;
            }

            if (inputNode.GetLeftNode() != null)
            {
                count += this.GetNodeCount(inputNode.GetLeftNode());
            }

            if (inputNode.GetRightNode() != null)
            {
                count += this.GetNodeCount(inputNode.GetRightNode());
            }

            return count;
        }
    }
}
