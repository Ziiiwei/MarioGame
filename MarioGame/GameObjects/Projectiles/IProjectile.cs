using Gamespace.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    interface IProjectile : IGameObject
    {
        IProjectileState State { get; set; }
        ShootAngle Angle { get; set; }
        void ChangeDirection(ShootAngle angle);
        void Shoot(ShootAngle angle, Vector2 initialV, Vector2 initialP);
        void Remove();
        void OwnerScores();
        void SetOwner(IMario owner);
    }
}
