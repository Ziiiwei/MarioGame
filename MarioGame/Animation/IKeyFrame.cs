using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace.Commands;

namespace Gamespace.Animation
{
    public interface IKeyFrame<T>
    {
        T AnimatedObj { get;}
        Func<Vector2,int,Vector2,int,bool> GoalCheck { get; }

        Vector2 GoalPoint { get; }
        int GoalFrameCount { get; }
        ICommand ComandToCall { get; }
        void FrameFinished();
        void Update();

    }
}
