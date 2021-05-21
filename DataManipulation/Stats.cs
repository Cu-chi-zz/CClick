using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using QuickChart;

namespace CClick
{
    public class StatsData
    {
        public double ClicksAverage { get; set; } // Clicks per test
        public int TotalClicks { get; set; }
        public double TotalMsElapsedOnTest { get; set; } //  Ms elapsed on all tests
        public int TotalTests { get; set; }
        public double ClicksPerSecondsAverage { get; set; }
        public List<double> ClicksPerSecondsAllTest { get; set; }
    }

    public class StatsUtilities
    {
        public bool GetChart()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<double> clicksArray = new Json().ReadStatsData("data\\stats.json").ClicksPerSecondsAllTest;

                Chart qc = new Chart();
                StatsMenu.StatsForm.StatsForm sf = new();

                qc.Width = sf.chartPanel.Size.Width;
                qc.Height = sf.chartPanel.Size.Height;

                string labelsIndex = "";
                string dataFromArray = "";

                if (clicksArray == null)
                {
                    MessageBox.Show($"Tests results are empty, do a test and retry.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (clicksArray.Count > 250)
                {
                    // If array count is bigger than QuickChart values limit
                    // Start from array - 250 to last array value
                    // > Set the last 250 tests in the chart
                    for (int i = 250; i > 0; i--)
                    {
                        int index = clicksArray.Count - i;

                        if (labelsIndex == "")
                        {
                            labelsIndex += $"'{index}'";
                            dataFromArray += $"{clicksArray[index]}";
                        }
                        else
                        {
                            labelsIndex += $", '{index}'";
                            dataFromArray += $", {clicksArray[index]}";
                        }

                        if (i > 250)
                            break;
                    }

                }
                else
                {
                    for (int i = 0; i < clicksArray.Count; i++)
                    {
                        if (labelsIndex == "")
                        {
                            labelsIndex += $"'{i}'";
                            dataFromArray += $"{clicksArray[i]}";
                        }
                        else
                        {
                            labelsIndex += $", '{i}'";
                            dataFromArray += $", {clicksArray[i]}";
                        }
                    }
                }

                qc.Config = @$"{{
                    type: 'line',
                    data: {{
                        labels: [{labelsIndex}],
                        datasets: [{{
                            label: 'CPS',
                            borderColor: getGradientFillHelper('vertical', ['#eb3639', '#a336eb', '#36a2eb']),
                            borderWidth: {(clicksArray.Count < 100 ? 3 : 1)},
                            fill: false,
                            pointRadius: 0,
                            lineTension: 0.2,
                            data: [{dataFromArray}]
                        }}]
                    }},
                    options: {{
                        legend: {{
                          display: false
                        }},
                    }}
                }}";

                qc.ToFile("data\\chart.png");
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e}");
                return false;
            }
        }
    }
}