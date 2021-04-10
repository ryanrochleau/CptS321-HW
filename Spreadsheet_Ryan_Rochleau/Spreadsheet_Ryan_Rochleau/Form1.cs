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
            this.dataGridView1.CellBeginEdit += this.DataGridView1_CellBeginEdit;
            this.dataGridView1.CellEndEdit += this.DataGridView1_CellEndEdit;

            this.menuStrip1.Items[0].Enabled = false;
            this.menuStrip1.Items[1].Enabled = false;
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

            if (eString == "BeginUndo")
            {
                this.menuStrip1.Items[0].Enabled = true;
            }
            else if (eString == "StopUndo")
            {
                this.menuStrip1.Items[0].Enabled = false;
            }
            else if (eString == "BeginRedo")
            {
                this.menuStrip1.Items[1].Enabled = true;
            }
            else if (eString == "StopRedo")
            {
                this.menuStrip1.Items[1].Enabled = false;
            }
            else if (eStringValues[2].Contains("COLOR:"))
            {
                uint newColor = Convert.ToUInt32(eStringValues[2].Substring(6));
                this.dataGridView1.Rows[Convert.ToInt32(eStringValues[1])].Cells[Convert.ToInt32(eStringValues[0])].Style.BackColor = Color.FromArgb((int)newColor);
            }
            else
            {
                this.dataGridView1.Rows[Convert.ToInt32(eStringValues[1])].Cells[Convert.ToInt32(eStringValues[0])].Value = eStringValues[2];
            }
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
            if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).GetTextValue() != this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                {
                    Cell cell = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex);
                    TextUndoRedo textUndoRedo = new TextUndoRedo(cell, cell.GetActualText(), this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    this.spreadsheet.AddUndo(textUndoRedo);

                    cell.SetActualText(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
            else
            {
                this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).SetActualText(string.Empty);
            }
        }

        /// <summary>
        /// Triggers when the user begins to edit the cell. Shows the
        /// actual text in the cell when editing.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Want to update the DataGridViews value to the actual text when we begin editing.
            string actualText = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).GetActualText();

            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = actualText;
        }

        /// <summary>
        /// Triggers when the user stops editing the cell. Shows
        /// the cells value when done editing.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Want to update the DataGridViews value to the text value when we end editing.
            string textValue = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).GetTextValue();

            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = textValue;
        }

        /// <summary>
        /// Handles when a button is pressed on the menu strip.
        /// </summary>
        /// <param name="sender">The menu strip.</param>
        /// <param name="e">Argument parameters.</param>
        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Undo")
            {
                this.spreadsheet.Undo();
            }
            else if (e.ClickedItem.Text == "Redo")
            {
                this.spreadsheet.Redo();
            }
            else if (e.ClickedItem.Text == "Change Color")
            {
                List<Cell> updatedCells = new List<Cell>();
                List<uint> oldColors = new List<uint>();
                ColorDialog colorDialog = new ColorDialog();

                colorDialog.ShowDialog();

                // Retrieved this line from https://www.daniweb.com/programming/software-development/code/217202/color-to-uint-and-back
                uint newColor = (uint)((colorDialog.Color.A << 24) | (colorDialog.Color.R << 16) | (colorDialog.Color.G << 8) | (colorDialog.Color.B << 0));
                foreach (DataGridViewTextBoxCell cell in this.dataGridView1.SelectedCells)
                {
                    updatedCells.Add(this.spreadsheet.GetCell(cell.RowIndex, cell.ColumnIndex));
                    oldColors.Add(this.spreadsheet.GetCell(cell.RowIndex, cell.ColumnIndex).GetColor());

                    this.spreadsheet.GetCell(cell.RowIndex, cell.ColumnIndex).SetColor(newColor);
                }

                ColorUndoRedo colorUndoRedo = new ColorUndoRedo(updatedCells, oldColors, newColor);
                this.spreadsheet.AddUndo(colorUndoRedo);
            }
        }
    }
}
