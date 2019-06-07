
using Gamespace.Blocks;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gamespace
{
    public class World
    {
        public List<IGameObject> objectsInWorld;

        public IMario Mario { get; set; }

        public Block Block1 { get; set; }
        public Block Block2 { get; set; }
        public Block Block3 { get; set; }

        private MarioGame game;
        private CollisionHandler collisionHandler;

        public World(MarioGame game)
        {
            this.game = game;
            objectsInWorld = new List<IGameObject>();
            collisionHandler = new CollisionHandler();
        }

        public void AddGameObject(IGameObject gameObject)
        {
            objectsInWorld.Add(gameObject);
        }

        public void UpdateWorld()
        {
            foreach (IGameObject gameObject in objectsInWorld)
            {
                gameObject.Update();
            }
            
            Mario.Update();
            Block1.Update();
            Block2.Update();
            Block3.Update();
            collisionHandler.HandleCollision(Mario, Block1);
        }

        [Obsolete]
        public void DrawWorld()
        {
            foreach (IGameObject gameObject in objectsInWorld)
            {
                gameObject.Draw(game.TheSpriteBatch);
            }

            Mario.Draw(game.TheSpriteBatch);
            Block1.Draw(game.TheSpriteBatch);
            Block2.Draw(game.TheSpriteBatch);
            Block3.Draw(game.TheSpriteBatch);
        }
    }
}
