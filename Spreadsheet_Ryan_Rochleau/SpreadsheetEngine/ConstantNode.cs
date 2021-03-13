using System;
using System.Collections.Generic;
using System.Text;

namespace CptS321
{
    /// <summary>
    /// Node representing a contant value.
    /// </summary>
    internal class ConstantNode : Node
    {
        /// <summary>
        /// Gets or sets the value that the constant node is set to which is
        /// a double.
        /// </summary>
        private double ConstantValue { get; set; }
    }
}
