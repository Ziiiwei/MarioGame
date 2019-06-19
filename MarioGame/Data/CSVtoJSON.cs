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
        public static void convert()
        {
            string[] lines = System.IO.File.ReadAllLines(@"MarioGame/Data/level1example.csv");
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadLines(lines)

            .WithFirstLineHeader(true)
            )
            {
                Console.WriteLine(p.ToString());
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }

            // Write string of json format into a specific json file
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\KC\Desktop\MarioGame\MarioGame\MarioGame\Data\level1example.json");
            file.WriteLine(sb.ToString());

            Console.WriteLine(sb);
        }


        protected class DeserializedObject
        {


   
        }
    }
}
