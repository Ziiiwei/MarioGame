using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Gamespace
{
    public interface IPhysics
    {
        Vector2 position { get; set; }
        Vector2 velocity { get; set; }

        int acceleration { get; set; }

        void MoveLeft();
        void MoveRight();
        void FreeFall();
        void Jump();
        void SpeedUp();
        void SlowDown();
        void Stop();
        void Update();
    }
}
