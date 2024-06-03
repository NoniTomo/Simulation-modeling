using System;
using System.Collections;
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
        private int timeBeforeNextClient;
        public static Random random = new Random();

        private EventQueue _eventQueue;

        public Form1()
        {
            InitializeComponent();
        }

        public void richTextBoxAdd(string data)
        {
            richTextBox1.AppendText(data);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeBeforeNextClient == 0)
            {
                _eventQueue.AddClient();
                timeBeforeNextClient = random.Next(2, 5);
            }
            timeBeforeNextClient--;
            _eventQueue.Iteration();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label[] labels = { label4, label5, label6 };
            _eventQueue = new EventQueue(this, labels, label8);
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }

    class Client
    {
        public int Id { get; private set; }

        public Client(int id)
        {
            Id = id;
        }

        public string GetQueueMessage(int queueNum)
        {
            return $"Клиент {Id + 1} встал в очередь под номером {queueNum}\n";
        }
    }

    class Worker
    {
        public int Id { get; private set; }
        public int Timer { get; private set; }
        private Client currentClient;
        private Label label;

        public Worker(int id, Label label)
        {
            Id = id;
            this.label = label;
        }

        public void SetClient(Client client)
        {
            Timer = Form1.random.Next(5, 15);
            currentClient = client;
            label.Text = $"Клиент {client.Id + 1}";
        }

        public void DecreaseTimer()
        {
            if (Timer > 0)
            {
                Timer--;
            }
        }

        public bool IsFree => Timer == 0;

        public string GetCurrentClientMessage()
        {
            return $"Клиент {currentClient.Id + 1} на обслуживании у работника {Id}\n";
        }
    }

    class EventQueue
    {
        private Worker[] workers;
        private Queue<Client> clientQueue;
        private int clientIdCounter;
        private Form1 form;
        private Label labelQueueLength;

        public EventQueue(Form1 form, Label[] labels, Label labelQueueLength)
        {
            this.form = form;
            this.labelQueueLength = labelQueueLength;
            workers = new Worker[3];
            clientQueue = new Queue<Client>();
            clientIdCounter = 0;
            for (int i = 0; i < 3; i++)
            {
                workers[i] = new Worker(i + 1, labels[i]);
            }
        }

        public void Iteration()
        {
            foreach (var worker in workers)
            {
                if (worker.IsFree && clientQueue.Count > 0)
                {
                    var client = clientQueue.Dequeue();
                    worker.SetClient(client);
                    form.richTextBoxAdd(worker.GetCurrentClientMessage());
                }
                worker.DecreaseTimer();
            }
            labelQueueLength.Text = $"{clientQueue.Count}";
        }

        public void AddClient()
        {
            var client = new Client(clientIdCounter++);
            bool assigned = false;

            foreach (var worker in workers)
            {
                if (worker.IsFree && clientQueue.Count == 0)
                {
                    worker.SetClient(client);
                    form.richTextBoxAdd(worker.GetCurrentClientMessage());
                    assigned = true;
                    break;
                }
            }

            if (!assigned)
            {
                clientQueue.Enqueue(client);
                form.richTextBoxAdd(client.GetQueueMessage(clientQueue.Count));
            }
        }
    }
}