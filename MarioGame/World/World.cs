/* Idea for JSON layout taken from https://stackoverflow.com/questions/16339167/how-do-i-deserialize-a-complex-json-object-in-c-sharp-net
 * and from comments Dean made in class */
using Gamespace.Blocks;
using Gamespace.Goombas;
using Gamespace.Interfaces;
using Gamespace.Koopas;
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
        private readonly List<IGameObject> objectsToAdd;
        private readonly List<int> objectsToRemove;
        private readonly List<IGameObject> collisionMovers;
        private readonly List<IGameObject> collisionReceivers;
        private readonly List<Type> collisionMoverClassifier;
        public IMario Mario { get; set; }
        private readonly CollisionHandler collisionHandler;

        private World()
        {
            objectsInWorld = new Dictionary<int, IGameObject>();
            objectsToAdd = new List<IGameObject>();
            objectsToRemove = new List<int>();
            collisionMovers = new List<IGameObject>();
            collisionReceivers = new List<IGameObject>();

            collisionMoverClassifier = new List<Type>
            {
                typeof(Mario),
                typeof(Goomba),
                typeof(Koopa)
            };

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
        public void AddGameObject(IGameObject gameObject)
        {
            if (gameObject.GetType() == typeof(Mario))
            {
                Mario = (Mario)gameObject;
                collisionMovers.Add(gameObject);

            }
            else if (collisionMoverClassifier.Contains(gameObject.GetType()))
            {
                collisionMovers.Add(gameObject);
            }
            else
            {
                collisionReceivers.Add(gameObject);
            }
            objectsToAdd.Add(gameObject);
        }

        public void UpdateWorld()
        {
            foreach (IGameObject gameObject in objectsToAdd)
            {
                objectsInWorld.Add(gameObject.Uid, gameObject);
            }

            foreach (int i in objectsToRemove)
            {
                if (collisionMovers.Contains(objectsInWorld[i]))
                {
                    collisionMovers.Remove(objectsInWorld[i]);
                }
                else
                {
                    collisionReceivers.Remove(objectsInWorld[i]);
                }
                objectsInWorld.Remove(i);
            }

            objectsToAdd.Clear();
            objectsToRemove.Clear();



            /* The instigator is the first object, then target. */

            foreach (IGameObject gameObject in objectsInWorld.Values)
            {
                gameObject.Update();
            }

            foreach (IGameObject mover in collisionMovers)
            {
                foreach (IGameObject otherMover in collisionMovers)
                {
                    if (mover != otherMover)
                    {
                        collisionHandler.HandleCollision(mover, otherMover);
                    }
                }

                foreach (IGameObject receiver in collisionReceivers)
                {
                    collisionHandler.HandleCollision(mover, receiver);
                }
            }

           
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            foreach (IGameObject gameObject in objectsInWorld.Values)
            {
                gameObject.Draw(spriteBatch);
            }

      
        }

        public void RemoveFromWorld(int uid)
        {
            objectsToRemove.Add(uid);
        }

        // Thanks Kirby!
        public void ClearWorld()
        {
            this.objectsInWorld.Clear();
            this.objectsToAdd.Clear();
            this.objectsToRemove.Clear();
            this.collisionMovers.Clear();
            this.collisionReceivers.Clear();
        }
    }
}
