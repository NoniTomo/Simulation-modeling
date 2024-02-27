using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        int cells = 8;
        int[,] colorsArray;
        int rows = 600 / 8;
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
            var thisY = e.Y;
            colorsArray[thisY / cells, thisX / cells] = colorsArray[thisY / cells, thisX / cells] == 1 ? 0 : 1;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            InitCells(e.Graphics);
            InitGrid(e.Graphics);
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
            rows = ClientSize.Height / cells;
            Invalidate();
        }
        private void Display()
        {
            int[,] newColorsArray = new int[colorsArray.GetLength(0), colorsArray.GetLength(1)];

            for (int i = 0; i < colorsArray.GetLength(0); i++)
            {
                for (int j = 0; j < colorsArray.GetLength(1); j++)
                {
                    int liveNeighbors = CountLiveNeighbors(i, j);

                    if (colorsArray[i, j] == 1)
                    {
                        if (liveNeighbors < 2 || liveNeighbors > 3)
                        {
                            newColorsArray[i, j] = 0; 
                        }
                        else
                        {
                            newColorsArray[i, j] = 1; 
                        }
                    }
                    else
                    {
                        if (liveNeighbors == 3)
                        {
                            newColorsArray[i, j] = 1; 
                        }
                        else
                        {
                            newColorsArray[i, j] = 0; 
                        }
                    }
                }
            }
            colorsArray = newColorsArray;
            Invalidate();
        }
        private int CountLiveNeighbors(int x, int y)
        {
            int count = 0;

            int _rows = colorsArray.GetLength(0);
            int _cols = colorsArray.GetLength(1);

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y)
                        continue;

                    int neighborX = (i + _rows) % _rows;
                    int neighborY = (j + _cols) % _cols;

                    if (colorsArray[neighborX, neighborY] == 1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                timer1.Start();
                button1.Text = "CLEAR";
            }
        
            else
            {
                Clear();
                timer1.Stop();
                flag = true;
                button1.Text = "DISPLAY";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Display();
        }
    }
}
