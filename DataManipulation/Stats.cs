namespace CClick
{
    public class StatsData
    {
        public double ClicksAverage { get; set; } // Clicks per test
        public int TotalClicks { get; set; }
        public double TotalMsElapsedOnTest { get; set; } //  Ms elapsed on all tests
        public int TotalTests { get; set; }
        public double ClicksPerSecondsAverage { get; set; }
    }
}