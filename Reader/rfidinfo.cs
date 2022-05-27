using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rfidsinfo
{
    public class rfidinfo
    {
        public string RFID { get; set; }
        public string Type { get; set; }
        public DateTime SeenTime { get; set; }
        public DateTime CheckTime { get; set; }

        public void Clear()
        {
            RFID = string.Empty;
            Type = string.Empty;
        }

    }
}
