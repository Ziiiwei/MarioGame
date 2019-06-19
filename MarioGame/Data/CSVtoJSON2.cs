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
    public class CSVtoJSON2
    {
        static CSVtoJSON2()
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
            String name = "";


            for(int i = 0; i < data.GetLength(1); i++)
            {
                for(int j = 0; j < data.GetLength(0); j++)
                {
                    if(j == 0)
                    {
                       // row = [i][j];
                    }
                    //if([i][j] = "")
                    //{

                    //}
                    name = data[i][j];
                    _X = (i * 16);
                    _Y = (j * 16);
                    CSVObject obj = new CSVObject(name, _X, _Y);
                    string output = JsonConvert.SerializeObject(obj);
                    Console.WriteLine(output);
                }
            }
        }
    }
}

