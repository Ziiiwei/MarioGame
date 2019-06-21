﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class HiddenBlock : AbstractGameObject, IBlock
    {
        public HiddenBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {

        }

    }
}