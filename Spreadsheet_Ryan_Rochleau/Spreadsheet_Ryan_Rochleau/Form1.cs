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
using CptS321;

namespace Spreadsheet_Ryan_Rochleau
{
    /// <summary>
    /// Form for HW4.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The spreadsheet class.
        /// </summary>
        private Spreadsheet spreadsheet;

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
            Console.WriteLine("test");
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

            this.spreadsheet = new Spreadsheet(50, 26);

            this.spreadsheet.PropertyChanged += this.UpdateGridCell;

            this.dataGridView1.CellValueChanged += this.DataGridView1_CellValueChanged;
        }

        /// <summary>
        /// This is fired off when the spreadsheet is changed. Will use the argument e to determine
        /// what was changed and where to update it on the spreadsheet.
        /// </summary>
        /// <param name="sender">The sender object which will be a spreadsheet.</param>
        /// <param name="e">The event arguments given when the even was fired from the spreadsheet class.</param>
        private void UpdateGridCell(object sender, PropertyChangedEventArgs e)
        {
                // String should be something like "Col,Row,Val" or "A,6,"Random text"".
                string eString = e.PropertyName;
                string[] eStringValues = eString.Split(',');

                this.dataGridView1.Rows[Convert.ToInt32(eStringValues[1])].Cells[Convert.ToInt32(eStringValues[0])].Value = eStringValues[2];
        }

        /// <summary>
        /// Button that runs a code demo on click.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void PerformDemo_Click(object sender, EventArgs e)
        {
            Random randomGenerator = new Random();

            int row, col;

            for (int i = 0; i < 50; i++)
            {
                row = randomGenerator.Next(50);
                col = randomGenerator.Next(26);

                this.dataGridView1.Rows[row].Cells[col].Value = "Hello World!";
            }

            for (int i = 0; i < 50; i++)
            {
                this.dataGridView1.Rows[i].Cells[1].Value = "This is cell B" + (i + 1).ToString();
            }

            for (int i = 0; i < 50; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = "=B" + (i + 1).ToString();
            }
        }

        /// <summary>
        /// Event for when a cell value is changed in the DataGrid. Updates the spreadsheet cell using SetActualText.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).SetActualText(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }
    }
}
