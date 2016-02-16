using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Relay
    {
        public int GPIO { get; set; }
        public int id { get; set; }
        public int status { get; set; }
        public string type { get; set; }
    }


    public class RelayCollection
    {

        public Relay[] relays { get; set; }

    }
}
