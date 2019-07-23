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

        private MultiplayerCamera(Vector2 location)
        {
            float y = -location.Y + (MarioGame.WINDOW_HEIGHT / MarioGame.Instance.PlayerCount) / 2;

            Transform = Matrix.CreateTranslation(-location.X + MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * MarioGame.SCALE), 0, 0);

            cameraPosition.X = location.X;
        }

        public MultiplayerCamera(int playerID, Vector2 initialPosition) : this(initialPosition)
        {
            this.playerID = playerID;
        }

        public void Update(Vector2 position)
        {
            MoveRight(position);
        }

        private void MoveRight(Vector2 position)
        {
            float y = -position.Y + (MarioGame.WINDOW_HEIGHT / MarioGame.Instance.PlayerCount) / 2;

            Transform = Matrix.CreateTranslation(-position.X + MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * MarioGame.SCALE), 0, 0);

            cameraPosition.X = position.X - MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * MarioGame.SCALE);
        }
    }
}
