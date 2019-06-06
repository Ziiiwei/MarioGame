
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

        public Block HiddenBlock { get; set; }
        public Block BrickBlock { get; set; }
        public Block QuestionBlock { get; set; }

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
            HiddenBlock.Update();
            BrickBlock.Update();
            QuestionBlock.Update();
        }

        [Obsolete]
        public void DrawWorld()
        {
            foreach (IGameObject gameObject in objectsInWorld)
            {
                gameObject.Draw(game.TheSpriteBatch);
            }

            Mario.Draw(game.TheSpriteBatch);
            HiddenBlock.Draw(game.TheSpriteBatch);
            BrickBlock.Draw(game.TheSpriteBatch);
            QuestionBlock.Draw(game.TheSpriteBatch);

        }
    }
}
