using Microsoft.Xna.Framework;
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

        public MultiplayerCamera(Point location)
        {
            Vector2 position = new Vector2(0, 0);
            int y = (MarioGame.WINDOW_HEIGHT / 2) * playerID;
            Transform = Matrix.CreateTranslation(-position.X + MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE), y, 0);
            CameraPosition.X = position.X - MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE);
        }

        public MultiplayerCamera(int playerID) : this(new Point(0, (MarioGame.WINDOW_HEIGHT / 2) * playerID))
        {
            this.playerID = playerID;
        }

        public void Update(Vector2 position)
        {
            // now we just compare Mario's position with the Camera's left side plus half the screen
            //then we move the camera right, we may lock it here soon
            if (position.X >= CameraPosition.X + MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE))
                MoveRight(position);
        }



        private void MoveRight(Vector2 position)
        {
            int y = (MarioGame.WINDOW_HEIGHT / 2) * playerID;
            Transform = Matrix.CreateTranslation(-position.X + MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE), y, 0);
            //always set the position equal to Mario's position minus half the screen to keep him at half or below.
            CameraPosition.X = position.X - MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE);
        }
    }
}
