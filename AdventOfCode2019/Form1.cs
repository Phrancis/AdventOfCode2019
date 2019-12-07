using System;
using System.Windows.Forms;

namespace AdventOfCode2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateForm(IAdventOfCodeProblem problem)
        {
            TitleTextBox.Text = problem.ProblemTitle();
            URLTextBox.Text = problem.ProblemUrl();
            InputFileTextBox.Text = problem.FileName();
            ResultTextBox.Text = problem.SolveProblem().ToString();
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            switch (ProblemSelector.GetItemText(ProblemSelector.SelectedItem))
            {
                case "Day 1 Problem 1":
                    UpdateForm(new Day1Problem1());
                    break;
                case "Day 1 Problem 2":
                    UpdateForm(new Day1Problem2());
                    break;
                case "Day 2 Problem 1":
                    UpdateForm(new Day2Problem1());
                    break;
                case "Day 2 Problem 2":
                    UpdateForm(new Day2Problem2());
                    break;
                case "Day 3 Problem 1":
                    UpdateForm(new Day3Problem1());
                    break;
                case "Day 3 Problem 2":
                    UpdateForm(new Day3Problem2());
                    break;
                case "Day 4 Problem 1":
                    UpdateForm(new Day4Problem1());
                    break;
                case "Day 4 Problem 2":
                    UpdateForm(new Day4Problem2());
                    break;
                case "Day 5 Problem 1":
                    UpdateForm(new Day5Problem1());
                    break;
                default:
                    MessageBox.Show("Invalid problem selection.");
                    break;
            }
        }
    }
}
