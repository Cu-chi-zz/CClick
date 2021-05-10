using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                System.IO.File.WriteAllText(p, JsonConvert.SerializeObject(j, Formatting.Indented));
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
            string jString = System.IO.File.ReadAllText(p);
            try
            {
                d = JsonConvert.DeserializeObject<Data>(jString);
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
        public int DefaultTest { get; set; }
    }
}