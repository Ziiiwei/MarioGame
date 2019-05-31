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

namespace Sprint2
{
    public sealed class SpriteFactory
    {
        private static readonly SpriteFactory instance = new SpriteFactory();
        private static readonly String magicNumbersFileLocation;
        private MarioGame gameInstance;
        private Dictionary<(Type, Type), Texture2D> spritesWithStateAssignments;
        private Dictionary<Type, int> spriteFrameCounts;
        private Dictionary<String, Texture2D> spriteAssignments;

        static SpriteFactory()
        {
    }

        private SpriteFactory()
        {
        }

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void SetGameInstance(MarioGame game)
        {
            gameInstance = game;

            StreamReader reader = File.OpenText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SpriteMagicNumbers.json"));
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var magicNumbers = javaScriptSerializer.Deserialize<Dictionary<String, Dictionary<String, String>>>(reader.ReadToEnd());
            spritesWithStateAssignments = new Dictionary<(Type, Type), Texture2D>();

            foreach (String movementState in magicNumbers.Keys)
            {
                foreach (KeyValuePair<String, String> powerUpStateAndTexture in magicNumbers[movementState])
                {
                    Texture2D texture = gameInstance.Content.Load<Texture2D>(powerUpStateAndTexture.Value);
                    spritesWithStateAssignments.Add((Type.GetType(movementState), Type.GetType(powerUpStateAndTexture.Key)), texture);

                }
            }

            reader = File.OpenText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SpriteFrameCounts.json"));
            var frameCounts = javaScriptSerializer.Deserialize<Dictionary<String, int>>(reader.ReadToEnd());
            spriteFrameCounts = new Dictionary<Type, int>();

            foreach (KeyValuePair<String, int> framesForState in frameCounts)
            {
                spriteFrameCounts.Add(Type.GetType(framesForState.Key), framesForState.Value);
            }


            spriteAssignments = new Dictionary<String, Texture2D>();

            /*
            textures.Add(gameInstance.Content.Load<Texture2D>("Coin"));
            textures.Add(gameInstance.Content.Load<Texture2D>("Star"));
            textures.Add(gameInstance.Content.Load<Texture2D>("GreenShroom"));
            textures.Add(gameInstance.Content.Load<Texture2D>("RedShroom"));
            textures.Add(gameInstance.Content.Load<Texture2D>("Flower"));
            textures.Add(gameInstance.Content.Load<Texture2D>("Goomba"));
            textures.Add(gameInstance.Content.Load<Texture2D>("GoombaStomped"));
            textures.Add(gameInstance.Content.Load<Texture2D>("Pipe"));
            textures.Add(gameInstance.Content.Load<Texture2D>("KoopaLeft"));
            textures.Add(gameInstance.Content.Load<Texture2D>("KoopaRight"));
            textures.Add(gameInstance.Content.Load<Texture2D>("KoopaShell"));
            textures.Add(gameInstance.Content.Load<Texture2D>("KoopaFlipped"));
            textures.Add(gameInstance.Content.Load<Texture2D>("BrickBlock"));
            textures.Add(gameInstance.Content.Load<Texture2D>("FloorBlock"));
            textures.Add(gameInstance.Content.Load<Texture2D>("MetalBlock"));
            textures.Add(gameInstance.Content.Load<Texture2D>("CoinBlock"));
            */
        }

        public ISprite GetSprite(String sprite)
        {
            return new Sprite(gameInstance.Content.Load<Texture2D>("Coin"), 1, 1, 1);
        }

        public ISprite GetSprite(IMarioState marioState, IMarioPowerUpState powerUpState)
        {
            var texture = spritesWithStateAssignments[(marioState.GetType(), powerUpState.GetType())];
            var frames = spriteFrameCounts[marioState.GetType()];
            return new Sprite(texture, 1, frames, frames);
        }
       



    }
}
