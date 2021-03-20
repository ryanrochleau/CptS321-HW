// <copyright file="ExpressionTree.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
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
            this.rootNode = this.CreateTree(expression);
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
        private Node CreateTree(string expression)
        {
            // Need to evaulate the expression right to left
            // so the constructed tree is valid.
            int expressionLength = expression.Length;
            bool found = false;

            if (expressionLength > 0)
            {
                // Find the first BinaryOp if it exists.
                while (!found && expressionLength > 0)
                {
                    switch (expression[expressionLength - 1])
                    {
                        case '-': found = true; break;
                        case '+': found = true; break;
                        case '/': found = true; break;
                        case '*': found = true; break;
                        default: found = false; break;
                    }

                    if (found)
                    {
                        break;
                    }

                    expressionLength--;
                }

                // Found a binary operator so create a node and call CreateTree
                // on the left and right substrings.
                if (found)
                {
                    BinaryOpNode binaryOpNode = new BinaryOpNode();
                    binaryOpNode.Operator = expression[expressionLength - 1];
                    binaryOpNode.LeftNode = this.CreateTree(expression.Substring(0, expressionLength - 1));
                    binaryOpNode.RightNode = this.CreateTree(expression.Substring(expressionLength));

                    return binaryOpNode;
                }

                // Binary operator wasn't found so we either have a variable or a
                // constant value.
                else
                {
                    // Checking to see if the value can be converted to double.
                    // Will throw a FormatException if value is not in right format.
                    // This should indicate a variable.
                    try
                    {
                        double constantValue = Convert.ToDouble(expression);
                        ConstantNode constantNode = new ConstantNode();
                        constantNode.ConstantValue = constantValue;

                        return constantNode;
                    }

                    // FormatException thrown should indicate that expression is a variable
                    // and not a double.
                    catch (FormatException)
                    {
                        VariableNode variableNode = new VariableNode();
                        variableNode.VariableName = expression;
                        variableNode.VariableValue = 1;

                        return variableNode;
                    }
                }
            }

            return null;
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
        public string[] ConvertInfixToPostFix(string expression)
        {
            List<string> result = new List<string>();
            Stack<string> stack = new Stack<string>();
            NodeFactory nodeFactory = new NodeFactory();

            // Regex that splits the expression into an array of tokens
            // Example "B2+(5-3*A2)+1" goes to ["B2",'+','(','5','-','3','*',"A2",')','+','1']
            string[] expressionArray = Regex.Split(expression, @"(?=[-+*/()])|(?<=[-+*/()])");

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
                else if (nodeFactory.GetPrecedence(value[0]) == -1 && value[0]!='(' && value[0]!=')')
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
