﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Load file button.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.LoadFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Save file button.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.SaveFile();
        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        public string GetTextBoxText()
        {
            string textBoxText = this.textBox1.Text;
            return textBoxText;
        }

        /// <summary>
        /// Uses a savefiledialog to save the textbox to a file.
        /// </summary>
        public void SaveFile()
        {
            SaveFileDialog newSaveFileDialog = new SaveFileDialog();
            newSaveFileDialog.Filter = "txt files (*.txt)|*.txt";
            newSaveFileDialog.Title = "Select File to Save to";

            // Selected a file successfully.
            if (newSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(newSaveFileDialog.FileName);

                streamWriter.WriteLine(this.textBox1.Text);
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Uses an openfiledialog to load a files text into the text box.
        /// </summary>
        public void LoadFile()
        {
            OpenFileDialog newOpenFileDialog = new OpenFileDialog();
            newOpenFileDialog.Filter = "txt files (*.txt)|*.txt";
            newOpenFileDialog.Title = "Select File to Load";

            // Selected a file successfully.
            if (newOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(newOpenFileDialog.FileName);
                this.textBox1.Text = streamReader.ReadToEnd();
            }
        }
    }
}
