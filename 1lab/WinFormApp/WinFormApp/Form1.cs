using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void edAngle_ValueChanged(object sender, EventArgs e)
        {

        }

        const double C = 0.15;
        const double rho = 1.29;
        const double g = 9.81;
        double height, angle, speed, S, m, dt;
        double cosa, sina, beta, k;

        double t, x, y, vx, vy;
        double x_max, x_old, y_max, y_old;

        private void btStart_Click(object sender, EventArgs e)
        {
            dt = (double)edStep.Value;
            height = (double)edHeight.Value;
            speed = (double)edSpeed.Value;
            angle = (double)edAngle.Value;
            S = (double)edSize.Value;
            m = (double)edWeight.Value;
            x_max = 0;
            y_max = 0;

            cosa = Math.Cos(angle * Math.PI / 180);
            sina = Math.Sin(angle * Math.PI / 180);

            beta = 0.5 * C * S * rho;
            k = beta / m;

            t = 0; 
            x = 0; 
            y = height;
            vx = speed * cosa;
            vy = speed * sina;

            //chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(x, y);

            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double vx_old = vx;
            double vy_old = vy;
            double root = Math.Sqrt(vx * vx + vy * vy);
            t = t + dt;

            vx = vx_old - k * vx_old * root * dt;
            vy = vy_old - (g + k * vy_old * root) * dt;

            x = x + vx * dt;
            y = y + vy * dt;

            if (x > x_max) x_max = x;
            if (y > y_max) y_max = y;

            chart1.Series[0].Points.AddXY(x, y);

            if (y <= 0)
            {
                edMaxX.Value = (decimal)(x_old + (y_old * (x_max - x_old) / (y_old - y)));
                edMaxY.Value = (decimal)y_max;
                edEndV.Value = (decimal)(Math.Sqrt(vx * vx + vy * vy));
                
                timer1.Stop();
            }
            y_old = y;
            x_old = x_max;
        }

    }
}
