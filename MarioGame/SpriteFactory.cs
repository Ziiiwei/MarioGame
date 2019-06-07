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

namespace Gamespace
{
    public sealed class SpriteFactory
    {
        private static readonly SpriteFactory instance = new SpriteFactory();
        private static readonly String marioSpriteMagicNumbers = "MarioGame/MarioSpriteMagicNumbers.json";
        private static readonly String enemyAndItemSpriteMagicNumbers = "MarioGame/EnemyAndItemMagicNumbers.json";
        private static readonly String spriteFrameCountFileLocation = "MarioGame/SpriteFrameCounts.json";
        private MarioGame gameInstance;
        private Dictionary<(Type, Type), Texture2D> spritesWithStateAssignments;
        private Dictionary<Type, int> spriteFrameCounts;
        private Dictionary<Type, Texture2D> spriteAssignments;

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

            StreamReader reader = File.OpenText(marioSpriteMagicNumbers);
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

            reader = File.OpenText(spriteFrameCountFileLocation);
            var frameCounts = javaScriptSerializer.Deserialize<Dictionary<String, int>>(reader.ReadToEnd());
            spriteFrameCounts = new Dictionary<Type, int>();

           
            foreach (KeyValuePair<String, int> framesForState in frameCounts)
            {
                if (Type.GetType(framesForState.Key) != null)
                {
                    spriteFrameCounts.Add(Type.GetType(framesForState.Key), framesForState.Value);
                }
                
            }

            reader = File.OpenText(enemyAndItemSpriteMagicNumbers);
            var assignmentsFromFile = javaScriptSerializer.Deserialize<Dictionary<String, String>>(reader.ReadToEnd());
            spriteAssignments = new Dictionary<Type, Texture2D>();

            foreach (KeyValuePair<String, String> entry in assignmentsFromFile)
            {
                if (Type.GetType(entry.Key) == null)
                {
                    continue;
                }
                var texture = gameInstance.Content.Load<Texture2D>(entry.Value);
                spriteAssignments.Add(Type.GetType(entry.Key), texture);
            }
        }

        public ISprite GetSprite(IGameObject gameObject)
        {
            if (spriteAssignments.ContainsKey(gameObject.GetType()))
            {
                var texture = spriteAssignments[gameObject.GetType()];
                int frameCount = 1;

                if (spriteFrameCounts.ContainsKey(gameObject.GetType()))
                {
                    frameCount = spriteFrameCounts[gameObject.GetType()];
                }
                return new Sprite(texture, frameCount);
            }
            else
            {
                return new Sprite(gameInstance.Content.Load<Texture2D>("missing"), 1);
            }
           
        }

        public ISprite GetSprite(IMarioState marioState, IMarioPowerUpState powerUpState)
        {
            var texture = spritesWithStateAssignments[(marioState.GetType(), powerUpState.GetType())];
            var frames = 1;
            if (spriteFrameCounts.ContainsKey(marioState.GetType()))
            {
                frames = spriteFrameCounts[marioState.GetType()];
            }
            
            return new Sprite(texture,  frames);
        }

        public ISprite GetSprite(IBlockState blockState)
        {
            var texture = spriteAssignments[blockState.GetType()];
            var frames = spriteFrameCounts[blockState.GetType()];
            return new Sprite(texture, frames);
        }






    }
}
