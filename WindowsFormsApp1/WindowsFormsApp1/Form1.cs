using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;
using static System.Windows.Forms.LinkLabel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int numOfExperiments;
        private double[] rundomVar;
        private double gap;
        private int[] counts;
        int k = 15;

        private double generalProbability = 0;
        private Random rnd = new Random();
        double mathExp;
        double mathVar;
        double ksi;
        double empMathVar;
        double empMathExp;
        double empMathVarError;
        double empMathExpError;
        double maxValue;
        double minValue;

        double mathExpUser;
        double mathVarUser;
        public Form1()
        {
            InitializeComponent();
            mathExp = 0;
            mathVar = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numOfExperiments = (int)numericUpDown7.Value;
            rundomVar = new double[numOfExperiments];
            mathVarUser = (double)numericUpDown1.Value;
            mathExpUser = (double)numericUpDown2.Value;

            counts = new int[k];
            chart1.Series[0].Points.Clear();

            listGenerate();
            gridGenerate();
            chi();
            visualisation();
        }
        private void gridGenerate() {
            maxValue = rundomVar.Max();
            minValue = rundomVar.Min();
            double sub = maxValue - minValue + 0.01;
            gap = sub / k;
            for (int i = 0; i < rundomVar.Length; i++)
            {
                int j = 0;
                do
                {
                    j++;
                } while (minValue + j * gap <= rundomVar[i]);
                counts[j - 1]++;
            }
        }
        private void listGenerate()
        {
            for (int i = 0; i < numOfExperiments; i++)
            {
                int n = 12;
                double rv = 0;
                for (int j = 0; j < n; j++)
                {
                    rv += rnd.NextDouble();
                }
                rv = rv - 6;
                double x = eval(rv);
                x = mathExpUser + Math.Sqrt(mathVarUser) * x;
                rundomVar[i] = x;
            }
        }
        private double eval(double rv)
        {
            return rv + (1 / 240.0) * (Math.Pow(rv, 3) - 3 * rv);
        }
        private void chi()
        {
            var distribution = new Normal(mathExpUser, Math.Sqrt(mathVarUser));
            ksi = 0;
            for (int i = 0; i < k; i++)
            {
                double a = minValue + i * gap;
                double b = a + gap;

                //функция плоности вер-ти 
                double probabilityA = distribution.CumulativeDistribution(a);
                double probabilityB = distribution.CumulativeDistribution(b);

                // Вероятность интервала - разность между значениями PDF в верхнем и нижнем пределах интервала
                double intervalProbability = probabilityB - probabilityA;
                ksi += (counts[i] * counts[i]) / (numOfExperiments * intervalProbability);

            }
            ksi -= numOfExperiments;
        }
        private void visualisation()
        {
            empMathExp = 0;
            empMathVar = 0;
            for (int i = 0; i < rundomVar.Length; i++)
            {
                empMathExp = rundomVar.Average();
                empMathVar = rundomVar.Variance();
            }
            empMathExpError = Math.Abs(empMathExp - mathExpUser);
            empMathVarError = Math.Abs(empMathVar - mathVarUser);
            empMathExpError = empMathExpError / mathExpUser * 100;
            empMathVarError = empMathVarError / mathVarUser * 100;

            numericUpDown13.Value = (decimal)ksi;
            Console.WriteLine(ksi);
            label12.Text = (ksi < 24.996) ? "is true" : "is false";
            for (int i = 0; i < k; i++)
            {
                float value = (float)counts[i] / (float)numOfExperiments;
                chart1.Series[0].Points.AddXY(i + 1, value);
            }

            numericUpDown8.Value = (decimal)empMathExp;
            numericUpDown10.Value = (decimal)Math.Round(empMathExpError, 3);
            numericUpDown9.Value = (decimal)empMathVar;
            numericUpDown11.Value = (decimal)Math.Round(empMathVarError, 3);
        }
    }
}
