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
    //Collision related function in this part
    {
        private Dictionary<IGameObject, List<(IGameObject, int)>> GetPendingCollisions()
        {
            var pendingCollisions = new Dictionary<IGameObject, List<(IGameObject, int)>>();


            Action<int, IGameObject> collisionColumnDetection = (column, mover) =>
            {
                List<IGameObject> collisionColumn = collisionColumns[column];
                for (int j = 0; j < collisionColumn.Count; j++)
                {
                    IGameObject target = collisionColumn[j];

                    if (mover != target)
                    {
                        Tuple<CollisionHandler.Side, Rectangle> collisionData = collisionHandler.DetectCollision(mover, target);

                        if (collisionData.Item1 != CollisionHandler.Side.None)
                        {
                            int collisionArea = collisionData.Item2.Height * collisionData.Item2.Width;
                            AddPendingCollision(pendingCollisions, mover, target, collisionArea);
                        }
                    }
                }
            };

            List<int> columnsToCheck = new List<int>() { -1, 0, 1 };

            for (int i = 0; i < collisionMovers.Count; i++)
            {
                IGameObject mover = collisionMovers[i];

                foreach (int column in columnsToCheck)
                {
                    int columnToCheck = Math.Max(0, mover.BlockSpacePosition + column);
                    collisionColumnDetection(columnToCheck, mover);
                }

            }

            return pendingCollisions;

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
    }
}
