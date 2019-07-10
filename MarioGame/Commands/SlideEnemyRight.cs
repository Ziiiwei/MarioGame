using Gamespace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class SlideEnemyRight : ICommand
    {
        private IEnemy enemy;
        public SlideEnemyRight(IEnemy enemy, CollisionData collisionData)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
             enemy.SlideRight();
        }
    }
}
