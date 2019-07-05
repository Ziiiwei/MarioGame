using Gamespace.Projectiles;
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
        void ChangeDirection();
        void MoveLeft();
        void MoveRight();
        void Remove();
    }
}
