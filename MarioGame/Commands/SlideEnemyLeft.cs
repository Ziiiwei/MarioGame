using Gamespace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class SlideEnemyLeft : ICommand
    {
        IEnemy enemy;
        public SlideEnemyLeft(IEnemy enemy, CollisionData collisionData)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.SlideRight();
        }
    }
}
