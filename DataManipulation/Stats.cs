using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CClick
{
    internal class Stats
    {
        /// <summary>
        /// Write and recalculate the total average of all tests.
        /// </summary>
        /// <returns>False on error</returns>
        public bool WriteAndRecalculateClicksAvg()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class StatsData
    {
        public double ClicksAverage { get; set; }
        public int TotalClicks { get; set; }
        public double TotalMsElapsedOnTest { get; set; }
        public int TotalTests { get; set; }
    }
}