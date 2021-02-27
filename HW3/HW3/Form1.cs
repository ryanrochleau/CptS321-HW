// <copyright file="Form1.cs" company="Ryan Rochleau">
// Copyright (c) Ryan Rochleau. All rights reserved.
// </copyright>

using System;
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
    /// <summary>
    /// Windows Form for HW3.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Constructor for the Windows form.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Setter for the textBox Text. Used during testing since
        /// testBox1 is private.
        /// </summary>
        /// <param name="inputText">Text to be inserted into textBox1.</param>
        public void SetTextBoxText(string inputText)
        {
            this.textBox1.Text = inputText;
        }

        /// <summary>
        /// Getter for the textBox Text. Used during testing since
        /// testBox1 is private.
        /// </summary>
        /// <returns>A string of text from textBox1.</returns>
        public string GetTextBoxText()
        {
            return this.textBox1.Text;
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
        /// Save function identical to the other save function without
        /// savefiledialog. NUnit does not work with savefiledialog.
        /// </summary>
        /// <param name="fileName">A file name string.</param>
        public void SaveFile(string fileName)
        {
            StreamWriter streamWriter = new StreamWriter(fileName);

            streamWriter.WriteLine(this.textBox1.Text);
            streamWriter.Close();
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

        /// <summary>
        /// Used for testing. Acts the same as LoadFile without OpenFileDialog.
        /// NUnit will not open an OpenFileDialog.
        /// </summary>
        /// <param name="fileName">Input file name.</param>
        public void LoadFile(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            this.textBox1.Text = streamReader.ReadToEnd();
        }

        /// <summary>
        /// Provided by the form automatically. Throws errors when removed.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Load file button.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void LoadFileClick(object sender, EventArgs e)
        {
            this.LoadFile();
        }

        /// <summary>
        /// Button for displaying first 50 numbers of the fibonacci sequence.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void FibFiftyClick(object sender, EventArgs e)
        {
            FibonacciTextReader fiftyNumbers = new FibonacciTextReader(50);
            this.textBox1.Text = fiftyNumbers.ReadToEnd();
        }

        /// <summary>
        /// Button for displaying first 100 numbers of the fibonacci sequence.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void FibHundredClick(object sender, EventArgs e)
        {
            FibonacciTextReader hundredNumbers = new FibonacciTextReader(100);
            this.textBox1.Text = hundredNumbers.ReadToEnd();
        }

        /// <summary>
        /// Save file button.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void SaveFileClick(object sender, EventArgs e)
        {
            this.SaveFile();
        }

        /// <summary>
        /// Provided by the form automatically. Not used but throws errors when removed.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void OpenFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
        }

        /// <summary>
        /// Provided by the form automatically. Not used but throws errors when removed.
        /// </summary>
        /// <param name="sender">Reference to control/object that raised the event.</param>
        /// <param name="e">Contains the event data.</param>
        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
    }
}
