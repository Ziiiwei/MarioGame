using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Goombas;
using Gamespace.Data;

namespace Gamespace.Blocks
{
    public class Spawner : AbstractGameObject
    {
        public Spawner(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            World.Instance.AddSpawner(this);
            World.Instance.MaskCollision(this);
        }
    }
}
