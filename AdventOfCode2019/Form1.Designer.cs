namespace AdventOfCode2019
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProblemSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.InputFileTextBox = new System.Windows.Forms.TextBox();
            this.Part1ResultTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SolveButton = new System.Windows.Forms.Button();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Part2ResultTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ProblemSelector
            // 
            this.ProblemSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProblemSelector.FormattingEnabled = true;
            this.ProblemSelector.Items.AddRange(new object[] {
            "Day 1",
            "Day 2",
            "Day 3",
            "Day 4",
            "Day 5",
            "Day 6"});
            this.ProblemSelector.Location = new System.Drawing.Point(119, 13);
            this.ProblemSelector.Name = "ProblemSelector";
            this.ProblemSelector.Size = new System.Drawing.Size(454, 28);
            this.ProblemSelector.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Problem";
            // 
            // URLTextBox
            // 
            this.URLTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.URLTextBox.Location = new System.Drawing.Point(119, 79);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.ReadOnly = true;
            this.URLTextBox.Size = new System.Drawing.Size(454, 26);
            this.URLTextBox.TabIndex = 2;
            // 
            // InputFileTextBox
            // 
            this.InputFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputFileTextBox.Location = new System.Drawing.Point(119, 111);
            this.InputFileTextBox.Name = "InputFileTextBox";
            this.InputFileTextBox.ReadOnly = true;
            this.InputFileTextBox.Size = new System.Drawing.Size(454, 26);
            this.InputFileTextBox.TabIndex = 2;
            // 
            // Part1ResultTextBox
            // 
            this.Part1ResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Part1ResultTextBox.Location = new System.Drawing.Point(119, 143);
            this.Part1ResultTextBox.Multiline = true;
            this.Part1ResultTextBox.Name = "Part1ResultTextBox";
            this.Part1ResultTextBox.ReadOnly = true;
            this.Part1ResultTextBox.Size = new System.Drawing.Size(454, 28);
            this.Part1ResultTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "URL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Input File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Part 1 Result";
            // 
            // SolveButton
            // 
            this.SolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolveButton.Location = new System.Drawing.Point(12, 217);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(98, 33);
            this.SolveButton.TabIndex = 3;
            this.SolveButton.Text = "Solve!";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleTextBox.Location = new System.Drawing.Point(119, 47);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.ReadOnly = true;
            this.TitleTextBox.Size = new System.Drawing.Size(454, 26);
            this.TitleTextBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 50);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Title";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Part 2 Result";
            // 
            // Part2ResultTextbox
            // 
            this.Part2ResultTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Part2ResultTextbox.Location = new System.Drawing.Point(119, 177);
            this.Part2ResultTextbox.Multiline = true;
            this.Part2ResultTextbox.Name = "Part2ResultTextbox";
            this.Part2ResultTextbox.ReadOnly = true;
            this.Part2ResultTextbox.Size = new System.Drawing.Size(454, 28);
            this.Part2ResultTextbox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 262);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.Part2ResultTextbox);
            this.Controls.Add(this.Part1ResultTextBox);
            this.Controls.Add(this.InputFileTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProblemSelector);
            this.Name = "Form1";
            this.Text = "Advent Of Code 2019";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProblemSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.TextBox InputFileTextBox;
        private System.Windows.Forms.TextBox Part1ResultTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Part2ResultTextbox;
    }
}

