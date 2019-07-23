using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    internal class MovingProjectileState : IProjectileState
    {
        protected IProjectile projectile;
        protected Dictionary<ShootAngle, Action> projectionActions;

        public MovingProjectileState(IProjectile projectile)
        {
            this.projectile = projectile;
            this.projectile.Angle = ShootAngle.None;
            projectionActions = new Dictionary<ShootAngle, Action>
            {
                {ShootAngle.Left,new Action(()=>projectile.State = new LeftMovingProjectile(projectile)) },
                {ShootAngle.Right, new Action(()=>projectile.State = new RightMovingProjectile(projectile))},
                {ShootAngle.Up, new Action(()=>projectile.State = new UpMovingProjectile(projectile))},
                {ShootAngle.LeftUp,new Action(()=>projectile.State = new LeftUpMovingProjectile(projectile))},
                {ShootAngle.RightUp, new Action(()=>projectile.State = new RightUpMovingProjectile(projectile))}
            };
        }
        public virtual void ChangeDirection(ShootAngle angle)
        {
            if (projectile.Angle!= angle)
            {
                projectionActions[angle].Invoke();
            }
        }
    }
}
