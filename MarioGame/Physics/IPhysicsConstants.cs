using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    interface IPhysicsConstants
    {
        float GRAVITY  { get; }
        float FORCE_HORIZONTAL_AGAINST { get; }
        float GAMEOBJECT_FORCE_UP { get; }
        float GAMEOBJECT_FORCE_HORIZONTAL { get; }
        float MAX_HORIZONTAL_V { get; }
        float MAX_VERTICAL_V { get; }
    }
}
