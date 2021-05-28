using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CClick
{
    internal class Json
    {
        /// <summary>
        /// Write in the json file specified
        /// </summary>
        /// <param name="j">Json data type</param>
        /// <param name="p">Json file path</param>
        /// <returns>True if the file is successfully created</returns>
        public bool WriteData(Data j, string p)
        {
            try
            {
                System.IO.File.WriteAllText(p, JsonConvert.SerializeObject(j, Formatting.None));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Read and return readed json data
        /// </summary>
        /// <param name="p">Path to json file to read</param>
        /// <returns>Json data readed</returns>
        public Data ReadData(string p)
        {
            Data d;
            try
            {
                string jString = System.IO.File.ReadAllText(p);
                d = JsonConvert.DeserializeObject<Data>(jString);
                return d;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Write in the json file specified
        /// </summary>
        /// <param name="j">Json data type</param>
        /// <param name="p">Json file path</param>
        /// <returns>True if the file is successfully created</returns>
        public bool WriteStatsData(StatsData j, string p)
        {
            try
            {
                System.IO.File.WriteAllText(p, JsonConvert.SerializeObject(j, Formatting.None));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Read and return readed json data
        /// </summary>
        /// <param name="p">Path to json file to read</param>
        /// <returns>Json data readed</returns>
        public StatsData ReadStatsData(string p)
        {
            StatsData d;
            try
            {
                string jString = System.IO.File.ReadAllText(p);
                d = JsonConvert.DeserializeObject<StatsData>(jString);
                return d;
            }
            catch
            {
                return null;
            }
        }
    }

    public class Data
    {
        public bool EnableSound { get; set; }
        public bool EnableProgressBar { get; set; }
        public int DefaultTest { get; set; }
        public string[] CustomConfig { get; set; }
        public bool RichTextBoxSaveEnabled { get; set; }
        public string RichTextBoxContent { get; set; }
        public bool SaveBestScoreForEachTest { get; set; }
    }
}