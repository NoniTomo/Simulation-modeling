using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string question;
        private string[] positiveAnswers;
        private string[] negativeAnswers;
        private string[] neutralAnswers;
        private List<string[]> answers;
        private List<double[]> answersProbabilities;
        private double[] probabilities = new double[3] { 0.2, 0.3, 0.5 };
        private double[] negativeAnswersProbabilities;
        private double[] positiveAnswersProbabilities;
        private double[] neutralAnswersProbabilities;
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();

            positiveAnswersProbabilities = new double[5] { 0.2, 0.3, 0.2, 0.2, 0.1 };
            negativeAnswersProbabilities = new double[5] { 0.4, 0.2, 0.1, 0.2, 0.1 };
            neutralAnswersProbabilities = new double[5] { 0.1, 0.3, 0.1, 0.3, 0.2 };

            positiveAnswers = new string[5]
            {
                "Ваше здоровье будет крепким, а дух - сильным",
                "Вы встретите интересного человека, который станет вашим другом",
                "Ваши усилия скоро принесут плоды",
                "Ожидайте приятных сюрпризов в ближайшем будущем",
                "Ваше будущее светло и полно возможностей!"
            };
            negativeAnswers = new string[5]
            {
                "Вам предстоит трудный период, но не отчаивайтесь",
                "Ваши планы могут не сбыться в ближайшем будущем",
                "Будьте осторожны, вас ждут испытания",
                "Вам придется принять трудное решение",
                "Ваше настроение может ухудшиться, но это временно"
            };
            neutralAnswers = new string[5]
            {
                "Результат будет зависеть от ваших действий",
                "Сейчас сложно сказать что-то определенное",
                "Вам стоит подождать некоторое время",
                "Ваши шансы 50 на 50",
                "Ваш вопрос требует более глубокого размышления"
            };
            answers = new List<string[]> { positiveAnswers, negativeAnswers, neutralAnswers };
            answersProbabilities = new List<double[]> { positiveAnswersProbabilities, negativeAnswersProbabilities, neutralAnswersProbabilities };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            question = textBox1.Text;

            double currentRnd = rnd.NextDouble();
            double[] borders = new double[2] { 0, 0 };

            for (int i = 0; i < probabilities.Length; i++)
            {
                double[] bordersVariant = new double[2] { 0, 0 };
                borders[0] = borders[1];
                borders[1] = borders[1] + probabilities[i];
                if (currentRnd < borders[1] && currentRnd > borders[0])
                {
                    currentRnd = rnd.NextDouble();
                    for (int j = 0; j < answers[i].Length; j++)
                    {
                        bordersVariant[0] = bordersVariant[1];
                        bordersVariant[1] = bordersVariant[1] + answersProbabilities[i][j];
                        if (currentRnd < bordersVariant[1] && currentRnd > bordersVariant[0])
                        {
                            textBox2.Text = answers[i][j];
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
