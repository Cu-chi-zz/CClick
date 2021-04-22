using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Timers;

namespace CClick
{
    public partial class Form1 : Form
    {
        private static bool running = false;
        private static int clickCounter = 0;
        private static Stopwatch watcher = new Stopwatch();
        private static BackgroundWorker worker = new BackgroundWorker();
        private static System.Timers.Timer timer;
        private static double ElapsedS = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void clickableButton_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                if (comboBox.SelectedIndex != -1)
                    SetupOnNewRun();
                else
                    MessageBox.Show("Please, select a test!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (comboBox.SelectedIndex != -1)
                {
                    if (comboBox.SelectedIndex == 0) // 10 Clicks
                    {
                        if (clickCounter < 10)
                        {
                            clickCounter++;
                            if (clickCounter == 10)
                            {
                                richTextBox1.Text += Math.Round(EndTest().TotalSeconds, 3).ToString() + "s\n";
                                MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (comboBox.SelectedIndex == 1) // 100 clicks
                    {
                        if (clickCounter < 100)
                        {
                            clickCounter++;
                            if (clickCounter == 100)
                            {
                                richTextBox1.Text += Math.Round(EndTest().TotalSeconds, 3).ToString() + "s\n";
                                MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (comboBox.SelectedIndex == 2) // 10 seconds
                    {
                        clickCounter++;
                    }
                }
                else
                {
                    MessageBox.Show("Please, select a test!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SetupOnNewRun()
        {
            clickableButton.Text = "CLICK";
            clickCounter = 0;
            running = true;
            watcher.Reset();
            watcher.Start();
            timer = new System.Timers.Timer();
            timer.Interval = 100;
            timer.Elapsed += Timer;
            timer.Elapsed += ForTestUsingTimer;
            timer.Enabled = true;
        }

        private TimeSpan EndTest()
        {
            watcher.Stop();
            clickableButton.Text = "START";
            running = false;
            timer.Enabled = false;
            timer.Stop();
            timer.Dispose();
            return watcher.Elapsed;
        }

        private void Timer(object source, ElapsedEventArgs e)
        {
            ElapsedS += 0.1;
            ElapsedS = Math.Round(ElapsedS, 1);
            label1.Invoke(new Action(() => label1.Text = ElapsedS.ToString() + "s"));
            label1.Invoke(new Action(() => label1.Refresh()));
        }

        private void ForTestUsingTimer(object source, ElapsedEventArgs e)
        {
            if (comboBox.SelectedIndex == 2)
            {
                if (ElapsedS >= 10)
                {
                    EndTest();
                    richTextBox1.Invoke(new Action(() => richTextBox1.Text += "clicked:" + clickCounter.ToString() + " times"));
                    MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}