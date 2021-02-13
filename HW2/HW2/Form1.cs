﻿namespace HW2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Windows form class which handles all form operations.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Constructor for the form.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Function that executs as the form loads. Will handle
        /// printing all of the relevent information for the
        /// homework assignment.
        /// </summary>
        /// <param name="sender">An object value.</param>
        /// <param name="e">An EventArgs value.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ThreeDistinct randomList = new ThreeDistinct();

            this.textBox1.Text = $"1. HashSet method: {randomList.HashSetMethod()} unique numbers\r\n";
            this.textBox1.AppendText("Adding values to a HashSet is O(1) if the count is less than the capacity, else it is O(n).\r\n");
            this.textBox1.AppendText("This evaluates out to an amortized time complexity of O(1). Since we are performing an amortized time compexity O(1)\r\n");
            this.textBox1.AppendText("operation for each value n in the list, we have n * O(1) which evaluated to O(n), once again\r\n");
            this.textBox1.AppendText("assuming we are using the amortized time complexity. If not, worst case insert is O(n), which\r\n");
            this.textBox1.AppendText("with n values in the list, evaluates to O(n^2).\r\n");
            this.textBox1.AppendText($"2. O(1) storage method: {randomList.BigOOneMethod()} unique numbers\r\n");
            this.textBox1.AppendText($"3. Sorted method: {randomList.SortedMethod()} unique numbers\r\n");

        }

        /// <summary>
        /// Windows provided function for textbox change.
        /// </summary>
        /// <param name="sender">An object value.</param>
        /// <param name="e">An EventArgs value.</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
