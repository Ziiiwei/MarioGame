using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace.Items;
using Gamespace.Blocks;

namespace Gamespace
{
    class LevelLoader
    {
        public LevelLoader(World world)
        {
            world.Mario = new Mario(new Vector2(300, 200));

            world.AddGameObject(new Flower(new Vector2(125, 100)));
            world.AddGameObject(new Coin(new Vector2(175, 100)));
            world.AddGameObject(new RedShroom(new Vector2(225, 100)));
            world.AddGameObject(new GreenShroom(new Vector2(275, 100)));
            world.AddGameObject(new Star(new Vector2(325, 100)));
            world.AddGameObject(new Pipe(new Vector2(375, 150)));
            world.AddGameObject(new Block(new BrickBlockState(),new Vector2(375, 100)));
            world.AddGameObject(new Block(new HiddenBlockState(),new Vector2(425, 100)));
            world.AddGameObject(new Block(new UsedBlockState(), new Vector2(475, 100)));
            world.AddGameObject(new Block(new QuestionBlockState(), new Vector2(525, 100)));

        }
    }
}
