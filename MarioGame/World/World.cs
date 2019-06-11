/* Idea for JSON layout taken from https://stackoverflow.com/questions/16339167/how-do-i-deserialize-a-complex-json-object-in-c-sharp-net
 * and from comments Dean made in class */
using Gamespace.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gamespace
{
    public class World
    {
        private static readonly World instance = new World();
        public Dictionary<int, IGameObject> objectsInWorld;
        private List<int> objectsToRemove;
        public IMario Mario { get; set; }
        private CollisionHandler collisionHandler;

        private World()
        {
            objectsInWorld = new Dictionary<int, IGameObject>();
            objectsToRemove = new List<int>();
            collisionHandler = new CollisionHandler();
        }

        static World()
        {
        }

        public static World Instance
        {
            get
            {
                return instance;
            }
        }
        public void AddGameObject(int uid, IGameObject gameObject)
        {
            if (gameObject.GetType() == typeof(Mario))
            {
                Mario = (Mario) gameObject;
            }
            else
            {
                objectsInWorld.Add(uid, gameObject);
            }
        }

        public void UpdateWorld()
        {
            foreach (int i in objectsToRemove)
            {
                objectsInWorld.Remove(i);
            }

            foreach (IGameObject gameObject in objectsInWorld.Values)
            {
                gameObject.Update();
            }
            
            Mario.Update();
            
            /* The instigator is the first object, then target */

            foreach (IGameObject obj in objectsInWorld.Values)
            {
                collisionHandler.HandleCollision(Mario, obj);
            }
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            foreach (IGameObject gameObject in objectsInWorld.Values)
            {
                gameObject.Draw(spriteBatch);
            }

            Mario.Draw(spriteBatch);
        }

        public void RemoveFromWorld(int uid)
        {
            objectsToRemove.Add(uid);
        }

        // Thanks Kirby!
        public void ClearWorld()
        {
            this.objectsInWorld.Clear();
            this.objectsToRemove.Clear();
        }
    }
}
