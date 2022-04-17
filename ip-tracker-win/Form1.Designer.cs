
namespace ip_tracker_win
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.outputTextbox = new System.Windows.Forms.TextBox();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.checkTimer = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusUpdated = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusInterval = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.outputTextbox.AcceptsReturn = true;
            this.outputTextbox.AcceptsTab = true;
            this.outputTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outputTextbox.Location = new System.Drawing.Point(0, 0);
            this.outputTextbox.Multiline = true;
            this.outputTextbox.Name = "textBox1";
            this.outputTextbox.ReadOnly = true;
            this.outputTextbox.Size = new System.Drawing.Size(800, 450);
            this.outputTextbox.TabIndex = 1;
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            // 
            // timer1
            // 
            this.checkTimer.Tick += new System.EventHandler(this.checkTimer_Tick);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusUpdated,
            this.statusCounter,
            this.statusInterval});
            this.statusBar.Location = new System.Drawing.Point(0, 428);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(800, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStripLastTime";
            // 
            // statusLastTime
            // 
            this.statusUpdated.Name = "statusLastTime";
            this.statusUpdated.Size = new System.Drawing.Size(85, 17);
            this.statusUpdated.Text = "statusLastTime";
            // 
            // statusCounter
            // 
            this.statusCounter.Name = "statusCounter";
            this.statusCounter.Size = new System.Drawing.Size(81, 17);
            this.statusCounter.Text = "statusCounter";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // statusInterval
            // 
            this.statusInterval.Name = "statusInterval";
            this.statusInterval.Size = new System.Drawing.Size(77, 17);
            this.statusInterval.Text = "statusInterval";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.outputTextbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox outputTextbox;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.Timer checkTimer;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusUpdated;
        private System.Windows.Forms.ToolStripStatusLabel statusCounter;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripStatusLabel statusInterval;
    }
}

