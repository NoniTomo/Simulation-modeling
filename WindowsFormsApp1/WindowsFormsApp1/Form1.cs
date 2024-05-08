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
        private int numOfTeam = 6;
        private int [,] team;
        private int[] counts;
        private double generalProbability = 0;
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            team = new int[numOfTeam, 8];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //numOfExperiments = (int)numericUpDown7.Value;
            dataGridView3.Rows.Clear();
            resultGenerate();
            visualisation();
        }
        private void resultGenerate()
        {
            for (int i = 0; i < numOfTeam; i++)
            {
                team[i, 0] = i + 1;
                for (int j = i + 1; j < numOfTeam; j++)
                {
                    if(i == j) { continue; }
                    else
                    {
                        double currentRnd = rnd.NextDouble() * 10 / 2;
                        int count_i = eval(currentRnd);
                        int count_j = eval(currentRnd);
                        team[i, 6] += count_i;
                        team[i, 7] += count_j;
                        team[j, 6] += count_j;
                        team[j, 7] += count_i;
                        if (count_i == count_j)
                        {
                            team[i, 3]++;
                            team[j, 3]++;
                            team[i, 5]++;
                            team[j, 5]++;
                        }
                        else
                        {
                            if (count_i > count_j)
                            {
                                team[i, 2] ++;
                                team[i, 5] += 3;
                                team[j, 4] ++;
                            }
                            else
                            {
                                team[j, 2]++;
                                team[j, 5] += 3;
                                team[i, 4]++;
                            }
                        }
                    }
                }
                team[i, 1] = team[i, 3] + team[i, 4] + team[i, 2];
            }
        }
        private int eval(double lambda)
        {
            int i = 0;
            double S = 0;
            Console.WriteLine(-lambda);
            do
            {
                double a = rnd.NextDouble();
                S += Math.Log(a);
                i++;
                Console.WriteLine(S);
            } while (S >= -lambda);
            Console.WriteLine(i);
            return i - 1;
        }
        private void visualisation()
        {
            for (int i = 0; i < 5; i++)
            {
                dataGridView3.Rows.Add(team[i, 0], team[i, 1], team[i, 2], team[i, 3], team[i, 4], team[i, 5], team[i, 6], team[i, 7]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            team = new int[numOfTeam, 8];
        }
    }
}
