using Gamespace.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MarioHitsEnemy : ICommand
    {
        private IGameObject enemy;
        private CollisionData collisionData;

        public MarioHitsEnemy(IGameObject enemy, CollisionData collisionData)
        {
            this.enemy = enemy;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            var enemyCast = (IEnemy)enemy;
            enemyCast.BeStomped();
        }
    }
}
