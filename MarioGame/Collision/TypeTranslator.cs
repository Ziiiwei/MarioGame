using Gamespace.Blocks;
using Gamespace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Collision
{
    class TypeTranslator
    {
        internal static (Type, Type) MarioBlockTranslator(IGameObject mover, IGameObject receiver)
        {
            IMario marioCast;
            if (mover.GetType() == typeof(Mario))
            {
                marioCast = (IMario)mover;
                return (marioCast.PowerUpState.GetType(), receiver.GetType());
            }
            marioCast = (IMario)receiver;
            return (marioCast.PowerUpState.GetType(), mover.GetType());
        }

        internal static (Type, Type) MarioGoombaTranslator(IGameObject mover, IGameObject receiver)
        {
            IEnemy goombaCast = (IEnemy)receiver;
            return (mover.GetType(), goombaCast.State.GetType());
        }

        internal static (Type, Type) MarioKoopaTranslator(IGameObject mover, IGameObject receiver)
        {
            IEnemy koopaCast = (IEnemy)receiver;
            return (mover.GetType(), koopaCast.State.GetType());
        }

        internal static (Type, Type) BumpableBlockEnemyTranslator(IGameObject mover, IGameObject receiver)
        {
            IEnemy enemyCast = (IEnemy)mover;
            IBumpable block = (IBumpable)receiver;
            
            return (enemyCast.GetType(), block.State.GetType());
        }
    }
}
