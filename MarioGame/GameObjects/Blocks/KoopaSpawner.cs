using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Koopas;
using Gamespace.Data;

namespace Gamespace.Blocks
{
    internal class KoopaSpawner : AbstractGameObject
    {
        private Random random;
        public KoopaSpawner(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            SetSprite();
            random = new Random();
            
        }

        protected override void SurrogateUpdate()
        {
            base.SurrogateUpdate();
            MaybeSpawn();
        }

        public void MaybeSpawn()
        {
            if (random.Next(3000) <= 10)
            {
                World.Instance.AddGameObject(new Koopa(this.positionOnScreen));
            }
        }
    }
}
