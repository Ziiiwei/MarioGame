using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    interface IPhysicsConstants
    {
        float G { get; }
        float A { get; }
        float MAX_X_V { get; }
        float MAX_Y_V { get; }
        float FRICTION { get; }
    }
}
