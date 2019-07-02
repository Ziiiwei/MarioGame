using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Sprites;

namespace Gamespace
{
    internal class Camera : ICamera
    {
        public Matrix Transform { get; private set; }
        private Vector2 CameraPosition;

        public Camera(Point location)
        {
            Transform = Matrix.CreateTranslation(new Vector3(-location.X, -location.Y, 0));
            CameraPosition = new Vector2();
        }
        public Camera() : this(Point.Zero) { }
        public void LookAt(Point location)
        {
            Transform = Matrix.CreateTranslation(new Vector3(-location.X, -location.Y, 0));
            CameraPosition = new Vector2();
        }

        public void Update(Vector2 position)
        {
            // now we just compare Mario's position with the Camera's left side plus half the screen
            //then we move the camera right, we may lock it here soon
            if(position.X >= CameraPosition.X + MarioGame.WINDOW_WIDTH /(2*MarioGame.SCALE))
                MoveRight(position);
        }
        
   

        private void MoveRight(Vector2 position)
        {
            Transform = Matrix.CreateTranslation(-position.X + MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE), 0, 0);
            //always set the position equal to Mario's position minus half the screen to keep him at half or below.
            CameraPosition.X = position.X - MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE);
        }
        



    }
}
