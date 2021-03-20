// <copyright file="NodeFactory.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// Class for NodeFactory. Produces nodes.
    /// </summary>
    internal class NodeFactory
    {
        /// <summary>
        /// Gets the precendence of an operator.
        /// </summary>
        /// <param name="op">Operator character.</param>
        /// <returns>An integer representing the precedence. Higher number
        /// is higher precedence and vice versa.</returns>
        public int GetPrecedence(char op)
        {
            switch (op)
            {
                case '-':
                    return 1;
                case '+':
                    return 1;
                case '*':
                    return 2;
                case '/':
                    return 2;
            }

            return -1;
        }

        /// <summary>
        /// Overloaded GetNode function for creating a ConstantNode.
        /// </summary>
        /// <param name="value">Double value for the node.</param>
        /// <returns>A ConstantNode.</returns>
        public ConstantNode GetNode(double value)
        {
            ConstantNode constantNode = new ConstantNode();
            constantNode.ConstantValue = value;
            return constantNode;
        }

        /// <summary>
        /// Overloaded GetNode function for creating a VariableNode.
        /// </summary>
        /// <param name="value">String name of the variable.</param>
        /// <returns>A VariableNode with initial value 0.</returns>
        public VariableNode GetNode(string value)
        {
            VariableNode variableNode = new VariableNode();
            variableNode.VariableName = value;
            variableNode.VariableValue = 0;
            return variableNode;
        }

        /// <summary>
        /// Overloaded GetNode function for creating a BinaryOpNode.
        /// </summary>
        /// <param name="value">Operator char.</param>
        /// <returns>A BinaryOpNode.</returns>
        public BinaryOpNode GetNode(char value)
        {
            if (this.GetPrecedence(value) != -1)
            {
                BinaryOpNode newNode = new BinaryOpNode();
                newNode.Operator = value;
                return newNode;
            }
            else
            {
                return null;
            }
        }
    }
}
