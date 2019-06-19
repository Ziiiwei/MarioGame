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
    internal class Camera
    {
        public Matrix Transform { get; private set; }
        private float offset;

        public Camera(Point location)
        {
            Transform = Matrix.CreateTranslation(new Vector3(-location.X, -location.Y, 0));
            offset = 0;
        }
        public Camera() : this(Point.Zero) { }
        public void LookAt(Point location)
        {
            Transform = Matrix.CreateTranslation(new Vector3(-location.X, -location.Y, 0));
            offset = 0;
        }

        public void Update()
        {
            if(World.Instance.Mario.PositionOnScreen.X >= Transform.Left.X + MarioGame.ScreenWidth / 4)
                MoveRight();
        }

        public void MoveRight()
        {
            Vector2 center = new Vector2(World.Instance.Mario.GetCenter().X - MarioGame.ScreenWidth / 4,
                World.Instance.Mario.GetCenter().Y - MarioGame.ScreenHeight / 4);
            Transform = Matrix.CreateTranslation(-center.X, 0/*-center.Y*/, 0);
            offset++;
        }
        



    }
}
