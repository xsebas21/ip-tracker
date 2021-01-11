using ip_tracker_library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ip_tracker_win
{
    public partial class Form1 : Form
    {
        #region Logger
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Private Members
        private static readonly Engine _engine = new Engine();
        private int _interval = 10000;
        private bool isFirstTime = true; // First run? Don't show a windows notification when the IP changes
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();

            // Engine
            _engine.IPChanged += Engine_IPChanged;
            _engine.IPChecked += Engine_IPChecked;

            // Worker
            worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
            worker.ProgressChanged += Worker_ProgressChanged;

            // Set the timer
            timer1.Interval = _interval;
            timer1.Start();
            timer1.Tick += (o, e) =>
            {
                if (!worker.IsBusy)
                {
                    worker.RunWorkerAsync();
                }
            };

        }
        #endregion

        #region Event Handlers
        private void Form1_Load(object sender, EventArgs e)
        {
            _engine.Check();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _engine.Check();
        }

        private void Engine_IPChecked(object sender, EventArgs e)
        {
            worker.ReportProgress(0, (EngineEventArgs)e);
        }

        private void Engine_IPChanged(object sender, EventArgs e)
        {
            worker.ReportProgress(0, (EngineEventArgs)e);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var engineEventArgs = (EngineEventArgs)e.UserState;
            var uiHandlers = new Dictionary<EngineEventType, Action<EngineEventArgs>>
            {
                { EngineEventType.IPChecked, HandleUIForIpChecked },
                { EngineEventType.IPChanged, HandleUIForIpChanged }
            };

            uiHandlers[engineEventArgs.EventType](engineEventArgs);
        }
        #endregion

        #region Private Methods
        private void HandleUIForIpChecked(EngineEventArgs engineEventArgs)
        {
            statusLastTime.Text = $"Last time checked: {engineEventArgs.Time}";
            statusCounter.Text = $"Times checked: {engineEventArgs.ChecksCounter}";           
        }

        private void HandleUIForIpChanged(EngineEventArgs engineEventArgs)
        {
            // Form
            this.Text = $"{engineEventArgs.IP} - Current Public IP";

            // Textbox
            var message = $"{engineEventArgs.Time} ==> {engineEventArgs.IP}";
            textBox1.Text += message + Environment.NewLine;
            textBox1.Focus();
            textBox1.Select(textBox1.Text.Length - 1, 0);

            // Windows notification
            NotifyWindows(engineEventArgs);

            //Log
            _logger.Info(message);
        }

        private void NotifyWindows(EngineEventArgs engineEventArgs)
        {
            // Info and icon settings            
            notifyIcon1.BalloonTipTitle = isFirstTime ? "Current IP: " : "IP Changed. New IP:";
            notifyIcon1.BalloonTipText = engineEventArgs.IP;
            notifyIcon1.Text = "Current IP: " + engineEventArgs.IP;
            isFirstTime = false;

            notifyIcon1.ShowBalloonTip(2000);
            //notifyIcon1.ShowBalloonTip(1000, "title", "text", ToolTipIcon.Info);
        }
        #endregion

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                notifyIcon1.Visible = false;
            }
        }
    }
}
