using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace.Items;
using Gamespace.Blocks;
using System.IO;
using System.Web.Script.Serialization;

namespace Gamespace
{
    internal class LevelLoader
    {
        public LevelLoader(World world)
        {
            //CSVtoJSON.convert();
            CSVtoJSON2.convert();
            var gameObjects = JsonParser.Instance.ParseLevelFile();

            foreach (Tuple<int, IGameObject> entry in gameObjects)
            {
                World.Instance.AddGameObject(entry.Item2);
            }
        }
    }
}
