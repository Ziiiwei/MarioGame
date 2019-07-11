using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Data;

namespace Gamespace.Projectiles
{
    internal class ProjectileLauncher : IFireable
    {
        private IMario gameObject;
        private int activeProjectiles = 0;
        private int maxProjectiles;
        private int delayBound;
        private int delayCounter;
        private Type projectileClassification;
        private static Dictionary<Side, Func<IMario, float>> spawnOffset;

        public ProjectileLauncher(IMario mario)
        {
            gameObject = mario;
            maxProjectiles = Numbers.MAX_PROJECTILES;
            delayBound = Numbers.DELAY_BOUND;
            projectileClassification = typeof(Fireball);

            spawnOffset = new Dictionary<Side, Func<IMario, float>>()
            {
                {Side.Left, (gameObject) => {return Numbers.PROJECTILE_LEFT_OFFSET; } },
                {Side.Right, (gameObject) => { return gameObject.Sprite.Width; } }
            };
        }

        public void Fire(Side side)
        {
            if (delayCounter % delayBound == 0)
            {
                Vector2 fireballPosition = new Vector2(gameObject.PositionOnScreen.X + spawnOffset[side].Invoke(gameObject),
                    gameObject.PositionOnScreen.Y + gameObject.Sprite.Height / 2);
                IProjectile projectile = (IProjectile)Activator.CreateInstance(projectileClassification, fireballPosition, side);
                World.Instance.AddGameObject(projectile);
                projectile.Move(side);
            }
            delayCounter++;
        }
    }
}
