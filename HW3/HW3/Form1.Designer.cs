
namespace HW3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.FirstFiftyFibButton = new System.Windows.Forms.Button();
            this.FirstHundredFibButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-3, 36);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(805, 416);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadFileButton.Location = new System.Drawing.Point(-3, 0);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(91, 36);
            this.LoadFileButton.TabIndex = 1;
            this.LoadFileButton.Text = "Load From File";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileClick);
            // 
            // FirstFiftyFibButton
            // 
            this.FirstFiftyFibButton.Location = new System.Drawing.Point(94, 0);
            this.FirstFiftyFibButton.Name = "FirstFiftyFibButton";
            this.FirstFiftyFibButton.Size = new System.Drawing.Size(91, 36);
            this.FirstFiftyFibButton.TabIndex = 2;
            this.FirstFiftyFibButton.Text = "Fib 50";
            this.FirstFiftyFibButton.UseVisualStyleBackColor = true;
            this.FirstFiftyFibButton.Click += new System.EventHandler(this.FibFiftyClick);
            // 
            // FirstHundredFibButton
            // 
            this.FirstHundredFibButton.Location = new System.Drawing.Point(191, 0);
            this.FirstHundredFibButton.Name = "FirstHundredFibButton";
            this.FirstHundredFibButton.Size = new System.Drawing.Size(91, 36);
            this.FirstHundredFibButton.TabIndex = 3;
            this.FirstHundredFibButton.Text = "Fib 100";
            this.FirstHundredFibButton.UseVisualStyleBackColor = true;
            this.FirstHundredFibButton.Click += new System.EventHandler(this.FibHundredClick);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(288, 0);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(91, 36);
            this.SaveFileButton.TabIndex = 4;
            this.SaveFileButton.Text = "Save File";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileClick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.FirstHundredFibButton);
            this.Controls.Add(this.FirstFiftyFibButton);
            this.Controls.Add(this.LoadFileButton);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.Button FirstFiftyFibButton;
        private System.Windows.Forms.Button FirstHundredFibButton;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

