using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Timers;
using CClick.SettingsMenu;
using CClick.StatsMenu.StatsForm;
using System.Net;

namespace CClick
{
    public partial class CClick : Form
    {
        private bool running = false;
        private int clickCounter = 0;
        private Stopwatch watcher = new Stopwatch();
        private System.Timers.Timer timer;
        private readonly string version = "0.921";
        private int battleModeHealth = 0;
        private int battleModeDamage = 0;
        private int typeModeEnteredValue = 0;
        private bool firstClickValuesCheck = false;
        private System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"audio\click.wav");
        private Json jData = new Json();
        private Data userData = new Data();
        private StatsData userStatsData = new StatsData();
        private SettingsForm settingsForm = new SettingsForm();
        private StatsForm statsForm = new StatsForm();

        public CClick()
        {
            InitializeComponent();

            string latestVersion = new WebClient().DownloadString("https://pastebin.com/raw/vNb10fgb");

            // Version check
            if (!latestVersion.Contains(version))
            {
                DialogResult verResult = MessageBox.Show($"A new version is now available :\nYou are using > {version}\nNew > {latestVersion}\nDo you want to install the new version?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (verResult == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start https://github.com/Cu-chi/CClick/releases/download/{latestVersion}/CClick-{latestVersion}.zip") { CreateNoWindow = true });
                }
            }


            if (!System.IO.File.Exists("data\\data.json"))
            {
                Data json = new Data
                {
                    EnableSound = false,
                    DefaultTest = -1,
                    CustomConfig = null
                };

                System.IO.Directory.CreateDirectory("data");

                if (!jData.WriteData(json, "data\\data.json"))
                {
                    MessageBox.Show("An error occured: Json file can't be created.\nContact support or create issue on github", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            else
            {
                userData = jData.ReadData("data\\data.json");
                if (userData == null)
                {
                    MessageBox.Show("An error occured: Json file is not working.\nContact support or create issue on github", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                if (userData.EnableSound)
                    settingsForm.soundEffectCheckBox.CheckState = CheckState.Checked;

                if (userData.DefaultTest != -1)
                    comboBox.SelectedIndex = userData.DefaultTest;

                if (comboBox.SelectedIndex == 5) // If selected test is custom
                {
                    if (userData.CustomConfig != null)
                    {
                        if (userData.CustomConfig[0] == "click")
                            typeCheckBox.CheckState = CheckState.Unchecked;
                        else
                            typeCheckBox.CheckState = CheckState.Checked;

                        if (userData.CustomConfig[1] == "battle")
                            battleTypeCheckBox.CheckState = CheckState.Checked;
                        else
                            typeCheckBox.CheckState = CheckState.Unchecked;

                        typeTextBox.Text = userData.CustomConfig[2];
                        battleHealthTextBox.Text = userData.CustomConfig[3];
                        battleDamageTextBox.Text = userData.CustomConfig[4];
                    }

                    CustomTestDisplay(true); // Display customization panel
                }
            }

            if (!System.IO.File.Exists("data\\stats.json"))
            {
                StatsData json = new StatsData
                {
                    ClicksAverage = 0,
                    TotalClicks = 0,
                    TotalMsElapsedOnTest = 0,
                    TotalTests = 0,
                    ClicksPerSecondsAverage = 0
                };

                if (!jData.WriteStatsData(json, "data\\stats.json"))
                {
                    MessageBox.Show("An error occured: Json file can't be created.\nContact support or create issue on github", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            else
            {
                userStatsData = jData.ReadStatsData("data\\stats.json");
                if (userStatsData == null)
                {
                    MessageBox.Show("An error occured: Json file (stats) is not working.\nContact support or create issue on github", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip ToolTips = new ToolTip();
            ToolTips.SetToolTip(statsButton, "Open Statistics");
            ToolTips.SetToolTip(settingsIcon, "Open Settings");

            settingsForm.soundEffectCheckBox.CheckedChanged += new EventHandler(SoundEffectCheckedChanged);
            settingsForm.saveButton.Click += new EventHandler(saveButton_Click);
        }

        private void clickableButton_Click(object sender, EventArgs e)
        {
            if (settingsForm.soundEffectCheckBox.Checked)
            {
                try
                {
                    player.Play();
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show($"FileNotFoundException: Can't find audio file.\nUnchecked sound effect to prevent errors.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    settingsForm.soundEffectCheckBox.CheckState = CheckState.Unchecked;
                }
            }

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
                            if (!firstClickValuesCheck)
                            {
                                typeModeEnteredValue = int.Parse(typeTextBox.Text);
                            }

                            if (clickCounter < typeModeEnteredValue)
                            {
                                clickCounter++;
                                clickLabel.Text = typeModeEnteredValue - clickCounter + " left";
                                if (clickCounter == typeModeEnteredValue)
                                {
                                    richTextBox1.Text += "You took " + Math.Round(EndTest().TotalSeconds, 3).ToString() + $"s to do {typeModeEnteredValue} clicks\n";
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
            firstClickValuesCheck = false;
            StatsData newStatsData = new StatsData
            {
                ClicksAverage = (userStatsData.TotalClicks + clickCounter) / (userStatsData.TotalTests + 1.0), // If 1, that's automatically round the double value
                TotalClicks = userStatsData.TotalClicks + clickCounter,
                TotalMsElapsedOnTest = userStatsData.TotalMsElapsedOnTest + watcher.ElapsedMilliseconds,
                TotalTests = userStatsData.TotalTests + 1,
                ClicksPerSecondsAverage = ToClickPerSeconds(userStatsData.TotalClicks + clickCounter, (long)userStatsData.TotalMsElapsedOnTest + watcher.ElapsedMilliseconds)
            };
            jData.WriteStatsData(newStatsData, "data\\stats.json");
            updateLocalStatsData();

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
                CustomTestDisplay(true);
            }
            else
            {
                CustomTestDisplay(false);
            }
        }

        private void CustomTestDisplay(bool display)
        {
            if (display)
            {
                clickableButton.Size = new Size(380, 232);
                typeCheckBox.Enabled = true;
                typeCheckBox.Visible = true;
                battleTypeCheckBox.Enabled = true;
                battleTypeCheckBox.Visible = true;
                customConfigSaveButton.Visible = true;
                applyConfigButton.Visible = true;

                typeTextBox.Visible = true;
                typeTextBox.Enabled = true;
            }
            else
            {
                clickableButton.Size = new Size(634, 232);
                typeCheckBox.Enabled = false;
                typeCheckBox.Visible = false;
                battleTypeCheckBox.Enabled = false;
                battleTypeCheckBox.Visible = false;
                battleHealthTextBox.Enabled = false;
                battleHealthTextBox.Visible = false;
                battleDamageTextBox.Enabled = false;
                battleDamageTextBox.Visible = false;
                customConfigSaveButton.Visible = false;
                applyConfigButton.Visible = false;

                typeTextBox.Visible = false;
                typeTextBox.Enabled = false;
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
                typeTextBox.Visible = false;
            }
            else
            {
                typeCheckBox.Enabled = true;
                typeTextBox.Enabled = true;
                typeTextBox.Visible = true;
            }
        }

        private void SoundEffectCheckedChanged(object sender, EventArgs e)
        {
            Data dateToWrite = new Data
            {
                EnableSound = settingsForm.soundEffectCheckBox.Checked,
                DefaultTest = userData.DefaultTest,
                CustomConfig = userData.CustomConfig
            };

            jData.WriteData(dateToWrite, "data//data.json");

            updateLocalData();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Data dateToWrite = new Data
            {
                EnableSound = userData.EnableSound,
                DefaultTest = comboBox.SelectedIndex,
                CustomConfig = userData.CustomConfig
            };

            if (!jData.WriteData(dateToWrite, "data//data.json"))
            {
                MessageBox.Show("An error occured: Can't write json data.\nContact support or create issue on github", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            updateLocalData();
        }

        private void customConfigSaveButton_Click(object sender, EventArgs e)
        {
            string[] config = {
                $"{((!typeCheckBox.Checked && !battleTypeCheckBox.Checked) ? "click" : "timer")}",
                $"{(battleTypeCheckBox.Checked ? "battle" : "none")}",
                $"{typeTextBox.Text}",
                $"{battleHealthTextBox.Text}",
                $"{battleDamageTextBox.Text}"
            };

            Data dateToWrite = new Data
            {
                EnableSound = userData.EnableSound,
                DefaultTest = userData.DefaultTest,
                CustomConfig = config
            };

            if (!jData.WriteData(dateToWrite, "data//data.json"))
            {
                MessageBox.Show("An error occured: Can't write json data.\nContact support or create issue on github", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            updateLocalData();
        }

        private void updateLocalData()
        {
            userData = jData.ReadData("data\\data.json");
            if (userData == null)
                MessageBox.Show("An error occured: Json file is not working.\nContact support or create issue on github", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void updateLocalStatsData()
        {
            userStatsData = jData.ReadStatsData("data\\stats.json");
            if (userStatsData == null)
                MessageBox.Show("An error occured: Json file (stats) is not working.\nContact support or create issue on github", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void applyConfigButton_Click(object sender, EventArgs e)
        {
            if (userData.CustomConfig != null)
            {
                if (userData.CustomConfig[1] == "battle")
                    battleTypeCheckBox.CheckState = CheckState.Checked;
                else
                    typeCheckBox.CheckState = CheckState.Unchecked;

                if (userData.CustomConfig[0] == "click")
                    typeCheckBox.CheckState = CheckState.Unchecked;
                else if (!battleTypeCheckBox.Checked)
                    typeCheckBox.CheckState = CheckState.Checked;

                typeTextBox.Text = userData.CustomConfig[2];
                battleHealthTextBox.Text = userData.CustomConfig[3];
                battleDamageTextBox.Text = userData.CustomConfig[4];
            }
            else
            {
                MessageBox.Show("Operation cancelled: Can't apply a null configuration.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            SettingsFormUtilities settingsFormUtilities = new SettingsFormUtilities();
            if (!settingsForm.Visible)
            {
                settingsFormUtilities.InitializeSettingsFormParameters(settingsForm, userData.EnableSound);
                settingsForm.ShowDialog();
            }
            else
                settingsForm.Hide();
        }

        private void statsButton_Click(object sender, EventArgs e)
        {
            if (!statsForm.Visible)
            {
                Cursor.Current = Cursors.WaitCursor;
                statsForm.totalClicksLabel.Text = $"Total Clicks: {userStatsData.TotalClicks}";
                statsForm.totalTestsLabel.Text = $"Total Tests: {userStatsData.TotalTests}";
                statsForm.clicksAverageLabel.Text = $"Clicks per test average: {Math.Round(userStatsData.ClicksAverage, 3)}";
                statsForm.timeElapsedLabel.Text = $"Time elapsed on tests: {Math.Round(userStatsData.TotalMsElapsedOnTest / 1000, 2)}s";
                statsForm.clicksPerSecondsAverageLabel.Text = $"Clicks per seconds average: {Math.Round(userStatsData.ClicksPerSecondsAverage, 3)}/s";
                statsForm.ShowDialog();
                Cursor.Current = Cursors.Default;
            }
            else
                statsForm.Hide();
        }
    }
}