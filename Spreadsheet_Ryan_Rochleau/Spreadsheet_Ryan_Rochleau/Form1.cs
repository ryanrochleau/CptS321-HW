// <copyright file="Form1.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spreadsheet_Ryan_Rochleau
{
    /// <summary>
    /// Form for HW4.
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
        /// Function for when a cell is clicked on.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        /// <summary>
        /// Function for when the Form loads.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnCount = 26;
            this.dataGridView1.RowCount = 50;

            for (int i = 0; i < 26; i++)
            {
                this.dataGridView1.Columns[i].Name = ((char)(i + 65)).ToString();
            }

            for (int i = 0; i < 50; i++)
            {
                this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
    }
}
