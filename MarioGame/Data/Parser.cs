using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;

namespace Gamespace
{
    static class Parser
    {
        private static readonly String StuffInGame = "MarioGame/Data/StuffInGame.json";
        

        public static Mario ParseMario()
        {
            StreamReader reader = File.OpenText(StuffInGame);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var Mario = javaScriptSerializer.Deserialize<Mario>(reader.ReadToEnd());
            return Mario;
        }

        public static List<IGameObject> ParseObjects()
        {
            StreamReader reader = File.OpenText(StuffInGame);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var magicNumbers = javaScriptSerializer.Deserialize<IGameObject>(reader.ReadLine());
            return null;
        }
    }
}
