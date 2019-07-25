using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace
{
    internal class MultiplayerCamera2 : ICamera
    {
        private int playerCountScale;
        private int xBound;
        private int yBound;
        private int xEpsilon;
        private int yEpsilon;
        private int frameDisplacement;
        private Viewport viewport;
        private Vector2 cameraPosition;
        public Vector2 CameraPosition { get => cameraPosition; }
        public Matrix Transform { get; private set; }
        bool recentering = false;
        IGameObject target;
        

        public MultiplayerCamera2(Viewport viewport, IGameObject target)
        {
            this.viewport = viewport;
            this.target = target;
            cameraPosition = new Vector2(target.PositionOnScreen.X - (viewport.Width / 2),
                 target.PositionOnScreen.Y - (viewport.Height / 2));
            Transform = Matrix.CreateTranslation(-cameraPosition.X, -cameraPosition.Y, 0);
            playerCountScale = (MarioGame.Instance.PlayerCount > 2) ? 2 : 1;
            xBound = 300 / playerCountScale;
            yBound = 150;
            xEpsilon = 100;
            yEpsilon = 100;
            frameDisplacement = 3;
        }

        public void Update(Vector2 position)
        {

            Rectangle centerBox = new Rectangle((int)CameraPosition.X + (viewport.Width / 2) - (xEpsilon / 2), (int)CameraPosition.Y + (viewport.Height / 2) - (yEpsilon / 2), xEpsilon, yEpsilon);

            if (!centerBox.Contains(position))
            {
                recentering = true;
            }
            else
            {
                recentering = false;
            }

            if (recentering)
            {
                Recenter(position);
            }

        }

        private void Recenter(Vector2 position)
        {
            float xTransform = 0;
            float yTransform = 0;


            recentering = true;

            if (position.X < CameraPosition.X + (viewport.Width / 2) - (xEpsilon / 2))
            {
               float t = position.X - (CameraPosition.X + (viewport.Width / 2) - (xEpsilon / 2));
                xTransform = -t/5;
                cameraPosition.X -= xTransform;
            }
            else
            {
                float t = position.X - (CameraPosition.X + (viewport.Width / 2) + (xEpsilon / 2));
                xTransform = t/5;
                cameraPosition.X += xTransform;
            }

            
            if (position.Y < CameraPosition.Y + (viewport.Height / 2) - (yEpsilon / 2))
            {
                float t = (CameraPosition.Y + (viewport.Height / 2) - (yEpsilon / 2)) - position.Y;
                yTransform = -t/10;
                cameraPosition.Y -= yTransform;
            }
            else
            {
                float t = position.Y - (CameraPosition.Y + (viewport.Height / 2) + (yEpsilon / 2));
                yTransform = t/10;
                cameraPosition.Y += yTransform;
            }
            
            Transform = Matrix.CreateTranslation(-cameraPosition.X + xTransform, -cameraPosition.Y + yTransform, 0);
        }

    }
}
