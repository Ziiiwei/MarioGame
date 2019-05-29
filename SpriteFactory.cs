﻿using System;
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
        private MarioGame gameInstance;

        static SpriteFactory()
        {
        }

        private SpriteFactory()
        {
            textures = new List<Texture2D>();
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
            textures.Add(gameInstance.Content.Load<Texture2D>("MarioFacingLeft"));
            textures.Add(gameInstance.Content.Load<Texture2D>("MarioFacingRight"));
            textures.Add(gameInstance.Content.Load<Texture2D>("MarioJumpLeft"));
            textures.Add(gameInstance.Content.Load<Texture2D>("MarioJumpRight"));
            textures.Add(gameInstance.Content.Load<Texture2D>("MarioWalkingLeft"));
            textures.Add(gameInstance.Content.Load<Texture2D>("MarioWalkingRight"));
            textures.Add(gameInstance.Content.Load<Texture2D>("Coin"));
            textures.Add(gameInstance.Content.Load<Texture2D>("Star"));
            textures.Add(gameInstance.Content.Load<Texture2D>("GreenShroom"));
            textures.Add(gameInstance.Content.Load<Texture2D>("RedShroom"));
            textures.Add(gameInstance.Content.Load<Texture2D>("Flower"));

        }

        public ISprite CreateLeftStandingMario()
        {
            return new Sprite(textures[0], 1, 1, 1);
        }

        public ISprite CreateRightStandingMario()
        {
            return new Sprite(textures[1], 1, 1, 1);
        }

        public ISprite CreateLeftJumpingMario()
        {
            return new Sprite(textures[2], 1, 1, 1);
        }

        public ISprite CreateRightJumpingMario()
        {
            return new Sprite(textures[3], 1, 1, 1);
        }

        public ISprite CreateLeftWalkingMario()
        {
            return new Sprite(textures[4], 1, 3, 3);
        }

        public ISprite CreateRightWalkingMario()
        {
            return new Sprite(textures[5], 1, 3, 3);
        }

        public ISprite CreateCoin()
        {
            return new Sprite(textures[6], 1, 3, 3);
        }
        public ISprite CreateStar()
        {
            return new Sprite(textures[7], 1, 4, 4);
        }

        public ISprite CreateGreenShroom()
        {
            return new Sprite(textures[8], 1, 1, 1);
        }

        public ISprite CreateRedShroom()
        {
            return new Sprite(textures[9], 1, 1, 1);
        }

        public ISprite CreateFlower()
        {
            return new Sprite(textures[10], 1, 4, 4);
        }





    }
}
