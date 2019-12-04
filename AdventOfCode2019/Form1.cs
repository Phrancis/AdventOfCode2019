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
            string result;
            switch (ProblemSelector.GetItemText(ProblemSelector.SelectedItem))
            {
                case "Day 1 Problem 1":
                    Day1Problem1 d1p1 = new Day1Problem1();
                    result = d1p1.SolveProblem().ToString();
                    UpdateForm(d1p1.ProblemTitle, d1p1.ProblemUrl, d1p1.FileName, result);
                    break;
                case "Day 1 Problem 2":
                    Day1Problem2 d1p2 = new Day1Problem2();
                    result = d1p2.SolveProblem().ToString();
                    UpdateForm(d1p2.ProblemTitle, d1p2.ProblemUrl, d1p2.FileName, result);
                    break;
                case "Day 2 Problem 1":
                    Day2Problem1 d2p1 = new Day2Problem1();
                    result = d2p1.SolveProblem().ToString();
                    UpdateForm(d2p1.ProblemTitle, d2p1.ProblemUrl, d2p1.FileName, result);
                    break;
                case "Day 2 Problem 2":
                    Day2Problem2 d2p2 = new Day2Problem2();
                    result = d2p2.SolveProblem().ToString();
                    UpdateForm(d2p2.ProblemTitle, d2p2.ProblemUrl, d2p2.FileName, result);
                    break;
                default:
                    MessageBox.Show("Invalid problem selection.");
                    break;
            }
        }
    }
}
