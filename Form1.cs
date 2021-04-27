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
using Octokit;

namespace CClick
{
    public partial class Form1 : Form
    {
        private static bool running = false;
        private static int clickCounter = 0;
        private static Stopwatch watcher = new Stopwatch();
        private static System.Timers.Timer timer;
        private static string version = "1.0.5";

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("CClick"));
                var releases = await client.Repository.Release.GetAll("Cu-chi", "CClick");

                try
                {
                    var latest = releases[0];

                    if (version != latest.TagName)
                    {
                        DialogResult verResult = MessageBox.Show($"A new version is now available :\nYou are using > {version}\nNew > {latest.TagName}\nDo you want to install the new version?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                        if (verResult == DialogResult.Yes)
                        {
                            Process.Start($"https://github.com/Cu-chi/CClick/releases/download/{latest.TagName}/CClick-{latest.TagName}.zip");
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show($"GIT VERSION CHECK: No version found.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (NotFoundException)
            {
                MessageBox.Show($"GIT VERSION CHECK: Can't find this repository on github.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                                richTextBox1.Text += "You took " + Math.Round(EndTest().TotalSeconds, 3).ToString() + "s\n";
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
                                richTextBox1.Text += "You took " + Math.Round(EndTest().TotalSeconds, 3).ToString() + "s\n";
                                MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (comboBox.SelectedIndex == 2 || comboBox.SelectedIndex == 3) // Test using time
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
            timer.Elapsed += Timer;
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
            label1.Invoke(new Action(() => label1.Text = Math.Round(watcher.Elapsed.TotalSeconds, 1).ToString() + "s"));
            label1.Invoke(new Action(() =>
            {
                label1.Refresh();

                if (comboBox.SelectedIndex == 2)
                {
                    if (watcher.ElapsedMilliseconds >= 10000)
                    {
                        EndTest();
                        richTextBox1.Invoke(new Action(() =>
                        {
                            richTextBox1.Text += "Clicked ";
                            richTextBox1.Text += clickCounter.ToString();
                            richTextBox1.Text += " times in 10s\n";
                        }));
                        MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (comboBox.SelectedIndex == 3)
                {
                    if (watcher.ElapsedMilliseconds >= 1000)
                    {
                        EndTest();
                        richTextBox1.Invoke(new Action(() =>
                        {
                            richTextBox1.Text += "Clicked ";
                            richTextBox1.Text += clickCounter.ToString();
                            richTextBox1.Text += " times in 1s\n";
                        }));
                        MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }));
        }
    }
}