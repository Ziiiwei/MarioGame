using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    sealed class SpriteFactory
    {
        private static readonly SpriteFactory instance = new SpriteFactory();
        private static Texture2D marioTexture;
        private Game gameInstance;

        static SpriteFactory()
        {
        }

        private SpriteFactory()
        {
            gameInstance.Content.Load<Texture2D>("SonicRoll");
            gameInstance.Content.Load<Texture2D>("SonicDead");
        }

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public static void SetGameInstance(Game game)
        {
            SpriteFactory.Instance.gameInstance = game;
        }

        public ISprite CreateGoomba(Vector2 positionOnScreen)
        {
            return null;
        }

        public static ISprite CreateKoopa(Vector2 positionOnScreen)
        {
            return null;
        }

        public static ISprite CreateMario(Vector2 positionOnScreen)
        {
            return new Mario(5, 1, marioTexture, positionOnScreen);
        }

        public static ISprite CreatePipe(Vector2 positionOnScreen)
        {
            return null;
        }
        
    }
}
