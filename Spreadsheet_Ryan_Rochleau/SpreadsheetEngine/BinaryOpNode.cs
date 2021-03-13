using System;
using System.Collections.Generic;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// Represents a binary operation node.
    /// </summary>
    internal class BinaryOpNode : Node
    {
        /// <summary>
        /// Gets or sets the operator of this node.
        /// </summary>
        private char Operator { get; set; }

        /// <summary>
        /// Gets or sets the left node.
        /// </summary>
        private Node LeftNode { get; set; }

        /// <summary>
        /// Gets or sets the right node.
        /// </summary>
        private Node RightNode { get; set; }

        /// <summary>
        /// Evaluates the expression tree rooted by
        /// this node.
        /// </summary>
        /// <returns>A double value which is the value of the expression tree
        /// rooted by this node.</returns>
        public override double Evaluate()
        {
            switch (this.Operator)
            {
                case '+': return this.LeftNode.Evaluate() + this.RightNode.Evaluate();
                case '-': return this.LeftNode.Evaluate() - this.RightNode.Evaluate();
                case '*': return this.LeftNode.Evaluate() * this.RightNode.Evaluate();
                case '/': return this.LeftNode.Evaluate() / this.RightNode.Evaluate();
                default: throw new ArgumentException(string.Format("The operator {0} is not a valid operator.", this.Operator), "Operator");
            }
        }
    }
}
