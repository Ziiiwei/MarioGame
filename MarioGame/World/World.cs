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
using Gamespace.Data;

namespace Gamespace
{
    public partial class World
    //core function, constructor and main update and draw in this part
    {
        private static readonly World instance = new World();
      
      
        private readonly List<IGameObject> objectsToAdd;
        private readonly List<IPlayer> playersToAdd;
        private readonly List<IGameObject> objectsToAddToUpdate;

        private readonly List<IGameObject> objectsToUpdate;
        private readonly List<IGameObject> objectsToDraw;

        private readonly List<IAnimation<IGameObject>> animationsToAdd;
        private readonly List<IAnimation<IGameObject>> animationsToPlay;
        private readonly List<IAnimation<IGameObject>> animationsToDelete;


        private List<IGameObject> objectsToRemoveFromUpdate;
        private ISet<IGameObject> objectsToRemove;
        private List<IPlayer> playersToRemove;

        private readonly List<IGameObject> collisionMovers;
        private readonly List<IGameObject> collisionReceivers;
        private readonly List<Type> collisionMoverClassifier;
        private readonly Dictionary<Type, int> collisionPriorities;

        private readonly List<List<IGameObject>> collisionColumns;

        private bool worldIsPaused = false;

   
        public List<IPlayer> players;
        private readonly CollisionHandler collisionHandler;

        private World()
        {
          
            objectsToAdd = new List<IGameObject>();
            playersToAdd = new List<IPlayer>();
            objectsToAddToUpdate = new List<IGameObject>();
            objectsToRemove = new HashSet<IGameObject>();
            playersToRemove = new List<IPlayer>();
            objectsToRemoveFromUpdate = new List<IGameObject>();
            collisionMovers = new List<IGameObject>();
            collisionReceivers = new List<IGameObject>();

            collisionColumns = new List<List<IGameObject>>();
            // This magic number has to go.
            for (int i = 0; i < 207; i++)
            {
                collisionColumns.Add(new List<IGameObject>());
            }

            objectsToUpdate = new List<IGameObject>();
            objectsToDraw = new List<IGameObject>();

            animationsToAdd = new List<IAnimation<IGameObject>>();
            animationsToPlay = new List<IAnimation<IGameObject>>();
            animationsToDelete = new List<IAnimation<IGameObject>>();

            collisionMoverClassifier = new List<Type>
            {
                typeof(Mario),
                typeof(Goomba),
                typeof(Koopa),
                typeof(RedShroom),
                typeof(GreenShroom),
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
            collisionColumns[gameObject.BlockSpacePosition].Add(gameObject);
        }

        public void UpdatePlayers(GameTime gameTime)
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
                player.Update(gameTime);
            }
        }

        public void UpdateWorld()
        {
            UpdateWaitingItems();

            foreach (List<IGameObject> collisionsColumn in collisionColumns)
            {
                collisionsColumn.Clear();
            }

            foreach (IAnimation<IGameObject> animation in animationsToPlay)
            {
                animation.Play();
            }

            foreach (IGameObject gameObject in objectsToUpdate)
            {
                gameObject.Update();
                collisionColumns[gameObject.BlockSpacePosition].Add(gameObject);
            }

            var pendingCollisions = GetPendingCollisions();

            List<IGameObject> pendingCollisionsObjectsList = pendingCollisions.Keys.ToList().OrderBy(o => GetCollisionPriority(o)).ToList();

            foreach (IGameObject pendingCollisionKey in pendingCollisionsObjectsList)
            {
                pendingCollisions[pendingCollisionKey] = pendingCollisions[pendingCollisionKey].OrderByDescending(collisionArea => collisionArea.Item2).ToList();
            }

            for ( int i = 0; i < pendingCollisionsObjectsList.Count; i++)
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
            List<IGameObject> deferredDraw = new List<IGameObject>();

            foreach (IGameObject gameObject in objectsToDraw)
            {
                if (gameObject.DrawPriority == Numbers.FOREGROUND_DRAW_PRIORITY)
                {
                    deferredDraw.Add(gameObject);
                }
                else
                {
                    gameObject.Draw(spriteBatch);
                }
            }

            foreach (IGameObject gameObject in deferredDraw)
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

                objectsToUpdate.Add(gameObject);
                objectsToDraw.Add(gameObject);

            }

            foreach (IGameObject gameObject in objectsToRemoveFromUpdate)
            {
                if (objectsToUpdate.Contains(gameObject))
                {
                    objectsToUpdate.Remove(gameObject);
                }
            }

            foreach (IGameObject gameObject in objectsToAddToUpdate)
            {
                if (!objectsToUpdate.Contains(gameObject))
                {
                    objectsToUpdate.Add(gameObject);
                }
            }

            foreach (IGameObject gameObject in objectsToRemove)
            {
                if (collisionMovers.Contains(gameObject))
                {
                    collisionMovers.Remove(gameObject);
                }
                else
                {
                    collisionReceivers.Remove(gameObject);
                }
                
                if (objectsToUpdate.Contains(gameObject))
                {
                    objectsToUpdate.Remove(gameObject);
                }

                if (objectsToDraw.Contains(gameObject))
                {
                    objectsToDraw.Remove(gameObject);
                }
            }

            foreach (IAnimation<IGameObject> animation in animationsToAdd)
            {
                animationsToPlay.Add(animation);
            }

            foreach (IAnimation<IGameObject> animation in animationsToDelete)
            {
                if (animationsToPlay.Contains(animation))
                {
                    animationsToPlay.Remove(animation);
                }
            }

            animationsToAdd.Clear();
            animationsToDelete.Clear();
            objectsToAddToUpdate.Clear();
            objectsToRemoveFromUpdate.Clear();
            objectsToAdd.Clear();
            objectsToRemove.Clear();
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
            objectsToRemove = objectsToUpdate.Concat(objectsToDraw).ToHashSet();
            playersToRemove = new List<IPlayer>(players);
            collisionMovers.Clear();
            collisionReceivers.Clear();
            animationsToAdd.Clear();
            animationsToDelete.Clear();
            objectsToAddToUpdate.Clear();
            objectsToRemoveFromUpdate.Clear();
            animationsToPlay.Clear();
        }

        public void PauseAllObjects()
        {
            worldIsPaused = !worldIsPaused;

            foreach (IGameObject gameObject in objectsToUpdate)
            {
                gameObject.IsPaused = worldIsPaused;
            }
        }
    }
}
