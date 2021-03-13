using System;
using System.Collections.Generic;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// Represents a variable in the expression tree.
    /// </summary>
    internal class VariableNode : Node
    {
        /// <summary>
        /// Gets or sets the name of the variable as a string.
        /// </summary>
        public string VariableName { get; set; }

        /// <summary>
        /// Gets or sets the value of the variable as a double.
        /// </summary>
        public double VariableValue { get; set; }

        /// <summary>
        /// Evaluated the variable node.
        /// </summary>
        /// <returns>Returns the value of node.</returns>
        public override double Evaluate()
        {
            return this.VariableValue;
        }
    }
}
