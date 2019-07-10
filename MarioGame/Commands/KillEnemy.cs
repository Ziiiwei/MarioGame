using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace.States;
using Gamespace.Interfaces;

namespace Gamespace.Commands
{
    internal class KillEnemy : ICommand
    {
        private IEnemy enemy;

        public KillEnemy(IEnemy enemy, CollisionData collisionData)
        {
            this.enemy = enemy;
        }

        public void Execute()
        {
            this.enemy.Die();
        }
    }
}

