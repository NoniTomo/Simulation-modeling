using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int numOfExperiments;
        private double[] probabilities;
        private int[] counts;
        private double generalProbability = 0;
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numOfExperiments = (int)numericUpDown7.Value;

            counts = new int[6];
            generalProbability = 0;
            chart1.Series[0].Points.Clear();

            probabilities = new double[6]
            {
                (double)numericUpDown1.Value,
                (double)numericUpDown2.Value,
                (double)numericUpDown3.Value,
                (double)numericUpDown4.Value,
                (double)numericUpDown5.Value,
                1
            };

            for (int i = 0; i < 5; i++) generalProbability += probabilities[i];

            if (generalProbability > 1)
            {
                MessageBox.Show("Сумма вероятностей > 1. Измените входные данные.");
                return;
            }
            probabilities[5] = 1 - generalProbability;
            numericUpDown6.Value = (decimal)probabilities[5];
            resultGenerate();
            visualisation();
        }
        private void resultGenerate()
        {
            for (int i = 0; i < numOfExperiments; i++)
            {
                double currentRnd = rnd.NextDouble();
                counts[eval(currentRnd)]++;
            }
        }
        private int eval(double currentRnd)
        {
            double prob = 0;
            int i = 0;
            while (prob >= 0)  
            {
                if(currentRnd <= prob) break;
                prob += probabilities[i++];
            }
            return i - 1;
        }
        private void visualisation()
        {
            for (int i = 0; i < 6; i++)
            {
                float value = (float)counts[i] / (float)numOfExperiments;
                chart1.Series[0].Points.AddXY(i + 1, value);
            }
        }
    }
}
