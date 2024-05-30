using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();
        const double μ = 0.0005;
        const double σ = 0.01;
        const int t = 1;
        double rateEuro, rateDollar, day;
        double butFlag = 0;

        private void btPredict_Click_1(object sender, EventArgs e)
        {
            rateEuro = (double)edEuroRate.Value;
            rateDollar = (double)edDollarRate.Value;
            day = 0;

            if (butFlag == 0)
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY(day, rateEuro);
                chart1.Series[1].Points.Clear();
                chart1.Series[1].Points.AddXY(day, rateDollar);

                butFlag = 1;
                btPredict.Text = "STOP";

                timer1.Start();
            }
            else
            {
                timer1.Stop();
                btPredict.Text = "RESTART";
                butFlag = 0;
            }
        }
        private double normalValueGeneration()
        {
            int n = 12;
            double rv = 0;
            for (int j = 0; j < n; j++)
            {
                rv += random.NextDouble();
            }
            return eval(rv - 6);
        }
        private double eval(double rv)
        {
            return rv + (1 / 240.0) * (Math.Pow(rv, 3) - 3 * rv);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            day += 1;
            rateEuro = rateEuro * Math.Exp((μ - (Math.Pow(σ, 2) / 2)) * 1 + σ * Math.Sqrt(1) * normalValueGeneration());
            rateDollar = rateDollar * Math.Exp((μ - (Math.Pow(σ, 2) / 2)) * 1 + σ * Math.Sqrt(1) * normalValueGeneration());
            chart1.Series[0].Points.AddXY(day, rateEuro);
            chart1.Series[1].Points.AddXY(day, rateDollar);
        }
    }
}
