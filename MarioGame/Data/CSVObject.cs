using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{


    public class CSVObject
    {
        public String T { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string State { get; set; }
   
        public CSVObject(string name, int x, int y, string state)
        {
            T = name;
            X = x;
            Y = y;
            State = state;
        }
    }
}
