using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Goombas;
using Gamespace.Data;

namespace Gamespace.Blocks
{
    internal class GoombaSpawner : AbstractGameObject
    {
        private Random random;
        public GoombaSpawner(Vector2 positionOnScreen) : base(positionOnScreen)
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
            if (random.Next() % Numbers.SPAWN_LIMITER == 0)
                World.Instance.AddGameObject(new Goomba(this.positionOnScreen));
        }
    }
}
