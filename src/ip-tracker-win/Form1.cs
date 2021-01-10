using ip_tracker_library;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ip_tracker_win
{
    public partial class Form1 : Form
    {
        private static readonly Engine engine = new Engine();
        private int interval = 5000;

        public Form1()
        {
            InitializeComponent();

            // Engine
            engine.IPChanged += Engine_IPChanged;
            engine.IPChecked += Engine_IPChecked;

            // Worker
            worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
            worker.ProgressChanged += Worker_ProgressChanged;

            // Set the timer
            timer1.Interval = interval;
            timer1.Start();
            timer1.Tick += (o, e) =>
            {
                if (!worker.IsBusy)
                {
                    worker.RunWorkerAsync();
                }
            };

        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var data = (ProgressChangedData)e.UserState;
            var args = (EngineEventArgs)data.EngineEventArgs;

            if (data.EventType == "IPChecked")
            {
                statusLastTime.Text = $"Last time checked: {args.Time}";
                statusCounter.Text = $"Times checked: {args.ChecksCounter}";
            }

            if (data.EventType == "IPChanged")
            {
                var message = $"{args.Time}: {args.IP}{Environment.NewLine}";
                textBox1.Text += message;
                textBox1.Focus();
                textBox1.Select(textBox1.Text.Length - 1, 0);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            engine.Check();
        }

        private void Engine_IPChecked(object sender, EventArgs e)
        {
            var data = new ProgressChangedData
            {
                EventType = "IPChecked",
                EngineEventArgs = (EngineEventArgs)e
            };

            worker.ReportProgress(0, data);
        }

        private void Engine_IPChanged(object sender, EventArgs e)
        {
            var data = new ProgressChangedData
            {
                EventType = "IPChanged",
                EngineEventArgs = (EngineEventArgs)e
            };

            worker.ReportProgress(0, data);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine.Check();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }
    }
}
