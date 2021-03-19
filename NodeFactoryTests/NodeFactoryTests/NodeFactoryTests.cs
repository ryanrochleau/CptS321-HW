// <copyright file="NodeFactoryTests.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using Cpts321;
using NUnit.Framework;

namespace NodeFactoryTests
{
    /// <summary>
    /// Test for the NodeFactory class.
    /// </summary>
    public class NodeFactoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Tests the precendce of each operator to ensure
        /// it is the correct value.
        /// </summary>
        [Test]
        public void TestPrecedence()
        {
            NodeFactory nodeFactory = new NodeFactory();

            Assert.AreEqual(1, nodeFactory.GetPrecedence('+'));
            Assert.AreEqual(1, nodeFactory.GetPrecedence('-'));
            Assert.AreEqual(2, nodeFactory.GetPrecedence('*'));
            Assert.AreEqual(2, nodeFactory.GetPrecedence('/'));
            Assert.Pass();
        }

        /// <summary>
        /// Tests the NodeFactory to ensure it returns the correct
        /// node types when requesting a node.
        /// </summary>
        [Test]
        public void TestTypes()
        {
            NodeFactory nodeFactory = new NodeFactory();
            double testConstantValue = 6.0;
            string testVariableValue = "A2";

            Assert.IsInstanceOf(ConstantNode, nodeFactory.GetNode(testConstantValue);

            Assert.IsInstanceOf(BinaryOpNode, nodeFactory.GetNode('+');
            Assert.IsInstanceOf(BinaryOpNode, nodeFactory.GetNode('-');
            Assert.IsInstanceOf(BinaryOpNode, nodeFactory.GetNode('*');
            Assert.IsInstanceOf(BinaryOpNode, nodeFactory.GetNode('/');

            Assert.IsInstanceOf(VariableNode, nodeFactory.GetNode(testVariableValue);

            Assert.Pass();
        }
    }
}