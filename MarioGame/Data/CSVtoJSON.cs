
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Web.Script.Serialization;
using Microsoft.VisualBasic.FileIO;
using ChoETL;


namespace Gamespace
{
    public class CSVtoJSON
    {
        static CSVtoJSON()
        {

        }
        public static void convert() {
            string[] lines = System.IO.File.ReadAllLines(@"MarioGame/Data/level1example.csv");
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadLines(lines) 
            .WithField("Row", position: 1)
            .WithField("Col1", position: 2)
            .WithField("Col2", position: 3)
            .WithField("Col3", position: 4)
            .WithField("Col4", position: 5)
            .WithField("Col5", position: 6)
            .WithField("Col6", position: 7)
            .WithField("Col7", position: 8)
            .WithField("Col8", position: 9)
            .WithField("Col9", position: 10)
            .WithFirstLineHeader(true)
            )
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
