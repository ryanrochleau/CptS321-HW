using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    /// <summary>
    /// The class that represents a node
    /// </summary>
    class BSTNode
    {
        private int data;
        public BSTNode leftNode;
        public BSTNode rightNode;

        /// <summary>
        /// Constructor for BSTNode
        /// </summary>
        /// <param name="inputData"></param>
        public BSTNode(int inputData)
        {
            this.data = inputData;
            this.leftNode = null;
            this.rightNode = null;
        }

        /// <summary>
        /// Getter for integer data
        /// </summary>
        /// <returns>
        /// Returns the integer data in the node
        /// </returns>
        public int getData()
        {
            return this.data;
        }

        /// <summary>
        /// Getter for the left BSTNode
        /// </summary>
        /// <returns>
        /// Returns the left BSTNode
        /// </returns>
        public BSTNode getLeftNode()
        {
            return this.leftNode;
        }

        /// <summary>
        /// Getter for the right BSTNode
        /// </summary>
        /// <returns>
        /// Returns the right BSTNode
        /// </returns>
        public BSTNode getRightNode()
        {
            return this.rightNode;
        }

        /// <summary>
        /// Setter for the integer data
        /// </summary>
        /// <param name="inputData"></param>
        public void setData(int inputData)
        {
            this.data = inputData;
        }

        /// <summary>
        /// Setter for the left BSTNode
        /// </summary>
        /// <param name="inputNode"></param>
        public void setLeftNode(BSTNode inputNode)
        {
            this.leftNode = inputNode;
        }

        /// <summary>
        /// Setter for the right BSTNode
        /// </summary>
        /// <param name="inputNode"></param>
        public void setRightNode(BSTNode inputNode)
        {
            this.rightNode = inputNode;
        }
    }
}
