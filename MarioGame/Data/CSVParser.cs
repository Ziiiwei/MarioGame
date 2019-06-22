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
    public class CSVParser
    {
        static CSVParser()
        {

        }
        private const int UNIT = 32;
        private static Dictionary<string, string> shortcuts;

        public static void ConvertCSVtoJSON()
        {
            shortcuts = new Dictionary<string, string>
            {
                {"BB", "Gamespace.Blocks.BrickBlock"},
                {"MB", "Gamespace.Blocks.MetalBlock" },
                {"FB", "Gamespace.Blocks.FloorBlock" },
                {"UB", "Gamespace.Blocks.UsedBlock" },
                {"HB", "Gamespace.Blocks.HiddenBlock" },
                {"QB", "Gamespace.Blocks.QuestionBlock" },
                {"P", "Gamespace.Items.Pipe" },
                {"PE", "Gamespace.Items.PipeExtension" },
                {"M", "Gamespace.Mario" },
                {"G", "Gamespace.Goombas.Goomba" },
                {"K", "Gamespace.Koopas.Koopa" },
                {"C", "Gamespace.Items.Coin" },
                {"S", "Gamespace.Items.Star" },
                {"FF", "Gamespace.Items.Flower" },
                {"GS", "Gamespace.Items.GreenShroom" },
                {"RS", "Gamespace.Items.RedShroom" },
                {"F", "Gamespace.FlagPole.Flag" },
                {"FP","Gamespace.FlagPole.Flagpole" },
                {"FT", "Gamespace.FlagPole.FlagPoleTop" },
                {"CA", "Gamespace.Castle.Castle" },
                {"C1", "Gamespace.Clouds.Cloud1" },
                {"C2", "Gamespace.Clouds.Cloud2" },
                {"C3", "Gamespace.Clouds.Cloud3" },
                {"BH", "Gamespace.Hills.BigHill" },
                {"SH", "Gamespace.Hills.SmallHill" }

            };

            String[][] data = File.ReadLines("MarioGame/Data/level1.csv").Select(x => x.Split(',')).ToArray();
            int _X = 0;
            int _Y = 0;
            var JsonList = new List<CSVObject>();
            string pattern = @"\+";
            string name;
            string state = "null";
            string path = "MarioGame/Data/Level1.json";
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {

                    // The first column is the row number
                    //if (j == 0)
                    //{
                    //    row = Int32.Parse(data[i][j]);
                    //}
                    /* If the array location is not empty, grab the name
                     *  calculat the X and Y coordinates, and serialize as 
                     *  a JSON object.
                     */
                    if (!(data[i][j] == ""))
                    {
                        if (data[i][j].Contains("+"))
                        {
                            string[] elements = System.Text.RegularExpressions.Regex.Split(data[i][j],pattern);
                            name = shortcuts[elements[0]];
                            state = shortcuts[elements[1]];
                        }
                        else
                        {
                            name = shortcuts[data[i][j]];
                            state = " null";
                        }
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

