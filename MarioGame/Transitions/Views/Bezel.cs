﻿using Gamespace.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public class Bezel : IView
    {
        private int playerCount;
        private GraphicsDevice graphicsDevice;
        private Texture2D horizontalBezel;
        private Texture2D verticalBezel;
        private List<Tuple<Texture2D, Rectangle>> drawable;
        private Dictionary<int, Delegate> playerIndexToDraw;


        public Bezel(int playerID, int playerCount, GraphicsDevice graphicsDevice)
        {
            this.playerCount = playerCount;
            this.graphicsDevice = graphicsDevice;

            drawable = new List<Tuple<Texture2D, Rectangle>>();

            horizontalBezel = new Texture2D(graphicsDevice, MarioGame.WINDOW_WIDTH / 2, 1);
            verticalBezel = new Texture2D(graphicsDevice, 1, MarioGame.WINDOW_HEIGHT / 2);

            Color[] colorDataHorizontal = new Color[MarioGame.WINDOW_WIDTH / 2];

            for (int i = 0; i < colorDataHorizontal.Length; i++)
            {
                colorDataHorizontal[i] = Color.Black;
            }

            Color[] colorDataVertical = new Color[MarioGame.WINDOW_HEIGHT / 2];

            for (int i = 0; i < colorDataVertical.Length; i++)
            {
                colorDataVertical[i] = Color.Black;
            }
            
            horizontalBezel.SetData(colorDataHorizontal);
            verticalBezel.SetData(colorDataVertical);

            playerIndexToDraw = new Dictionary<int, Delegate>()
            {
                {0, new Action(() => PlayerOneBezel()) },
                {1, new Action(() => PlayerTwoBezel()) },
                {2, new Action(() => PlayerThreeBezel()) },
                {3, new Action(() => PlayerFourBezel()) }
            };

            playerIndexToDraw[playerID].DynamicInvoke();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tuple<Texture2D, Rectangle> line in drawable)
            {
                spriteBatch.Draw(line.Item1, line.Item2, null, Color.Black);
            }
        }

        private void PlayerOneBezel()
        {
            Rectangle verticalRectangle = new Rectangle((MarioGame.WINDOW_WIDTH / 4) - 1, 0, 1, MarioGame.WINDOW_HEIGHT / 2);

            if (playerCount < 3)
            {
                Rectangle horizontalRectangle = new Rectangle(0, (MarioGame.WINDOW_HEIGHT / 2) - 1, MarioGame.WINDOW_WIDTH, 1);
                drawable.Add(new Tuple<Texture2D, Rectangle>(horizontalBezel, horizontalRectangle));
            } else
            {
                Rectangle horizontalRectangle = new Rectangle(0, (MarioGame.WINDOW_HEIGHT / 2) - 1, MarioGame.WINDOW_WIDTH / 2, 1);
                drawable.Add(new Tuple<Texture2D, Rectangle>(horizontalBezel, horizontalRectangle));
                drawable.Add(new Tuple<Texture2D, Rectangle>(verticalBezel, verticalRectangle));
            }
        }

        private void PlayerTwoBezel()
        {

        }

        private void PlayerThreeBezel()
        {

        }

        private void PlayerFourBezel()
        {

        }
    }
}
