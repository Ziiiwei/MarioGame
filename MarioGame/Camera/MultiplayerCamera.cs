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
        private Viewport viewport;
        int playerScale = (MarioGame.Instance.PlayerCount > 2) ? 2 : 1;
        private int softXBoundary = 300;
        private int softYBoundary = 80;
        private int frameDisplacement = 4;
        private int frameDisplacementSpeedUp = 1;
        private int FrameDisplacement { get => Math.Max(frameDisplacement, frameDisplacementSpeedUp); }

        public MultiplayerCamera(int playerID, Vector2 initialPosition, int playerCount, Viewport viewport)
        {
            this.playerID = playerID;
            this.playerCount = playerCount;
            this.viewport = viewport;

            softXBoundary /= playerScale;
            softYBoundary /= playerScale;

            float y = -initialPosition.Y + (MarioGame.WINDOW_HEIGHT / MarioGame.Instance.PlayerCount) / 2;

            //Transform = Matrix.CreateTranslation(-initialPosition.X + MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * xScale), 0, 0);

            cameraPosition.X = initialPosition.X;
            cameraPosition.Y = initialPosition.Y;

        }

        public void Update(Vector2 position)
        {
            if ((cameraPosition.X + viewport.Width) - softXBoundary <= position.X)
            {
                xForward(position);
            }
            else if(cameraPosition.X + softXBoundary >= position.X)
            {
                xBackward(position);
            }
            
            if (position.Y < (cameraPosition.Y + softYBoundary) ||
                position.Y > (cameraPosition.Y + MarioGame.WINDOW_HEIGHT - softYBoundary) / (2 * playerScale))
            {
                if ((cameraPosition.Y + MarioGame.WINDOW_HEIGHT + softYBoundary) / (4 * playerScale) > position.Y)
                {
                    yUp(position);
                }
                else if ((cameraPosition.Y + MarioGame.WINDOW_HEIGHT - softYBoundary) / (4 * playerScale) < position.Y)
                {
                    yDown(position);
                }
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
            float x = -position.X + (MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * playerScale));

            Transform = Matrix.CreateTranslation(x, 0, 0);

            cameraPosition.X = position.X - MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * playerScale);
        }

        private void xForward(Vector2 position)
        {
            float x = -cameraPosition.X + FrameDisplacement;
            float delta = position.X - (cameraPosition.X + viewport.Width - softXBoundary);

            if ((delta > 0) && delta < FrameDisplacement)
            {
                cameraPosition.X += delta;
                Transform = Matrix.CreateTranslation(-cameraPosition.X + delta, Transform.Translation.Y, 0);
            } else
            {
                cameraPosition.X += FrameDisplacement;
                Transform = Matrix.CreateTranslation(x, Transform.Translation.Y, 0);
            }

            frameDisplacementSpeedUp = 1;
        }

        private void xBackward(Vector2 position)
        {
            float x = -cameraPosition.X - FrameDisplacement;
            float delta = (cameraPosition.X + softXBoundary) - position.X;

            if ((delta > 0) && delta < FrameDisplacement)
            {
                cameraPosition.X -= delta;
                Transform = Matrix.CreateTranslation(-cameraPosition.X - delta, Transform.Translation.Y, 0);
            }
            else
            {
                cameraPosition.X -= FrameDisplacement;
                Transform = Matrix.CreateTranslation(x, Transform.Translation.Y, 0);
            }

            frameDisplacementSpeedUp = 1;
        }

        private void yUp(Vector2 position)
        {
            if(true)
            //if (((int)position.Y) != cameraPosition.Y + MarioGame.WINDOW_HEIGHT / 2)
            {
                float y = -cameraPosition.Y - FrameDisplacement;

                cameraPosition.Y -= FrameDisplacement;
                Transform = Matrix.CreateTranslation(Transform.Translation.X, y, 0);

                frameDisplacementSpeedUp = 1;
            }
        }

        private void yDown(Vector2 position)
        {
            if(true)
            //if (((int)position.Y) != cameraPosition.Y + MarioGame.WINDOW_HEIGHT / 4)
            {
                float y = -cameraPosition.Y + FrameDisplacement;

                cameraPosition.Y += FrameDisplacement;
                Transform = Matrix.CreateTranslation(Transform.Translation.X, y, 0);

                frameDisplacementSpeedUp = 1;
            }
        }

    }
}
