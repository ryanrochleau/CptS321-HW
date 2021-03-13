using System;
using System.Collections.Generic;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// Represents and expression tree.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// Root node of the expression tree.
        /// </summary>
        private Node rootNode;

        /// <summary>
        /// Dictionary containing variable strings and their corresponding values.
        /// </summary>
        private Dictionary<string, double> variablesDictionary = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// Constructor for the expression tree class. Constructs a tree
        /// from an expression string input.
        /// </summary>
        /// <param name="expression">Input expression as a string.</param>
        public ExpressionTree(string expression)
        {

        }

        /// <summary>
        /// Adds a variable to the classes dictionary.
        /// </summary>
        /// <param name="variableName">The name of the variable as a string.</param>
        /// <param name="variableValue">The value of the variable as a double.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.variablesDictionary.Add(variableName, variableValue);
        }

        /// <summary>
        /// Evaluates the expression tree.
        /// </summary>
        /// <returns>The value of the expression tree as a double.</returns>
        public double Evaluate()
        {
            if (this.rootNode != null)
            {
                switch (this.rootNode)
                {
                    case ConstantNode cNode: return cNode.Evaluate();
                    case BinaryOpNode bNode: return bNode.Evaluate();
                    case VariableNode vNode: return vNode.Evaluate();
                    default: throw new ArgumentException(string.Format("The root node of the expression tree is not a valid node type."));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("The root node of the expression tree is null."));
            }
        }
    }
}
