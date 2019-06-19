using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Web.Script.Serialization;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace Gamespace
{
    public class CSVtoJSON
    {
        static CSVtoJSON()
        {

        }

        public static void convert()
        {
            StreamReader sr = new StreamReader("MarioGame/Data/level1example.csv");

            String [][] data = new String[15][];
            data = File.ReadLines("MarioGame/Data/level1example.csv").Select(x => x.Split(',')).ToArray();


           
            int _X = 0;
            int _Y = 0;
            int row = 0;
            var JsonList = new List<CSVObject>();
            String name = "";

            String path = "MarioGame/Data/level1objects.json";

            using (Stream stream = File.Open(path, FileMode.Create))
            {
                
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < 10; j++)
                    {

                        // The first column is the row number
                        if (j == 0)
                        {
                            row = Int32.Parse(data[i][j]);
                        }

                        /* If the array location is not empty, grab the name
                        *  calculat the X and Y coordinates, and serialize as 
                        *  a JSON object.
                        */
                        else if (!(data[i][j] == ""))
                        {
                            name = data[i][j];
                            _X = (i * 32);
                            _Y = (j * 32);
                            CSVObject obj = new CSVObject(name, _X, _Y);
                            string output = JsonConvert.SerializeObject(obj);
                            JsonList.Add(obj);

                        }

                    }
                }
            }
            using (StreamWriter file = File.CreateText(@"MarioGame/Data/level1objects.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, JsonList);
            }

        }
    }
}

