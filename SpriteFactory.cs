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
    public sealed class SpriteFactory
    {
        private static readonly SpriteFactory instance = new SpriteFactory();
        private List<Texture2D> textures;
        private List<List<Texture2D>> marioTextures;
        private MarioGame gameInstance;
        private Dictionary<String, int> marioStateValues;

        static SpriteFactory()
        {
        }

        private SpriteFactory()
        {
            textures = new List<Texture2D>();
            marioTextures = new List<List<Texture2D>>();
            // Small Mario textures.
            marioTextures.Add(new List<Texture2D>());
            // Big Mario textures.
            marioTextures.Add(new List<Texture2D>());
            // Fire Mario textures.
            marioTextures.Add(new List<Texture2D>());

            marioStateValues = new Dictionary<string, int>();
            marioStateValues.Add("Sprint2.MarioSmallState", 0);
            marioStateValues.Add("Sprint2.MarioSuperState", 1);
            marioStateValues.Add("Sprint2.MarioFireState", 2);
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
            marioTextures[0].Add(gameInstance.Content.Load<Texture2D>("MarioFacingLeft"));
            marioTextures[0].Add(gameInstance.Content.Load<Texture2D>("MarioFacingRight"));
            marioTextures[0].Add(gameInstance.Content.Load<Texture2D>("MarioJumpLeft"));
            marioTextures[0].Add(gameInstance.Content.Load<Texture2D>("MarioJumpRight"));
            marioTextures[0].Add(gameInstance.Content.Load<Texture2D>("MarioWalkingLeft"));
            marioTextures[0].Add(gameInstance.Content.Load<Texture2D>("MarioWalkingRight"));

            marioTextures[1].Add(gameInstance.Content.Load<Texture2D>("SuperMario/SMFacingLeft"));
            marioTextures[1].Add(gameInstance.Content.Load<Texture2D>("SuperMario/SMFacingRight"));
            marioTextures[1].Add(gameInstance.Content.Load<Texture2D>("SuperMario/SMJumpLeft"));
            marioTextures[1].Add(gameInstance.Content.Load<Texture2D>("SuperMario/SMJumpRight"));
            marioTextures[1].Add(gameInstance.Content.Load<Texture2D>("SuperMario/SMWalkingLeft"));
            marioTextures[1].Add(gameInstance.Content.Load<Texture2D>("SuperMario/SMWalkingRight"));

            marioTextures[2].Add(gameInstance.Content.Load<Texture2D>("FireMario/FMFacingLeft"));
            marioTextures[2].Add(gameInstance.Content.Load<Texture2D>("FireMario/FMFaceRight"));
            marioTextures[2].Add(gameInstance.Content.Load<Texture2D>("FireMario/FMJumpLeft"));
            marioTextures[2].Add(gameInstance.Content.Load<Texture2D>("FireMario/FMJumpRight"));
            marioTextures[2].Add(gameInstance.Content.Load<Texture2D>("FireMario/FMRunLeft"));
            marioTextures[2].Add(gameInstance.Content.Load<Texture2D>("FireMario/FMRunRight"));

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




        }

        public ISprite CreateLeftStandingMario(IMarioPowerUpState powerUpState)
        {
            String key = powerUpState.GetType().ToString();
            return new Sprite(marioTextures[marioStateValues[key]][0], 1, 1, 1);
        }

        public ISprite CreateRightStandingMario(IMarioPowerUpState powerUpState)
        {
            String key = powerUpState.GetType().ToString();
            return new Sprite(marioTextures[marioStateValues[key]][1], 1, 1, 1);
        }

        public ISprite CreateLeftJumpingMario(IMarioPowerUpState powerUpState)
        {
            String key = powerUpState.GetType().ToString();
            return new Sprite(marioTextures[marioStateValues[key]][2], 1, 1, 1);
        }

        public ISprite CreateRightJumpingMario(IMarioPowerUpState powerUpState)
        {
            String key = powerUpState.GetType().ToString();
            return new Sprite(marioTextures[marioStateValues[key]][3], 1, 1, 1);
        }

        public ISprite CreateLeftWalkingMario(IMarioPowerUpState powerUpState)
        {
            String key = powerUpState.GetType().ToString();
            return new Sprite(marioTextures[marioStateValues[key]][4], 1, 3, 3);
        }

        public ISprite CreateRightWalkingMario(IMarioPowerUpState powerUpState)
        {
            String key = powerUpState.GetType().ToString();
            return new Sprite(marioTextures[marioStateValues[key]][5], 1, 3, 3);
        }

        public ISprite CreateCoin()
        {
            return new Sprite(textures[0], 1, 3, 3);
        }
        public ISprite CreateStar()
        {
            return new Sprite(textures[1], 1, 4, 4);
        }

        public ISprite CreateGreenShroom()
        {
            return new Sprite(textures[2], 1, 1, 1);
        }

        public ISprite CreateRedShroom()
        {
            return new Sprite(textures[3], 1, 1, 1);
        }

        public ISprite CreateFlower()
        {
            return new Sprite(textures[4], 1, 4, 4);
        }

        public ISprite CreateGoomba()
        {
            return new Sprite(textures[5], 1, 2, 2);
        }

        public ISprite CreateStompedGoomba()
        {
            return new Sprite(textures[6], 1, 1, 1);
        }

        public ISprite CreatePipe()
        {
            return new Sprite(textures[7], 1, 1, 1);
        }
        public ISprite CreateKoopaLeft()
        {
            return new Sprite(textures[8], 1, 2, 2);
        }

        public ISprite CreateKoopaRight()
        {
            return new Sprite(textures[9], 1, 2, 2);
        }

        public ISprite CreateKoopaStomped()
        {
            return new Sprite(textures[10], 1, 2, 2);
        }

        public ISprite CreateKoopaFlipped()
        {
            return new Sprite(textures[11], 1, 2, 2);

        }

        public ISprite CreateBrickBlock()
        {
            return new Sprite(textures[12], 1, 1, 1);
        }

        public ISprite CreateFloorBlock()
        {
            return new Sprite(textures[13], 1, 1, 1);
        }

        public ISprite CreateMetalBlock()
        {
            return new Sprite(textures[14], 1, 1, 1);
        }



    }
}
