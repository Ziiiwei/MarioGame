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

        public Camera(Point location)
        {
            Transform = Matrix.CreateTranslation(new Vector3(-location.X, 0, 0));
        }
        public Camera() : this(Point.Zero) { }
        public void LookAt(Point location)
        {
            Transform = Matrix.CreateTranslation(new Vector3(-location.X, 0, 0));
        }

        public void Update()
        {
            float _dX = World.Instance.Mario.GetCenter().X - MarioGame.ScreenWidth / 4;
            float current_X = World.Instance.Mario.GetCenter().X + Transform.M14;
            if (_dX > -Transform.M14 && current_X > MarioGame.ScreenWidth / 4)
            {
                Transform = Matrix.CreateTranslation(-_dX, 0, 0);
            }
            
        }
        



    }
}
