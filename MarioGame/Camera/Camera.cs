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

        public void Update(IMario gameObject)
        {
            // now we just compare Mario's position with the Camera's left side plus half the screen
            //then we move the camera right, we may lock it here soon
            if(gameObject.PositionOnScreen.X >= CameraPosition.X + MarioGame.WINDOW_WIDTH /(2*MarioGame.SCALE))
                MoveRight(gameObject.PositionOnScreen);
            if (gameObject.PositionOnScreen.X <= CameraPosition.X)
                Lock(gameObject);
        }
        
   

        private void MoveRight(Vector2 position)
        {
            Transform = Matrix.CreateTranslation(-position.X + MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE), 0, 0);
            //always set the position equal to Mario's position minus half the screen to keep him at half or below.
            CameraPosition.X = position.X - MarioGame.WINDOW_WIDTH / (2 * MarioGame.SCALE);
        }

        private void Lock(IMario gameObject)
        {
            // The simplest way to do this is to  force the mario to collide left, magic numbers need to be removed
            gameObject.CollideLeft(new Rectangle((int)CameraPosition.X - 16,0,8,MarioGame.WINDOW_HEIGHT));
        }
        



    }
}
