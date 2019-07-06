using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Web.Script.Serialization;
using Gamespace.Sprites;
using Gamespace.Blocks;
using Gamespace.States;
using Gamespace.Interfaces;

namespace Gamespace
{
    internal class SpriteFactory
    {
        private static readonly SpriteFactory instance = new SpriteFactory();
        private Dictionary<Tuple<String, String, String>, SpriteData> spriteAssignments;
        private Texture2D missingTexture = MarioGame.Instance.Content.Load<Texture2D>("missing");

        static SpriteFactory()
        {
        }

        private SpriteFactory()
        {
            StreamReader reader = File.OpenText("MarioGame/Data/DataFiles/SpriteFactoryData.json");
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var magicNumbers = javaScriptSerializer.Deserialize<SpriteDataRoot>(reader.ReadToEnd());
            reader.Close();

            spriteAssignments = new Dictionary<Tuple<string, string, string>, SpriteData>();

            foreach (SpriteData entry in magicNumbers.Entries)
            {
                var key = new Tuple<String, String, String>(entry.Name, entry.State, entry.PowerUpState);
                entry.Texture = MarioGame.Instance.Content.Load<Texture2D>(entry.TexturePath);
                spriteAssignments.Add(key, entry);
            }

        }

        internal static SpriteFactory Instance { get; } = new SpriteFactory();

        protected class SpriteData
        {
            public String Name { get; set; }
            public String State { get; set; }
            public String PowerUpState { get; set; }
            public Texture2D Texture { get; set; }
            public String TexturePath { get; set; }
            public int FrameCount { get; set; }
            public int FrameDelay { get; set; }
        }

        protected class SpriteDataRoot
        {
            public List<SpriteData> Entries { get; set; }
        }

      
        public ISprite GetSprite(String gameObjectName, String state, String powerUpState)
        {
            var key = new Tuple<String, String, String>(gameObjectName, state, powerUpState);
            if (spriteAssignments.ContainsKey(key))
            {
                return new Sprite(spriteAssignments[key].Texture, spriteAssignments[key].FrameCount, spriteAssignments[key].FrameDelay);
            }
            return new Sprite(missingTexture, 1, 1);
        }

    }
}
