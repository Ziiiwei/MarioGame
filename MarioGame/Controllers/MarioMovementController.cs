using Gamespace.Commands;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Controllers
{
    internal class MarioMovementController
    {
        private static readonly MarioMovementController instance = new MarioMovementController();
        private static Dictionary<Keys, Func<ICommand>> keyActionMap;
        public static IMario marioUnderControl { get; private set; }

        

        static MarioMovementController()
        {
            keyActionMap = new Dictionary<Keys, Func<ICommand>>()
            {
                {Keys.Q, () => {return new QuitGame(MarioGame.Instance); } },
                {Keys.R, () => {return new Reset(MarioGame.Instance); } },
                {Keys.W, new Func<ICommand>(MarioUpMovement) },
                {Keys.S, new Func<ICommand>(MarioDownMovement) },
                {Keys.A, new Func<ICommand>(MarioLeftMovement) },
                {Keys.D, new Func<ICommand>(MarioRightMovement) }
            };
        }

        private MarioMovementController()
        {

        }

        public static MarioMovementController Instance
        {
            get
            {
                return instance;
            }
        }
        public void SetMarioUnderControl(IMario mario)
        {
            marioUnderControl = mario;
        }

        public ICommand GetCommand(Keys key)
        {
            if (keyActionMap.ContainsKey(key))
            {
                return keyActionMap[key].Invoke();
            }
            return new NullCommand();
        }

        private static ICommand MarioUpMovement()
        {
            if (marioUnderControl.GameObjectPhysics.Velocity.Y == 0 
                && marioUnderControl.GameObjectPhysics.Acceleration.Y == 0)
            {
                return new MarioJumpCommand(marioUnderControl);
            }

            return new NullCommand();
        }

        private static ICommand MarioDownMovement()
        {
            return new MarioCrouchCommand(marioUnderControl);
        }

        private static ICommand MarioLeftMovement()
        {
            if (marioUnderControl.GameObjectPhysics.Velocity.X <= 0)
            {
                return new MarioMoveLeftCommand(marioUnderControl);
            }
            return new MarioMoveRightCommand(marioUnderControl);
        }

        private static ICommand MarioRightMovement()
        {
            if (marioUnderControl.GameObjectPhysics.Velocity.X >= 0)
            {
                return new MarioMoveRightCommand(marioUnderControl);
            }
            return new MarioMoveLeftCommand(marioUnderControl);
        }

    }
}
