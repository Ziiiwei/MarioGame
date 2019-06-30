/* Idea for JSON layout taken from https://stackoverflow.com/questions/16339167/how-do-i-deserialize-a-complex-json-object-in-c-sharp-net
 * and from comments Dean made in class */
/* Help for using of OrderBy found here: https://stackoverflow.com/questions/188141/listt-orderby-alphabetical-order */
using Gamespace.Blocks;
using Gamespace.Goombas;
using Gamespace.Interfaces;
using Gamespace.Items;
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
        private Dictionary<int, IGameObject> objectsInWorld;
        private readonly List<IGameObject> objectsToAdd;
        private readonly List<int> objectsToRemove;
        private readonly List<IGameObject> collisionMovers;
        private readonly List<IGameObject> collisionReceivers;
        private readonly List<Type> collisionMoverClassifier;
        private readonly Dictionary<Type, int> collisionPriorities;
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
                typeof(Koopa),
                typeof(RedShroom),
                typeof(Fireball)
            };

            collisionPriorities = new Dictionary<Type, int>()
            {
                {typeof(Mario), 1},
                {typeof(Goomba), 2},
                {typeof(Koopa), 3},
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
            if (gameObject is Mario)
            {
                Mario = (Mario)gameObject;
            }

            objectsToAdd.Add(gameObject);
        }

        public void UpdateWorld()
        {
            foreach (IGameObject gameObject in objectsToAdd)
            {
                ClassifyNewObject(gameObject);
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

            var pendingCollisions = new Dictionary<IGameObject, List<(IGameObject, int)>>();

            //foreach (IGameObject mover in collisionMovers)
            for (int i = 0; i < collisionMovers.Count; i++)
            {
                IGameObject mover = collisionMovers[i];
                //foreach (IGameObject otherMover in collisionMovers)
                for (int j = i+1; j < collisionMovers.Count; j++)
                {
                    IGameObject otherMover = collisionMovers[j];

                    if (mover != otherMover)
                    {
                        (CollisionHandler.Side, Rectangle) collisionData = collisionHandler.DetectCollision(mover, otherMover);

                        if (collisionHandler.DetectCollision(mover, otherMover).Item1 != CollisionHandler.Side.None)
                        {
                            int collisionArea = collisionData.Item2.Height * collisionData.Item2.Width;
                            AddPendingCollision(pendingCollisions, mover, otherMover, collisionArea);
                        }

                    }
                }

                foreach (IGameObject receiver in collisionReceivers)
                {
                    (CollisionHandler.Side, Rectangle) collisionData = collisionHandler.DetectCollision(mover, receiver);

                    if (collisionHandler.DetectCollision(mover, receiver).Item1 != CollisionHandler.Side.None)
                    {
                        int collisionArea = collisionData.Item2.Height * collisionData.Item2.Width;
                        AddPendingCollision(pendingCollisions, mover, receiver, collisionArea);
                    }
                }
            }

            List<IGameObject> pendingCollisionsObjectsList = pendingCollisions.Keys.ToList().OrderBy(o => GetCollisionPriority(o)).ToList();

            foreach (IGameObject pendingCollisionKey in pendingCollisionsObjectsList)
            {
                pendingCollisions[pendingCollisionKey] = pendingCollisions[pendingCollisionKey].OrderByDescending(ca => ca.Item2).ToList();
            }

            for (int i = 0; i < pendingCollisionsObjectsList.Count; i++)
            {
                List<(IGameObject, int)> pendingTargets = pendingCollisions[pendingCollisionsObjectsList[i]];

                for (int j = 0; j < pendingTargets.Count; j++)
                {
                    collisionHandler.HandleCollision(pendingCollisionsObjectsList[i], pendingTargets[j].Item1);
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
            objectsInWorld.Clear();
            objectsToAdd.Clear();
            objectsToRemove.Clear();
            collisionMovers.Clear();
            collisionReceivers.Clear();
        }

        private void ClassifyNewObject(IGameObject gameObject)
        {
            if (collisionMoverClassifier.Contains(gameObject.GetType()))
            {
                collisionMovers.Add(gameObject);
            }
            else
            {
                collisionReceivers.Add(gameObject);
            }
        }

        private int GetCollisionPriority(IGameObject gameObject)
        {
            if (collisionPriorities.ContainsKey(gameObject.GetType()))
            {
                return collisionPriorities[gameObject.GetType()];
            }
            else
            {
                return 4;
            }
        }

        private void AddPendingCollision(Dictionary<IGameObject, List<(IGameObject, int)>> pendingCollisions, IGameObject mover, IGameObject target, int collisionArea)
        {
            if (!pendingCollisions.ContainsKey(mover))
            {
                List<(IGameObject, int)> collisionTargets = new List<(IGameObject, int)>() { (target, collisionArea) };
                pendingCollisions.Add(mover, collisionTargets);
            }
            else
            {
                pendingCollisions[mover].Add((target, collisionArea));
            }
        }
    
        public void MaskCollision(IGameObject gameObject)
        {
            if (collisionMovers.Contains(gameObject))
            {
                collisionMovers.Remove(gameObject);
            }
            else
            {
                collisionReceivers.Remove(gameObject);
            }
        }

        public void UnmaskCollision(IGameObject gameObject)
        {
            AddGameObject(gameObject);
        }

        public void Replace(IGameObject oldObject, IGameObject newObject)
        {
            /*This assertion helps with debugging the replace*/
            System.Diagnostics.Debug.Assert(objectsInWorld.ContainsKey(oldObject.Uid));
            /*This is mainly to manage decorators*/
            if(objectsInWorld.ContainsKey(newObject.Uid))
                RemoveFromWorld(newObject.Uid); /*They were In to begin with?*/
            RemoveFromWorld(oldObject.Uid);
            AddGameObject(newObject);
        }
    }
}
