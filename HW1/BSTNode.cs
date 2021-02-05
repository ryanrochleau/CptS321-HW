namespace HW1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class that represents a node.
    /// </summary>
    internal class BSTNode
    {
        private int data;
        private BSTNode leftNode;
        private BSTNode rightNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="BSTNode"/> class.
        /// Constructor for BSTNode.
        /// </summary>
        /// <param name="inputData">An integer.</param>
        public BSTNode(int inputData)
        {
            this.data = inputData;
            this.leftNode = null;
            this.rightNode = null;
        }

        /// <summary>
        /// Getter for integer data.
        /// </summary>
        /// <returns>
        /// Returns the integer data in the node.
        /// </returns>
        public int GetData()
        {
            return this.data;
        }

        /// <summary>
        /// Getter for the left BSTNode.
        /// </summary>
        /// <returns>
        /// Returns the left BSTNode.
        /// </returns>
        public BSTNode GetLeftNode()
        {
            return this.leftNode;
        }

        /// <summary>
        /// Getter for the right BSTNode.
        /// </summary>
        /// <returns>
        /// Returns the right BSTNode.
        /// </returns>
        public BSTNode GetRightNode()
        {
            return this.rightNode;
        }

        /// <summary>
        /// Setter for the integer data.
        /// </summary>
        /// <param name="inputData">An integer.</param>
        public void SetData(int inputData)
        {
            this.data = inputData;
        }

        /// <summary>
        /// Setter for the left BSTNode.
        /// </summary>
        /// <param name="inputNode">A BSTNode.</param>
        public void SetLeftNode(BSTNode inputNode)
        {
            this.leftNode = inputNode;
        }

        /// <summary>
        /// Setter for the right BSTNode.
        /// </summary>
        /// <param name="inputNode">A BSTNode.</param>
        public void SetRightNode(BSTNode inputNode)
        {
            this.rightNode = inputNode;
        }
    }
}
