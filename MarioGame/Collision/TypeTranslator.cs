using Gamespace.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Collision
{
    class TypeTranslator
    {
        internal static (Type, Type) MarioBlockTranslator(IGameObject mario, IGameObject block)
        {
            IMario marioCast = (IMario)mario;
            return (marioCast.PowerUpState.GetType(), block.GetType());
        }
    }
}
