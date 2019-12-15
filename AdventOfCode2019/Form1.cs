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
            Part1ResultTextBox.Text = problem.SolvePart1().ToString();
            Part2ResultTextbox.Text = problem.SolvePart2().ToString();
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            switch (ProblemSelector.GetItemText(ProblemSelector.SelectedItem))
            {
                case "Day 1":
                    UpdateForm(new Day1());
                    break;
                case "Day 2":
                    UpdateForm(new Day2());
                    break;
                case "Day 3":
                    UpdateForm(new Day3());
                    break;
                case "Day 4":
                    UpdateForm(new Day4());
                    break;
                case "Day 5":
                    UpdateForm(new Day5());
                    break;
                case "Day 6":
                    UpdateForm(new Day6());
                    break;
                case "Day 7":
                    UpdateForm(new Day7());
                    break;
                case "Day 8":
                    UpdateForm(new Day8());
                    break;
                case "Day 9":
                    UpdateForm(new Day9());
                    break;
                default:
                    MessageBox.Show("Invalid problem selection.");
                    break;
            }
        }
    }
}
