using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    public interface ILauncher
    {
        int MaxProjectiles { get; set; }

        int RemainingAmmo { get; }
        void Update();
        void Fire(ShootAngle angle);
    }
}
