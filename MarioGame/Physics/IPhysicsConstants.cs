using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public interface IPhysicsConstants
    {
        float gravityConstant { get; }
        float accelConstant { get; }
        float max_X_V { get; }
        float max_Y_V { get; }
        float frictionConstant{ get; }
    }
}
