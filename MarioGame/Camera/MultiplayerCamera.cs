using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Data;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace
{
    internal class  MultiplayerCamera : ICamera
    {
        public Matrix Transform { get; private set; }
        private Vector2 cameraPosition;
        public Vector2 CameraPosition { get => cameraPosition; }
        private readonly int playerID;
        private int playerCount;
        private int xScale;
        private Viewport viewport;
        private int softBoundary = 250;
        private int hardBoundary = 50;
        private int frameDisplacement = 4;
        private int frameDisplacementSpeedUp = 1;
        private int FrameDisplacement { get => Math.Max(frameDisplacement, frameDisplacementSpeedUp); }

        public MultiplayerCamera(int playerID, Vector2 initialPosition, int playerCount, Viewport viewport)
        {
            this.playerID = playerID;
            this.playerCount = playerCount;
            this.viewport = viewport;

            xScale = (this.playerCount > 2) ? 2 : 1;
            float y = -initialPosition.Y + (MarioGame.WINDOW_HEIGHT / MarioGame.Instance.PlayerCount) / 2;

            Transform = Matrix.CreateTranslation(-initialPosition.X + MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * xScale), 0, 0);

            cameraPosition.X = initialPosition.X;
            cameraPosition.Y = initialPosition.Y;

        }

        public void Update(Vector2 position)
        {
            if ((cameraPosition.X + viewport.Width) - softBoundary <= position.X)
            {
                if ((cameraPosition.X + viewport.Width) - hardBoundary <= position.X)
                {
                    frameDisplacementSpeedUp = 5;

                }
                xPush(position);
            }
            else if(cameraPosition.X + softBoundary >= position.X)
            {
                xDrag(position);
            }

        }

        private void yFollow(Vector2 position)
        {
            float y = -position.Y + (MarioGame.WINDOW_HEIGHT / MarioGame.Instance.PlayerCount) / 2;

            Transform = Matrix.CreateTranslation(0, y, 0);

            cameraPosition.Y = position.Y - (MarioGame.WINDOW_HEIGHT / MarioGame.Instance.PlayerCount) / 2;
        }

        private void xFollow(Vector2 position)
        {
            float x = -position.X + (MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * xScale));

            Transform = Matrix.CreateTranslation(x, 0, 0);

            cameraPosition.X = position.X - MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * xScale);
        }

        private void xPush(Vector2 position)
        {
            float x = -cameraPosition.X + FrameDisplacement;

            Transform = Matrix.CreateTranslation(x, 0, 0);

            cameraPosition.X = cameraPosition.X + FrameDisplacement;

            frameDisplacementSpeedUp = 1;
        }

        private void xDrag(Vector2 position)
        {
            float x = -cameraPosition.X - FrameDisplacement;

            Transform = Matrix.CreateTranslation(x, 0, 0);

            cameraPosition.X = cameraPosition.X - FrameDisplacement;

            frameDisplacementSpeedUp = 1;
        }

    }
}
