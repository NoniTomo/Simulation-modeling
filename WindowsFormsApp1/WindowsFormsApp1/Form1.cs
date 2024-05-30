using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int codeState;
        private Random rnd = new Random();
        private Dictionary<int, string> weather;
        private double[,] P = new double[,] { { 0.3, 0.5, 0.2 }, { 0.3, 0.6, 0.1 }, { 0.1, 0.4, 0.5 } };
        public Form1()
        {
            InitializeComponent();
            codeState = 0;
            weather = new Dictionary<int, string>
            {
                {0, "Осадки" },
                {1, "Облачно" },
                {2, "Ясно" }
            };
            var stationaryProbabilities = stationaryProbabilitiesCalc(P);
            //осадки
            label32.Text = $"{Math.Round(stationaryProbabilities[0], 4)}";
            //облачно
            label31.Text = $"{Math.Round(stationaryProbabilities[1], 4)}";
            //ясно
            label30.Text = $"{Math.Round(stationaryProbabilities[2], 4)}";

            int[] states = RunMarkovChainSimulation(P, codeState, 10000);
            //осадки
            label23.Text = $"{(double)countStatus(states, 0) / 10000.0}";
            //облачно
            label22.Text = $"{(double)countStatus(states, 1) / 10000.0}";
            //ясно
            label21.Text = $"{(double)countStatus(states, 2) / 10000.0}";
        }
        public static Vector<double> stationaryProbabilitiesCalc(double[,] transitionMatrix)
        {
            var matrixP = Matrix<double>.Build.DenseOfArray(transitionMatrix);
            var n = matrixP.RowCount;

            // Транспонируем матрицу
            var transposedP = matrixP.Transpose();

            // Создаем матрицу A = P^T - I
            var identity = Matrix<double>.Build.DenseIdentity(n);
            var A = transposedP - identity;

            // Добавляем условие нормировки: сумма вероятностей = 1
            var ones = Vector<double>.Build.Dense(n, 1.0);
            A = A.InsertRow(n, ones.ToRowMatrix().Row(0));

            // Создаем вектор b
            var b = Vector<double>.Build.Dense(n + 1);
            b[n] = 1.0;

            // Решаем систему линейных уравнений
            var pi = A.Solve(b);
            return pi;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private int countStatus(int[] states, int state)
        {
            int value = 0;
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i] == state) value++;
            }
            return value;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            int[] states = RunMarkovChainSimulation(P, codeState, 2);
            codeState = states[states.Length - 1];
            label18.Text = weather[codeState];
        }

        public int[] RunMarkovChainSimulation(double[,] P, int codeState = 0, int numIters = 2)
        {
            int numStates = P.GetLength(0);
            int[] states = new int[numIters];

            states[0] = codeState; 

            for (int t = 1; t < numIters; t++)
            {
                int currentState = states[t - 1];
                double[] probabilities = new double[numStates];
                for (int j = 0; j < numStates; j++)
                {
                    probabilities[j] = P[currentState, j];
                }

                states[t] = SampleFromMultinomial(probabilities);
            }

            return states;
        }

        private int SampleFromMultinomial(double[] probabilities)
        {
            double cumulative = 0.0;
            double r = rnd.NextDouble();

            for (int i = 0; i < probabilities.Length; i++)
            {
                cumulative += probabilities[i];
                if (r < cumulative)
                {
                    label10.Text = $"{probabilities[i]}";
                    return i;
                }
            }
            return probabilities.Length - 1;
        }
    }
}
