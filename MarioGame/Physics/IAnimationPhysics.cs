using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public interface IAnimationPhysics
    {
        void IncrementMove(Side side,int distance);
        void FuctionMove(Func<Vector2, Vector2> trajectory);

    }
}
