/* Idea for JSON layout taken from https://stackoverflow.com/questions/16339167/how-do-i-deserialize-a-complex-json-object-in-c-sharp-net
 * and from comments Dean made in class */
/* Help for using of OrderBy found here: https://stackoverflow.com/questions/188141/listt-orderby-alphabetical-order */
using Gamespace.Blocks;
using Gamespace.Goombas;
using Gamespace.Interfaces;
using Gamespace.Items;
using Gamespace.Koopas;
using Gamespace.Multiplayer;
using Gamespace.Projectiles;
using Gamespace.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gamespace
{
    public partial class World
    {
        private static readonly World instance = new World();
        private readonly Dictionary<int, IGameObject> objectsInWorld;

        private readonly List<IGameObject> objectsToAdd;
        private readonly List<IPlayer> playersToAdd;

        private readonly List<IAnimation<IGameObject>> animationsToAdd;
        private readonly List<IAnimation<IGameObject>> animationsToPlay;

        private ISet<IGameObject> objectsToRemove;
        private List<IPlayer> playersToRemove;

        private readonly List<IGameObject> collisionMovers;
        private readonly List<IGameObject> collisionReceivers;
        private readonly List<Type> collisionMoverClassifier;
        private readonly Dictionary<Type, int> collisionPriorities;

        public bool worldIsPaused = false;

        public bool pendingAnimation = false;

        public IMario Mario { get; set; }
        public List<IPlayer> players;
        private readonly CollisionHandler collisionHandler;

        private World()
        {
            objectsInWorld = new Dictionary<int, IGameObject>();
            objectsToAdd = new List<IGameObject>();
            playersToAdd = new List<IPlayer>();
            objectsToRemove = new HashSet<IGameObject>();
            playersToRemove = new List<IPlayer>();
            collisionMovers = new List<IGameObject>();
            collisionReceivers = new List<IGameObject>();

            animationsToAdd = new List<IAnimation<IGameObject>>();
            animationsToPlay = new List<IAnimation<IGameObject>>();

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
                {typeof(Fireball), 1 },
                {typeof(Goomba), 2},
                {typeof(Koopa), 3},
            };

            collisionHandler = new CollisionHandler();

            players = new List<IPlayer>();
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
            objectsToAdd.Add(gameObject);
        }

        public void UpdatePlayers()
        {
            foreach (IPlayer player in playersToAdd)
            {
                players.Add(player);
            }

            foreach (IPlayer player in playersToRemove)
            {
                player.Release();
                players.Remove(player);
            }

            playersToAdd.Clear();
            playersToRemove.Clear();

            foreach (IPlayer player in players)
            {
                player.Update();
            }
        }

        public void UpdateWorld()
        {
            UpdateWaitingItems();

            foreach (IGameObject gameObject in objectsInWorld.Values)
            {
                gameObject.Update();
            }

            var pendingCollisions = GetPendingCollisions();

            List<IGameObject> pendingCollisionsObjectsList = pendingCollisions.Keys.ToList().OrderBy(o => GetCollisionPriority(o)).ToList();

            foreach (IGameObject pendingCollisionKey in pendingCollisionsObjectsList)
            {
                pendingCollisions[pendingCollisionKey] = pendingCollisions[pendingCollisionKey].OrderByDescending(collisionArea => collisionArea.Item2).ToList();
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

        public void RemoveFromWorld(IGameObject gameObject)
        {
            objectsToRemove.Add(gameObject);
        }

        private void UpdateWaitingItems()
        {


            foreach (IGameObject gameObject in objectsToAdd)
            {
                ClassifyNewObject(gameObject);
                objectsInWorld.Add(gameObject.Uid, gameObject);
            }

            foreach (IGameObject gameObject in objectsToRemove)
            {
                if (collisionMovers.Contains(objectsInWorld[gameObject.Uid]))
                {
                    collisionMovers.Remove(objectsInWorld[gameObject.Uid]);
                }
                else
                {
                    collisionReceivers.Remove(objectsInWorld[gameObject.Uid]);
                }
                objectsInWorld.Remove(gameObject.Uid);
            }
            objectsToAdd.Clear();
            objectsToRemove.Clear();
        }

        private Dictionary<IGameObject, List<(IGameObject, int)>> GetPendingCollisions()
        {
            var pendingCollisions = new Dictionary<IGameObject, List<(IGameObject, int)>>();

            for (int i = 0; i < collisionMovers.Count; i++)
            {
                IGameObject mover = collisionMovers[i];
                for (int j = 0; j < collisionMovers.Count; j++)
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
            return pendingCollisions;
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
                RemoveFromWorld(newObject); /*They were In to begin with?*/
            RemoveFromWorld(oldObject);
            AddGameObject(newObject);
        }

        public void AddPlayer(IPlayer player)
        {
            playersToAdd.Add(player);
            AddGameObject(player.GameObject);
        }

        public void DrawPlayers()
        {
            foreach (IPlayer player in players)
            {
                player.DrawPlayersScreen();
            }
        }

        public void ClearWorld()
        {
            objectsToAdd.Clear();
            playersToAdd.Clear();
            objectsToRemove = objectsInWorld.Values.ToHashSet();
            playersToRemove = new List<IPlayer>(players);
            collisionMovers.Clear();
            collisionReceivers.Clear();
        }

        public void PauseAllObjects()
        {
            worldIsPaused = !worldIsPaused;

            foreach (IGameObject gameObject in objectsInWorld.Values)
            {
                gameObject.IsPaused = worldIsPaused;
            }
        }
    }
}
