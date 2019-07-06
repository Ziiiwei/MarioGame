using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    internal class ProjectileLauncher : IFireable
    {
        private IMario gameObject;
        private int activeProjectiles = 0;
        private int maxProjectiles;
        private int delayBound;
        private int delayCounter = 0;
        private Type projectileClassification;

        public ProjectileLauncher(IMario mario)
        {
            gameObject = mario;
            maxProjectiles = 3;
            delayBound = 5;
            projectileClassification = typeof(Fireball);
        }

        public void Fire(Side side)
        {
            if (delayCounter % delayBound == 0)
            {
                Vector2 fireballPosition = new Vector2(gameObject.PositionOnScreen.X + gameObject.Sprite.Width,
                    gameObject.PositionOnScreen.Y + gameObject.Sprite.Height / 2);
                IProjectile projectile = (IProjectile)Activator.CreateInstance(projectileClassification, fireballPosition, side);
                World.Instance.AddGameObject(projectile);
                projectile.Move(side);
            }
            delayCounter++;
        }
    }
}
