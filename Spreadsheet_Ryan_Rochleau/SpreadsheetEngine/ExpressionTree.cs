// <copyright file="ExpressionTree.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CptS321
{
    /// <summary>
    /// Represents and expression tree.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// The cell this expression tree belongs to.
        /// </summary>
        public Cell mainCell;

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
            this.Expression = expression;
            string[] postFix = this.ConvertInfixToPostFix(expression);
            this.rootNode = this.CreateTree(postFix);
        }

        /// <summary>
        /// Gets or sets the expression that is being evaluated in this tree.
        /// </summary>
        private string Expression { get; set; }

        /// <summary>
        /// Adds a variable to the classes dictionary.
        /// </summary>
        /// <param name="variableName">The name of the variable as a string.</param>
        /// <param name="variableValue">The value of the variable as a double.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            if (this.variablesDictionary.ContainsKey(variableName))
            {
                this.variablesDictionary[variableName] = variableValue;
            }
            else
            {
                this.variablesDictionary.Add(variableName, variableValue);
            }

            this.UpdateVariableValue(this.rootNode, variableName, variableValue);
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
                    case VariableNode vNode: return this.variablesDictionary[vNode.VariableName];
                    default: throw new ArgumentException(string.Format("The root node of the expression tree is not a valid node type."));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("The root node of the expression tree is null."));
            }
        }

        /// <summary>
        /// Creates an expression tree and returns the root node.
        /// </summary>
        /// <param name="expression">Expression which is a string.</param>
        /// <returns>A Node which is the rootNode of the expression tree.</returns>
        private Node CreateTree(string[] expression)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            NodeFactory nodeFactory = new NodeFactory();

            for (int i = 0; i < expression.Length; i++)
            {
                // Check if the node is a current value is a variable
                // or constant. If it is either, create the node and
                // add it to the stack.
                if (this.IsVariableOrConstant(expression[i]))
                {
                    try
                    {
                        double constantValue = Convert.ToDouble(expression[i]);

                        nodeStack.Push(nodeFactory.GetNode(constantValue));
                    }
                    catch (FormatException)
                    {
                        nodeStack.Push(nodeFactory.GetNode(expression[i]));
                    }
                }
                else
                {
                    // Not a variable or constant so it must be a operator.
                    // Pop two nodes off the stack and add them to the left and
                    // right of the operator node. Then push the node back on
                    // the stack.
                    try
                    {
                        Node rightNode = nodeStack.Pop();
                        Node leftNode = nodeStack.Pop();

                        BinaryOpNode binaryOpNode = nodeFactory.GetNode(expression[i][0]);
                        binaryOpNode.LeftNode = leftNode;
                        binaryOpNode.RightNode = rightNode;
                        nodeStack.Push(binaryOpNode);
                    }
                    catch (InvalidOperationException)
                    {
                        throw new ArgumentException(string.Format("Stack is empty"));
                    }
                }
            }

            return nodeStack.Pop();
        }

        /// <summary>
        /// Updates all variables in the tree with the given value.
        /// </summary>
        /// <param name="currentNode">The current Node we are at in the tree.</param>
        /// <param name="variable">The variable whos value needs to be changed.</param>
        /// <param name="value">The new value for the variable.</param>
        private void UpdateVariableValue(Node currentNode, string variable, double value)
        {
            if (currentNode != null)
            {
                switch (currentNode)
                {
                    case ConstantNode cNode: break;
                    case BinaryOpNode bNode: this.UpdateVariableValue(bNode.LeftNode, variable, value); this.UpdateVariableValue(bNode.RightNode, variable, value); break;
                    case VariableNode vNode:
                        if (vNode.VariableName == variable)
                        {
                            vNode.VariableValue = value;
                        }

                        break;

                    default: throw new ArgumentException(string.Format("The current node of the expression tree is not a valid node type."));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("The current node of the expression tree is null."));
            }
        }

        /// <summary>
        /// Converts the infix expression to a postfix expression for easy
        /// expression tree construction.
        /// </summary>
        /// <param name="expression">The infix string expression.</param>
        /// <returns>Equivalence post fix string expression.</returns>
        private string[] ConvertInfixToPostFix(string expression)
        {
            List<string> result = new List<string>();
            Stack<string> stack = new Stack<string>();
            NodeFactory nodeFactory = new NodeFactory();

            // Regex that splits the expression into an array of tokens
            // Example "B2+(5-3*A2)+1" goes to ["B2",'+','(','5','-','3','*',"A2",')','+','1']
            string[] expressionArray = Regex.Split(expression, @"(?=[-+*/()])|(?<=[-+*/()])");

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == string.Empty)
                {
                    List<string> expressionList = expressionArray.ToList();
                    expressionList.RemoveAll(string.IsNullOrWhiteSpace);
                    expressionArray = expressionList.ToArray();
                }
            }

            for (int i = 0; i < expressionArray.Length; i++)
            {
                string stackString = expressionArray[i];

                // Check for a variable or double value and push it immediately to the result.
                if (this.IsVariableOrConstant(stackString))
                {
                    result.Add(stackString);
                }

                // Now check if instead, the value is an open parenthesis. This is pushed to the stack.
                else if (stackString[0] == '(')
                {
                    stack.Push(stackString);
                }

                // Now check if instead, the value is a closed parenthesis. This will cause all values in between
                // to be popped and added to the result.
                else if (stackString[0] == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        result.Add(stack.Pop());
                    }

                    // If the stack is empty, we did not find a "(". This is
                    // an invalid expression.
                    if (stack.Count == 0)
                    {
                        throw new ArgumentException(string.Format("The infix expression parenthesis are invalid."));
                    }

                    // If the count is not 0, the while loop must have ended when stack.Peek() == "("
                    // so we just pop it off since we don't want it in the result.
                    else
                    {
                        stack.Pop();
                    }
                }

                // Now the value must be a BinaryOp of some sort.
                else
                {
                    while (stack.Count > 0 && nodeFactory.GetPrecedence(stackString[0]) <= nodeFactory.GetPrecedence(stack.Peek()[0]))
                    {
                        result.Add(stack.Pop());
                    }

                    stack.Push(stackString);
                }
            }

            // Pop all remaining operators off the stack and add them to the result.
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }

            return result.ToArray();
        }

        /// <summary>
        /// Checks if the string is a variable.
        /// </summary>
        /// <param name="value">String to check.</param>
        /// <returns>True if the input is a variable and false
        /// if the input is not a variable.</returns>
        private bool IsVariableOrConstant(string value)
        {
            try
            {
                double constantValue = Convert.ToDouble(value);

                return true;
            }

            // FormatException thrown should indicate that expression is a variable
            // and not a double.
            catch (FormatException)
            {
                NodeFactory nodeFactory = new NodeFactory();
                if (value.Length > 1)
                {
                    return true;
                }
                else if (nodeFactory.GetPrecedence(value[0]) == -1 && value[0] != '(' && value[0] != ')')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
