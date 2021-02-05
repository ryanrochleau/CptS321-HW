namespace HW1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class represent a binary search tree
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
                        traversalNode = this.root.GetLeftNode();

                        if (traversalNode == null)
                        {
                            parentNode.SetLeftNode(newNode);
                            return;
                        }
                    }
                    else
                    {
                        traversalNode = this.root.GetRightNode();

                        if (traversalNode == null)
                        {
                            parentNode.SetRightNode(newNode);
                            return;
                        }
                    }
                }
            }
        }
    }
}
