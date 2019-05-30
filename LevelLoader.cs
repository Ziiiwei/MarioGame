﻿using Sprint2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class LevelLoader
    {
        public LevelLoader(World world)
        {
            world.Mario = new Mario(new Vector2(400, 200));
            world.AddGameObject(new FireFlower(new Vector2(50, 100)));
            world.AddGameObject(new Coin(new Vector2(100, 100)));
            world.AddGameObject(new RedMushroom(new Vector2(150, 100)));
            world.AddGameObject(new GreenMushroom(new Vector2(200, 100)));
            world.AddGameObject(new Star(new Vector2(250, 100)));

        }
    }
}
