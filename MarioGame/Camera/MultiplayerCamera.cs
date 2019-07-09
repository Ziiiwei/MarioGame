﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class MultiplayerCamera : ICamera
    {
        public Matrix Transform { get; private set; }
        private Vector2 CameraPosition;
        private readonly int playerID;
        private readonly int yTransform;

        private MultiplayerCamera(Vector2 location)
        {
            Transform = Matrix.CreateTranslation(-location.X, yTransform, 0);
            //Transform = Matrix.CreateTranslation(-location.X + MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE), yTransform, 0);
            //CameraPosition.X = location.X - MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE);
            CameraPosition.X = location.X;
        }

        public MultiplayerCamera(int playerID, Vector2 initialPosition) : this(initialPosition)
        {
            this.playerID = playerID;
            yTransform = (MarioGame.WINDOW_HEIGHT / 2) * playerID;
        }

        public void Update(Vector2 position)
        {
            // now we just compare Mario's position with the Camera's left side plus half the screen
            //then we move the camera right, we may lock it here soon
            
            if (position.X >= CameraPosition.X + MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE))
            {
                MoveRight(position);
            }
            else
            {
                Transform = Matrix.CreateTranslation(-CameraPosition.X, yTransform, 0);
            }
                
        }

        private void MoveRight(Vector2 position)
        {
            Transform = Matrix.CreateTranslation(-position.X + MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE), yTransform, 0);
            //always set the position equal to Mario's position minus half the screen to keep him at half or below.
            CameraPosition.X = position.X - MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE);
        }
    }
}
