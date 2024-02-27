using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int cells = 2;
        int[,] colorsArray;
        int rows = 1;
        bool flag = true;
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            ClientSize = new Size(750, 600);
            MouseDown += paint;
            colorsArray = new int[(ClientSize.Width - 150) / cells, ClientSize.Height / cells];
            DoubleBuffered = true;

        }
        private void paint(object sender, MouseEventArgs e)
        {
            var thisX = e.X;
            colorsArray[0, thisX / cells] = colorsArray[0, thisX / cells] == 1 ? 0 : 1;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            InitCells(e.Graphics);
            if(cells > 2) InitGrid(e.Graphics);
        }
        protected void InitGrid(Graphics g)
        {
            for (int i = 0; i <= rows; i++)
            {
                g.DrawLine(new Pen(Color.Black, 1), new Point(0, cells * i), new Point(ClientSize.Width - 150, cells * i));
            }
            for (int i = 0; i <= (ClientSize.Width - 150) / cells; i++)
            {
                g.DrawLine(new Pen(Color.Black, 1), new Point(cells * i, 0), new Point(cells * i, cells * rows));
            }
        }
        protected void InitCells(Graphics g)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < (ClientSize.Width - 150) / cells; j++)
                {
                    if (colorsArray[i, j] == 1)
                    {
                        g.FillRectangle(Brushes.Black, cells * j, cells * i, cells, cells);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, cells * j, cells * i, cells, cells);
                    }
                }
            }
        }
        private void Clear()
        {
            colorsArray = new int[(ClientSize.Width - 150) / cells, ClientSize.Height / cells];
            rows = 1;
            Invalidate();
        }
        private void Display()
        {
            string binvalue = Convert.ToString((int)rule.Value, 2);
            if (binvalue.Length < 8)
            {
                binvalue = binvalue.PadLeft(8, '0'); 
            }
            
            rows = ClientSize.Height / cells;
            for (int i = 1; i < rows; i++)
            {
                for (int j = 0; j < (ClientSize.Width - 150) / cells; j++)
                {
                    var l = (j - 1 + (ClientSize.Width - 150) / cells) % ((ClientSize.Width - 150) / cells);
                    var r = (j + 1) % ((ClientSize.Width - 150) / cells);

                    string[] variation = new string[] { "111", "110", "101", "100", "011", "010", "001", "000" };

                    for (int k = 0; k < variation.Length; k++)
                    {
                        if (colorsArray[i - 1, l].ToString() + colorsArray[i - 1, j].ToString() + colorsArray[i - 1, r].ToString() == variation[k])
                        {
                            colorsArray[i, j] = int.Parse(binvalue[k].ToString());
                            break;
                        }
                    }
                }
            }
            Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                Display();
                button1.Text = "CLEAR";
            }
            else
            {
                Clear();
                flag = true;
                button1.Text = "DISPLAY";
            }
        }
    }
}