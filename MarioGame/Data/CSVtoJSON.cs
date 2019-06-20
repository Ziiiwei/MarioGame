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
        private const int UNIT = 32;
        public static void ConvertCSVtoJSON()
        {
            
            StreamReader sr = new StreamReader("MarioGame/Data/level1test.csv");

            String[][] data = File.ReadLines("MarioGame/Data/level1test.csv").Select(x => x.Split(',')).ToArray();
            int _X = 0;
            int _Y = 0;
            int row = 0;
            var JsonList = new List<CSVObject>();
            string name;
            string state = "null";
            string path = "MarioGame/Data/Level1.json";
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
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
                        _X = (j * UNIT);
                        _Y = (i * UNIT);

                        CSVObject obj = new CSVObject(name, _X, _Y, state);
                        string output = JsonConvert.SerializeObject(obj);
                        JsonList.Add(obj);
                    }
                }
            }
            var JsonListWithHeader = new
            {
                gameObjects = JsonList
            };
            using (StreamWriter file = File.CreateText(@path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, JsonListWithHeader);
            }
        }
    }
}

