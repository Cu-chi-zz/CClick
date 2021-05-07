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
using System.Runtime.InteropServices;

namespace CClick
{
    public partial class Form1 : Form
    {
        private static bool running = false;
        private static int clickCounter = 0;
        private static Stopwatch watcher = new Stopwatch();
        private static System.Timers.Timer timer;
        private static string version = "1.0.6";
        private static int battleModeHealth = 0;
        private static int battleModeDamage = 0;
        private static bool firstClickValuesCheck = false; // To-Do : Stop assign on each click vars (ex: k for Custom Mode)

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
                            Process.Start(new ProcessStartInfo("cmd", $"/c start https://github.com/Cu-chi/CClick/releases/download/{latest.TagName}/CClick-{latest.TagName}.zip") { CreateNoWindow = true });
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
                            clickLabel.Text = 10 - clickCounter + " left";
                            if (clickCounter == 10)
                            {
                                richTextBox1.Text += "You took " + Math.Round(EndTest().TotalSeconds, 3).ToString() + "s to do 10 clicks\n";
                                richTextBox1.ScrollToCaret();
                                MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (comboBox.SelectedIndex == 1) // 100 clicks
                    {
                        if (clickCounter < 100)
                        {
                            clickCounter++;
                            clickLabel.Text = 100 - clickCounter + " left";
                            if (clickCounter == 100)
                            {
                                richTextBox1.Text += "You took " + Math.Round(EndTest().TotalSeconds, 3).ToString() + "s to do 100 clicks\n";
                                richTextBox1.ScrollToCaret();
                                MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (comboBox.SelectedIndex == 2) // 1000 clicks
                    {
                        if (clickCounter < 1000)
                        {
                            clickCounter++;
                            clickLabel.Text = 1000 - clickCounter + " left";
                            if (clickCounter == 1000)
                            {
                                richTextBox1.Text += "You took " + Math.Round(EndTest().TotalSeconds, 3).ToString() + "s to do 1000 clicks\n";
                                richTextBox1.ScrollToCaret();
                                MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (comboBox.SelectedIndex == 3 || comboBox.SelectedIndex == 4) // Test using time
                    {
                        clickCounter++;
                        clickLabel.Text = clickCounter + " clicks";
                    }
                    else if (comboBox.SelectedIndex == 5) // Test using time
                    {
                        if (typeCheckBox.Checked)
                        {
                            clickCounter++;
                            clickLabel.Text = clickCounter + " clicks";
                        }
                        else if ((!typeCheckBox.Checked) && (!battleTypeCheckBox.Checked))
                        {
                            int k = int.Parse(typeTextBox.Text);
                            if (clickCounter < k)
                            {
                                clickCounter++;
                                clickLabel.Text = k - clickCounter + " left";
                                if (clickCounter == k)
                                {
                                    richTextBox1.Text += "You took " + Math.Round(EndTest().TotalSeconds, 3).ToString() + $"s to do {k} clicks\n";
                                    richTextBox1.ScrollToCaret();
                                    MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else if (battleTypeCheckBox.Checked)
                        {
                            battleModeHealth -= battleModeDamage;
                            clickLabel.Text = battleModeHealth + "hp remaining";
                            if (battleModeHealth <= 0)
                            {
                                richTextBox1.Text += "You took " + Math.Round(EndTest().TotalSeconds, 3).ToString() + $"s to do kill enemy with {battleHealthTextBox.Text}hp, you were doing {battleModeDamage} damage per click\n";
                                richTextBox1.ScrollToCaret();
                                MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            clickCounter = 1;
            running = true;
            watcher.Reset();
            watcher.Start();
            timer = new System.Timers.Timer();
            timer.Elapsed += Timer;
            timer.Enabled = true;

            if (comboBox.SelectedIndex == 0) // 10 Clicks
            {
                clickLabel.Text = 10 - clickCounter + " left";
            }
            else if (comboBox.SelectedIndex == 1) // 100 clicks
            {
                clickLabel.Text = 100 - clickCounter + " left";
            }
            else if (comboBox.SelectedIndex == 2) // 1000 clicks
            {
                clickLabel.Text = 1000 - clickCounter + " left";
            }
            else if ((comboBox.SelectedIndex == 5) && (!typeCheckBox.Checked) && (!battleTypeCheckBox.Checked)) // Custom with clicks mode
            {
                int k = int.Parse(typeTextBox.Text);
                clickLabel.Text = k - clickCounter + " left";
            }
            else if ((comboBox.SelectedIndex == 5) && (battleTypeCheckBox.Checked))
            {
                if (!int.TryParse(battleHealthTextBox.Text, out battleModeHealth))
                {
                    EndTest();
                    MessageBox.Show("The entered value is not correct for Health", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(battleDamageTextBox.Text, out battleModeDamage))
                {
                    EndTest();
                    MessageBox.Show("The entered value is not correct for Damage", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                clickLabel.Text = $"{battleModeHealth}hp remaining";
            }
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
            timeLabel.Invoke(new Action(() => timeLabel.Text = Math.Round(watcher.Elapsed.TotalSeconds, 1).ToString() + "s"));
            timeLabel.Invoke(new Action(() =>
            {
                timeLabel.Refresh();

                if (comboBox.SelectedIndex == 3)
                {
                    if (watcher.ElapsedMilliseconds >= 10000)
                    {
                        long ms = watcher.ElapsedMilliseconds;
                        EndTest();
                        richTextBox1.Invoke(new Action(() =>
                        {
                            richTextBox1.Text += "Clicked ";
                            richTextBox1.Text += clickCounter.ToString();
                            richTextBox1.Text += " times in 10s\n";
                            richTextBox1.Text += "Clicks per second on average: \n";
                            richTextBox1.Text += ToClickPerSeconds(clickCounter, ms);
                            richTextBox1.Text += " cps\n";
                        }));
                        MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (comboBox.SelectedIndex == 4)
                {
                    if (watcher.ElapsedMilliseconds >= 1000)
                    {
                        long ms = watcher.ElapsedMilliseconds;
                        EndTest();
                        richTextBox1.Invoke(new Action(() =>
                        {
                            richTextBox1.Text += "Clicked ";
                            richTextBox1.Text += clickCounter.ToString();
                            richTextBox1.Text += " times in 1s\n";
                            richTextBox1.Text += "Clicks per second on average: \n";
                            richTextBox1.Text += ToClickPerSeconds(clickCounter, ms);
                            richTextBox1.Text += " cps\n";
                        }));
                        MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if ((comboBox.SelectedIndex == 5) && (typeCheckBox.Checked))
                {
                    int secFromTextBox = int.Parse(typeTextBox.Text);
                    if (watcher.ElapsedMilliseconds >= secFromTextBox * 1000)
                    {
                        long ms = watcher.ElapsedMilliseconds;
                        EndTest();
                        richTextBox1.Invoke(new Action(() =>
                        {
                            richTextBox1.Text += "Clicked ";
                            richTextBox1.Text += clickCounter.ToString();
                            richTextBox1.Text += $" times in {secFromTextBox}s\n";
                            richTextBox1.Text += "Clicks per second on average: \n";
                            richTextBox1.Text += ToClickPerSeconds(clickCounter, ms);
                            richTextBox1.Text += " cps\n";
                        }));
                        MessageBox.Show("Test finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }));
        }

        private double ToClickPerSeconds(int totalClicks, long msElapsed)
        {
            return (double)totalClicks / (double)(msElapsed / 1000);
        }

        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 5) // If selected item is "Custom"
            {
                typeCheckBox.Enabled = true;
                typeCheckBox.Visible = true;
                battleTypeCheckBox.Enabled = true;
                battleTypeCheckBox.Visible = true;

                typeTextBox.Visible = true;
                typeTextBox.Enabled = true;
                this.Size = new Size(750, this.Size.Height);
            }
        }

        private void typeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (typeCheckBox.Checked)
            {
                typeTextBox.PlaceholderText = "Seconds before end";
            }
            else
            {
                typeTextBox.PlaceholderText = "Max clicks";
            }
        }

        private void battleTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            battleHealthTextBox.Enabled = !battleHealthTextBox.Enabled;
            battleHealthTextBox.Visible = !battleHealthTextBox.Visible;
            battleDamageTextBox.Enabled = !battleDamageTextBox.Enabled;
            battleDamageTextBox.Visible = !battleDamageTextBox.Visible;
            if (battleTypeCheckBox.Checked)
            {
                typeCheckBox.Checked = false;
                typeCheckBox.Enabled = false;
                typeTextBox.Enabled = false;
            }
            else
            {
                typeCheckBox.Enabled = true;
                typeTextBox.Enabled = true;
            }
        }
    }
}