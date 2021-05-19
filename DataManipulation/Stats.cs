using System.Collections.Generic;

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
        public void RetrieveClicksPerSecondsData()
        {
            StatsData clicksArray = new Json().ReadStatsData("data\\stats.json");
        }
    }
}