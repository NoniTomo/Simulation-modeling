using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void edRate_ValueChanged(object sender, EventArgs e)
        {

        }

        const double k = 0.05;
        double rateEuro, rateDollar, day;
        double butFlag = 0;

        Random random = new Random();

        private void btPredict_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            day += 1;
            rateEuro = rateEuro * (1 + k * (random.NextDouble() - 0.5));
            rateDollar = rateDollar * (1 + (k + 0.05) * (random.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(day, rateEuro);
            chart1.Series[1].Points.AddXY(day, rateDollar);
        }
    }
}
