using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    interface ICamera
    {
        Matrix Transform { get; }
        void Update(Vector2 position);

        Vector2 Position();

    }
}
