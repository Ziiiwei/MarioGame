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
        private readonly int yTransform;

        private MultiplayerCamera(Vector2 location)
        {
            Transform = Matrix.CreateTranslation(-location.X, yTransform, 0);
            cameraPosition.X = location.X;
        }

        public MultiplayerCamera(int playerID, Vector2 initialPosition) : this(initialPosition)
        {
            this.playerID = playerID;
            yTransform = (MarioGame.WINDOW_HEIGHT / Numbers.CAMERA_FACTOR) * playerID;
        }

        public void Update(Vector2 position)
        {
            // now we just compare Mario's position with the Camera's left side plus half the screen
            //then we move the camera right, we may lock it here soon
            

            MoveRight(position);
 
        }

        private void MoveRight(Vector2 position)
        {
            //Since the scale is being doubled, I do not believe this is an example of a magic number
            Transform = Matrix.CreateTranslation(-position.X + MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * MarioGame.SCALE), 0, 0);
            //always set the position equal to Mario's position minus half the screen to keep him at half or below.
            cameraPosition.X = position.X - MarioGame.WINDOW_WIDTH / (Numbers.CAMERA_FACTOR * MarioGame.SCALE);
        }
    }
}
