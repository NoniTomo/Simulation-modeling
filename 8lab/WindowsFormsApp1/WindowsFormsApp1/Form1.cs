using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> pastAnswers = new Dictionary<string, string>();
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string question = textBox1.Text;
            double p = (double)numericUpDown1.Value;
            question = question.ToLower();
            question = Regex.Replace(question, "\\p{P}", string.Empty); //удаляет все &?/!& и т.д.
            question = Regex.Replace(question, " ", string.Empty);

            if (pastAnswers.ContainsKey(question))
            {
                textBox2.Text = pastAnswers[question];
            }
            else
            {
                if (rnd.NextDouble() < p)
                {
                    textBox2.Text = "Да";
                }
                else
                {
                    textBox2.Text = "Нет";
                }
                pastAnswers[question] = textBox2.Text;
            }

        }
    }
    
}
