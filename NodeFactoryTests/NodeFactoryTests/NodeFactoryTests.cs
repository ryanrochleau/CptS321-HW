// <copyright file="NodeFactoryTests.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using Cpts321;
using NUnit.Framework;

namespace NodeFactoryTests
{
    public class NodeFactoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

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