using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Data;

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

        public MultiplayerCamera(int playerID, Vector2 initialPosition, int playerCount)
        {
            this.playerID = playerID;
            this.playerCount = playerCount;

            xScale = (this.playerCount > 2) ? 2 : 1;
            float y = -initialPosition.Y + (MarioGame.WINDOW_HEIGHT / MarioGame.Instance.PlayerCount) / 2;

            Transform = Matrix.CreateTranslation(-initialPosition.X + MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * xScale), 0, 0);

            cameraPosition.X = initialPosition.X;
            cameraPosition.Y = initialPosition.Y;

        }

        public void Update(Vector2 position)
        {
            MoveRight(position);
        }

        private void MoveRight(Vector2 position)
        {
            float x = -position.X + (MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * xScale));
            float y = -position.Y + (MarioGame.WINDOW_HEIGHT / MarioGame.Instance.PlayerCount) / 2;

            Transform = Matrix.CreateTranslation(x, 0, 0);

            cameraPosition.X = position.X - MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * xScale);
            //cameraPosition.Y = position.Y - (MarioGame.WINDOW_HEIGHT / MarioGame.Instance.PlayerCount) / 2;
        }
    }
}
