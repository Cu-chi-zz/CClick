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

namespace CClick
{
    public partial class Form1 : Form
    {
        private bool running = false;
        private int clickCounter = 0;
        private Stopwatch watcher = new Stopwatch();

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
                    if (comboBox.SelectedIndex == 0)
                    {
                        if (clickCounter < 10)
                        {
                            clickCounter++;
                            label1.Text = $"{clickCounter}";
                            if (clickCounter == 10)
                            {
                                richTextBox1.Text += Math.Round(EndTest().TotalSeconds, 3).ToString() + "s\n";
                            }
                        }
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
        }

        private TimeSpan EndTest()
        {
            watcher.Stop();
            clickableButton.Text = "START";
            running = false;
            return watcher.Elapsed;
        }
    }
}