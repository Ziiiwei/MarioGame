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
    class JsonGameObject
    {
        public int Uid { get; set; }
        public String T { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public String State { get; set; }
    }

    class JsonGameObjectRoot
    {
        public List<JsonGameObject> gameObjects;
    }
    class LevelLoader
    {
        private readonly String levelFilePath = "MarioGame/Data/Level1.json";
        public LevelLoader(World world)
        {
            /*
            world.Mario = new Mario(new Vector2(300, 200));
            world.Mario = new Mario(new Vector2(175, 100));
            new Flower(new Vector2(125, 100)));
            world.AddGameObject(new Coin(new Vector2(175, 100)));
            world.AddGameObject(new RedShroom(new Vector2(225, 100)));
            world.AddGameObject(new GreenShroom(new Vector2(275, 100)));
            world.AddGameObject(new Star(new Vector2(325, 100)));
            world.AddGameObject(new Pipe(new Vector2(375, 150)));
            world.AddGameObject(new Block(new UsedBlock(), new Vector2(475, 100)));
            world.Block1 = new Block(new BrickBlock(), new Vector2(375, 100));
            world.Block2 = new Block(new HiddenBlock(), new Vector2(425, 100));
            world.Block3 = new Block(new QuestionBlock(), new Vector2(525, 100));
            */

            StreamReader reader = File.OpenText(levelFilePath);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var magicNumbers = javaScriptSerializer.Deserialize<JsonGameObjectRoot>(reader.ReadToEnd());

            foreach (JsonGameObject jgo in magicNumbers.gameObjects)
            {
                Type t = Type.GetType(jgo.T);
                int x = jgo.X;
                int y = jgo.Y;
                Type state = Type.GetType(jgo.State);

                if (state != null)
                {
                    var stateInstance = Activator.CreateInstance(state);
                    var go = (IGameObject)Activator.CreateInstance(t, stateInstance, new Vector2(x, y));
                    World.Instance.AddGameObject(go.Uid, go);
                }
                else
                {
                    var go = (IGameObject)Activator.CreateInstance(t, new Vector2(x, y));
                    World.Instance.AddGameObject(go.Uid, go);
                }
                
            }
        }
    }
}
