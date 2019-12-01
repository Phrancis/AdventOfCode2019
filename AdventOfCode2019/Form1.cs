using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateForm(string title, string url, string inputFile, string result)
        {
            TitleTextBox.Text = title;
            URLTextBox.Text = url;
            InputFileTextBox.Text = inputFile;
            ResultTextBox.Text = result;
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            int result;
            switch (ProblemSelector.GetItemText(ProblemSelector.SelectedItem))
            {
                case "Day 1 Problem 1":
                    Day1Problem1 d1p1 = new Day1Problem1();
                    result = d1p1.SolveProblem();
                    UpdateForm(d1p1.ProblemTitle, d1p1.ProblemUrl, d1p1.InputFilePath, result.ToString());
                    break;
                case "Day 1 Problem 2":
                    Day1Problem2 d1p2 = new Day1Problem2();
                    result = d1p2.SolveProblem();
                    UpdateForm(d1p2.ProblemTitle, d1p2.ProblemUrl, d1p2.InputFilePath, result.ToString());
                    break;
                default:
                    MessageBox.Show("Invalid problem selection.");
                    break;
            }
        }
    }
}
