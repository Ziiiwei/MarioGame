using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public class AbstractGameStatefulObject<T> : AbstractGameObject
    {

        private T state;
        public AbstractGameStatefulObject(Vector2 positionOnScreen) : base(positionOnScreen) {
            
        }
       
        public virtual void SetState(T state)
        {
            this.state = state; 
        }
    }
}
