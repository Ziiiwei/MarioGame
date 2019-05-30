using Sprint2;
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
            world.Mario = new Mario(new Vector2(300, 200));
            world.TheGoomba = new Goomba(new Vector2(300, 300));
            world.TheKoopa = new Koopa(new Vector2(300, 400));

            world.AddGameObject(new FireFlower(new Vector2(125, 100)));
            world.AddGameObject(new Coin(new Vector2(175, 100)));
            world.AddGameObject(new RedMushroom(new Vector2(225, 100)));
            world.AddGameObject(new GreenMushroom(new Vector2(275, 100)));
            world.AddGameObject(new Star(new Vector2(325, 100)));
            world.AddGameObject(new Pipe(new Vector2(375, 150)));
            world.AddGameObject(new BrickBlock(new Vector2(375, 100)));
            world.AddGameObject(new FloorBlock(new Vector2(425, 100)));
            world.AddGameObject(new MetalBlock(new Vector2(475, 100)));

            world.AddBlocks(new CoinBlock(new Vector2(525, 100)));

        }
    }
}
