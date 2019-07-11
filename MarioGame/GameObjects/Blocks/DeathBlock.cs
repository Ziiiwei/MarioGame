﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    internal class DeathBlock : AbstractGameObject
    {
        public DeathBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            SetSprite();
        }
    }
}