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
                // To-Do :
                // 1 - Check if array is null
                // 2 - Get result image
                // 3 - Display Image in panel

                List<double> clicksArray = new Json().ReadStatsData("data\\stats.json").ClicksPerSecondsAllTest;

                Chart qc = new Chart();
                StatsMenu.StatsForm.StatsForm sf = new();

                qc.Width = sf.chartPanel.Size.Width;
                qc.Height = sf.chartPanel.Size.Height;

                string labelsIndex = "";
                string dataFromArray = "";
                for (int i = 0; i < clicksArray.Count; i++)
                {
                    if (labelsIndex == "")
                    {
                        labelsIndex += $"'{i}'";
                        dataFromArray += $"{clicksArray[i].ToString().Replace(',', '.')}";
                    }
                    else
                    {
                        labelsIndex += $", '{i}'";
                        dataFromArray += $", {clicksArray[i].ToString().Replace(',', '.')}";
                    }
                }

                qc.Config = @$"{{
                    type: 'line',
                    data: {{
                        labels: [{labelsIndex}],
                        datasets: [{{
                            label: 'CPS',
                            data: [{dataFromArray}]
                        }}]
                    }}
                }}";

                Process.Start(new ProcessStartInfo("cmd", $"/c start {qc.GetShortUrl()}") { CreateNoWindow = true });
                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}