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
    }
}