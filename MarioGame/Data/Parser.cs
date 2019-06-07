using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;
using System.Web.Script.Serialization;

namespace Gamespace
{
    static class Parser
    {
        private static readonly String StuffInGame = "MarioGame/Data/StuffInGame.json";
        

        public static Vector2 ParseMario()
        {
            StreamReader reader = File.OpenText(StuffInGame);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var Mario = javaScriptSerializer.Deserialize<Vector2>(reader.ReadToEnd());
            return Mario;
        }

        public static List<IGameObject> ParseObjects()
        {
            StreamReader reader = File.OpenText(StuffInGame);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var Objects = javaScriptSerializer.Deserialize<List<IGameObject>>(reader.ReadLine());
            return Objects;
        }
    }
}
