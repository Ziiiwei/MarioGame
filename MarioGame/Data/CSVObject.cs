﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{


    public class CSVObject
    {
        public String Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
   
        public CSVObject(String name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }
    

    
    }
}