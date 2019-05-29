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
        private List<IGameObject> objectsInWorld;
        public IMario Mario { get; set; }
        private MarioGame game;

        public World(MarioGame game)
        {
            this.game = game;
            objectsInWorld = new List<IGameObject>();
            Mario = new Mario(new Vector2(200, 200));
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
        }

        public void DrawWorld()
        {
            foreach (IGameObject gameObject in objectsInWorld)
            {
                gameObject.Draw(game.TheSpriteBatch);
            }
            Mario.Draw(game.TheSpriteBatch);
            
        }
    }
}
