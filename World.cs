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
        public Goomba TheGoomba { get; set; }
        public Koopa TheKoopa { get; set; }
        private MarioGame game;

        public World(MarioGame game)
        {
            this.game = game;
            objectsInWorld = new List<IGameObject>();
            Mario = new Mario(new Vector2(200, 200));
            TheGoomba = new Goomba(new Vector2(300, 300));
            TheKoopa = new Koopa(new Vector2(300, 400));
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
            Mario.Draw(game.TheSpriteBatch);
            TheGoomba.Draw(game.TheSpriteBatch);
            TheKoopa.Draw(game.TheSpriteBatch);


        }
    }
}
