using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class World
    {
        public List<IGameObject> objectsInWorld;

        public List<IBlocks> blocksInWorld;
        public IMario Mario { get; set; }
        public Goomba TheGoomba { get; set; }
        public Koopa TheKoopa { get; set; }
        private MarioGame game;

        public World(MarioGame game)
        {
            this.game = game;
            objectsInWorld = new List<IGameObject>();
            blocksInWorld = new List<IBlocks>();
            
           
        }

        public void AddGameObject(IGameObject gameObject)
        {
            objectsInWorld.Add(gameObject);
        }

        public void AddBlocks(IBlocks block)
        {
            blocksInWorld.Add(block);
        }

        public void UpdateWorld()
        {
            foreach (IGameObject gameObject in objectsInWorld)
            {
                gameObject.Update();
            }

            foreach (IBlocks block in blocksInWorld)
            {
                block.Update();
            }
            Mario.Update();
            TheGoomba.Update();
            TheKoopa.Update();
        }

        [Obsolete]
        public void DrawWorld()
        {
            foreach (IGameObject gameObject in objectsInWorld)
            {
                gameObject.Draw(game.TheSpriteBatch);
            }

            foreach (IBlocks block in blocksInWorld)
            {
                block.Draw(game.TheSpriteBatch);
            }
            Mario.Draw(game.TheSpriteBatch);
            TheGoomba.Draw(game.TheSpriteBatch);
            TheKoopa.Draw(game.TheSpriteBatch);


        }
    }
}
