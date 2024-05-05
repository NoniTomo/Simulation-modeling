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
        private Dictionary<int, double> probabilities;
        private int[] counts;
        private double generalProbability = 0;
        private Random rnd = new Random();
        double mathExp;
        double mathVar;
        double ksi;
        double empMathVar;
        double empMathExp;
        double empMathVarError;
        double empMathExpError;
        public Form1()
        {
            InitializeComponent();
            mathExp = 0;
            mathVar = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numOfExperiments = (int)numericUpDown7.Value;

            counts = new int[6];
            generalProbability = 0;
            chart1.Series[0].Points.Clear();

            probabilities = new Dictionary<int, double>
            {
                { 1, (double)numericUpDown1.Value },
                { 2, (double)numericUpDown2.Value },
                { 3, (double)numericUpDown3.Value },
                { 4, (double)numericUpDown4.Value },
                { 5, (double)numericUpDown5.Value },
                { 6, 1 }
            };

            for (int i = 1; i < 6; i++) generalProbability += probabilities[i];

            if (generalProbability > 1)
            {
                MessageBox.Show("Сумма вероятностей > 1. Измените входные данные.");
                return;
            }
            probabilities[6] = 1 - generalProbability;
            numericUpDown6.Value = (decimal)probabilities[6];
            resultGenerate();
            visualisation();
        }
        private void resultGenerate()
        {
            for (int i = 0; i < numOfExperiments; i++)
            {
                double currentRnd = rnd.NextDouble();
                int x = eval(currentRnd);
                counts[x - 1]++;
            }
        }
        private int eval(double currentRnd)
        {
            double prob = 0;
            int i = 1;
            while (prob >= 0)  
            {
                prob += probabilities[i++];
                if(currentRnd <= prob) break;
            }
            return i - 1;
        }
        private void visualisation()
        {
            empMathExp = 0;
            empMathVar = 0;
            ksi = 0;
            mathExp = 0;
            mathVar = 0;
            for (int i = 0; i < 6; i++)
            {
                double p = (double)counts[i] / numOfExperiments;
                empMathExp += (i + 1) * p;
                empMathVar += Math.Pow(i + 1, 2) * p;
            }
            empMathVar -= Math.Pow(empMathExp, 2);

            for (int i = 0; i < 6; i++)
            {
                double p = (double)probabilities[i + 1];
                mathExp += (i + 1) * p;
                mathVar += Math.Pow(i + 1, 2) * p;
            }
            mathVar -= Math.Pow(mathExp, 2);
         
            for (int i = 0; i < 6; i++)
            {
                double p = (double)probabilities[i + 1];
                ksi += Math.Pow(counts[i], 2) / (numOfExperiments * p);
            }
            ksi -= numOfExperiments;

            numericUpDown13.Value = (decimal)ksi;
            label12.Text = (ksi < 11.070) ? "is true" : "is false";
            for (int i = 0; i < 6; i++)
            {
                float value = (float)counts[i] / (float)numOfExperiments;
                chart1.Series[0].Points.AddXY(i + 1, value);
            }
            empMathExpError = Math.Abs(empMathExp - mathExp) / Math.Abs(mathExp);
            empMathVarError = Math.Abs(empMathVar - mathVar) / Math.Abs(mathVar);
            numericUpDown8.Value = (decimal)mathExp;
            numericUpDown10.Value = (decimal)Math.Round(empMathExpError, 3);
            numericUpDown9.Value = (decimal)mathVar;
            numericUpDown11.Value = (decimal)Math.Round(empMathVarError, 3);
        }
    }
}
