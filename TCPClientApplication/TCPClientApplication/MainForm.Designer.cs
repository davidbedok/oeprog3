namespace TCPClientApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bTest = new System.Windows.Forms.Button();
            this.lbEventDiary = new System.Windows.Forms.ListBox();
            this.bKill = new System.Windows.Forms.Button();
            this.bWorkThread = new System.Windows.Forms.Button();
            this.bWorkNoThread = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.bSimulator = new System.Windows.Forms.Button();
            this.timerSimulator = new System.Windows.Forms.Timer(this.components);
            this.timerSimulatorBegin = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bTest
            // 
            this.bTest.Location = new System.Drawing.Point(7, 41);
            this.bTest.Name = "bTest";
            this.bTest.Size = new System.Drawing.Size(167, 23);
            this.bTest.TabIndex = 0;
            this.bTest.Text = "Test Operation";
            this.bTest.UseVisualStyleBackColor = true;
            this.bTest.Visible = false;
            this.bTest.Click += new System.EventHandler(this.bTest_Click);
            // 
            // lbEventDiary
            // 
            this.lbEventDiary.FormattingEnabled = true;
            this.lbEventDiary.Location = new System.Drawing.Point(180, 12);
            this.lbEventDiary.Name = "lbEventDiary";
            this.lbEventDiary.Size = new System.Drawing.Size(263, 173);
            this.lbEventDiary.TabIndex = 5;
            // 
            // bKill
            // 
            this.bKill.Location = new System.Drawing.Point(7, 128);
            this.bKill.Name = "bKill";
            this.bKill.Size = new System.Drawing.Size(167, 23);
            this.bKill.TabIndex = 6;
            this.bKill.Text = "Kill Server";
            this.bKill.UseVisualStyleBackColor = true;
            this.bKill.Click += new System.EventHandler(this.bKill_Click);
            // 
            // bWorkThread
            // 
            this.bWorkThread.Location = new System.Drawing.Point(7, 70);
            this.bWorkThread.Name = "bWorkThread";
            this.bWorkThread.Size = new System.Drawing.Size(167, 23);
            this.bWorkThread.TabIndex = 7;
            this.bWorkThread.Text = "Work In Thread";
            this.bWorkThread.UseVisualStyleBackColor = true;
            this.bWorkThread.Visible = false;
            this.bWorkThread.Click += new System.EventHandler(this.bWork_Click);
            // 
            // bWorkNoThread
            // 
            this.bWorkNoThread.Location = new System.Drawing.Point(7, 99);
            this.bWorkNoThread.Name = "bWorkNoThread";
            this.bWorkNoThread.Size = new System.Drawing.Size(167, 23);
            this.bWorkNoThread.TabIndex = 8;
            this.bWorkNoThread.Text = "Work Operation";
            this.bWorkNoThread.UseVisualStyleBackColor = true;
            this.bWorkNoThread.Visible = false;
            this.bWorkNoThread.Click += new System.EventHandler(this.bWorkNoThread_Click);
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(7, 157);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(167, 23);
            this.bExit.TabIndex = 9;
            this.bExit.Text = "Exit Client";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bSimulator
            // 
            this.bSimulator.Location = new System.Drawing.Point(7, 12);
            this.bSimulator.Name = "bSimulator";
            this.bSimulator.Size = new System.Drawing.Size(167, 23);
            this.bSimulator.TabIndex = 10;
            this.bSimulator.Text = "Simulation";
            this.bSimulator.UseVisualStyleBackColor = true;
            this.bSimulator.Click += new System.EventHandler(this.bSimulator_Click);
            // 
            // timerSimulator
            // 
            this.timerSimulator.Interval = 1000;
            this.timerSimulator.Tick += new System.EventHandler(this.timerSimulator_Tick);
            // 
            // timerSimulatorBegin
            // 
            this.timerSimulatorBegin.Interval = 1000;
            this.timerSimulatorBegin.Tick += new System.EventHandler(this.timerSimulatorBegin_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 192);
            this.Controls.Add(this.bSimulator);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bWorkNoThread);
            this.Controls.Add(this.bWorkThread);
            this.Controls.Add(this.bKill);
            this.Controls.Add(this.lbEventDiary);
            this.Controls.Add(this.bTest);
            this.Name = "MainForm";
            this.Text = "TCP Client Application";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bTest;
        private System.Windows.Forms.ListBox lbEventDiary;
        private System.Windows.Forms.Button bKill;
        private System.Windows.Forms.Button bWorkThread;
        private System.Windows.Forms.Button bWorkNoThread;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bSimulator;
        private System.Windows.Forms.Timer timerSimulator;
        private System.Windows.Forms.Timer timerSimulatorBegin;
    }
}

