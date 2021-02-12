namespace HW2
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
