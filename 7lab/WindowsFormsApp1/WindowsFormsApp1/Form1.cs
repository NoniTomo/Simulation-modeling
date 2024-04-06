using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        int toUrgentCalls = 0;
        double fromUrgentToCompleted = 0;
        int fromOnCallCars = 0;

        Random rnd = new Random();
        int hour = 0;

        int timeWithoutEpidemics = 1;
        double epidThreat = 0.1;
        double trust = 0.5;
        double speedReaction = 0.5;
        double qualityWork = 0.5;
        double speedWork = 0.5;
        double naturalDepopulation = 0.5;
        double survivalRate = 0.5;
        int[] durationOfInformationStorage = new int[10];

        int urgentCalls = 0;
        int completedCalls = 0;
        int carsOnCall = 0;
        int freeCars = 0;
        int newChangeValue;
        int countCar = 0;

        bool flag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            freeCars = (int)numericUpDown1.Value;
            countCar = freeCars;
            if (flag)
            {
                timer1.Stop();
                flag = false;
                button1.Text = "Начать моделирование";
                button2.Visible = false;
                anotherFlag = false;
            } else
            {
                toUrgentCalls = 0;
                fromUrgentToCompleted = 0;
                fromOnCallCars = 0;
                rnd = new Random();

                hour = 0;
                timeWithoutEpidemics = 1;
                epidThreat = 0.1;
                trust = 0.5;
                speedReaction = 0.5;
                qualityWork = 0.5;
                speedWork = 0.5;
                naturalDepopulation = 0.5;
                survivalRate = 0.5;

                durationOfInformationStorage = new int[10];

                urgentCalls = 0;
                completedCalls = 0;
                carsOnCall = 0;

                flag = true;
                chart2.Series[0].Points.Clear();
                chart3.Series[0].Points.Clear();
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                timer1.Start();
                button1.Text = "Прекратить моделирование";
                button2.Visible = true;
            }           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hour++;

            //эпидемиологическая угроза
            //*
            // Чем дольше не было эпидемий, тем выше вероятность
            // что она случится и будет сильнее
            //*
            double val = rnd.NextDouble();
            bool check = val <= (double)timeWithoutEpidemics / 100.0;
            if (check)
            {
                epidThreat = (double)(timeWithoutEpidemics) / 100.0;
                timeWithoutEpidemics = 1;

            } else timeWithoutEpidemics+=10;

            //скорость_реакции_на_обращения
            speedReaction = (double)freeCars  / ((double)countCar / 100.0) * 0.01;

            //доверие_к_скорой_помощи
            trust = qualityWork * 0.3 + speedReaction * 0.7;

            //скорость_работы
            speedWork = speedReaction * 0.7 + rnd.NextDouble() * 0.3;

            //естественная_убыль_населения
            naturalDepopulation = epidThreat * 0.5 + survivalRate * 0.5;

            //актуальные_вызовы
            double value = (trust * 0.3 + epidThreat * 0.7>= naturalDepopulation * 0.5) ? rnd.Next((int)Math.Floor(countCar * epidThreat) * 3, countCar * 3) * (trust * 0.3 + epidThreat * 0.7 - naturalDepopulation * 0.5) : 0;
            urgentCalls = (int)Math.Floor(value);
            chart2.Series[0].Points.AddXY(hour, urgentCalls);

            int changeValue = Math.Min(freeCars, urgentCalls);
            urgentCalls -= changeValue;
            freeCars -= changeValue;
            carsOnCall += changeValue;

            
            //машины_на_вызове
            newChangeValue += (int)Math.Floor(carsOnCall * speedWork);
            carsOnCall -= newChangeValue;

            freeCars += newChangeValue;
            newChangeValue = 0;
            chart1.Series[1].Points.AddXY(hour, carsOnCall);
            chart1.Series[0].Points.AddXY(hour, freeCars);

            //выполненные_вызовы
            int prevCompletedCalls = completedCalls;
            if (hour > 10)
            {
                for (int i = 0; i < durationOfInformationStorage.Length - 1; i++)
                {
                    durationOfInformationStorage[i] = durationOfInformationStorage[i + 1];
                }
                durationOfInformationStorage[durationOfInformationStorage.Length - 1] = changeValue;
                completedCalls = 0;
                foreach (int item in durationOfInformationStorage)
                {
                    completedCalls += item;
                }
            }
            else
            {
                this.durationOfInformationStorage[hour - 1] = changeValue;
                completedCalls += changeValue;
            }

            //выживаемость_больных
            survivalRate = (prevCompletedCalls != 0) ? Math.Abs((double)(prevCompletedCalls - completedCalls) / ((double)prevCompletedCalls / 100.0) * 0.01) : 0.1;

            //качество_работы
            qualityWork = (prevCompletedCalls != 0) ? Math.Abs((double)(prevCompletedCalls - completedCalls) / ((double)prevCompletedCalls / 100.0) * 0.01) : 0.1;

            chart3.Series[0].Points.AddXY(hour, completedCalls);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        bool anotherFlag = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (anotherFlag)
            {
                timer1.Start();
                anotherFlag = false;
                button2.Text = "Стоп";
            }
            else
            {
                anotherFlag = true;
                timer1.Stop();
                button2.Text = "Старт";
            }
        }
    }
}
