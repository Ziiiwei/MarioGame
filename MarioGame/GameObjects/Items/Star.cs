using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;
using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace.Items
{
    class Star : AbstractGameObject, IItem, ICollidable
    {
        private static int[] bumpOffsets = { 4, 4, 4, 4, 4, 4, 4, 4 };
        private int bumpCounter = 0;

        public Star(Vector2 positionOnScreen) : base (positionOnScreen) 
        {
            SetSprite();
        }

        public void Consume()
        {
            World.Instance.RemoveFromWorld(Uid);
        }

        public override void Update()
        {
            base.Update();

            if (bumpCounter < bumpOffsets.Count())
            {
                positionOnScreen.Y -= bumpOffsets[bumpCounter];
                bumpCounter += 1;
            }
            else
            {
                GameObjectPhysics = PhysicsFactory.Instance.GetPhysics(this, positionOnScreen);
            }
                
            
        }
    }
}
