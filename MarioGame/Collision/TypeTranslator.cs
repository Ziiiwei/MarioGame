using Gamespace.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal static class TypeTranslator
    {
        internal static (Type, Type) MarioBlockTranslator(IGameObject mario, IGameObject block)
        {
            IMario marioCast = (IMario)mario;
            IBlock blockCast = (IBlock)block;
            return (marioCast.PowerUpState.GetType(), blockCast.GetType());
        }
    }
}
