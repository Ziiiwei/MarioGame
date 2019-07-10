using Gamespace.Commands;
using Gamespace.Multiplayer;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Controllers
{
    internal class KeyAssignmentFactory
    {
        private static readonly KeyAssignmentFactory instance = new KeyAssignmentFactory();
        private Dictionary<int, Dictionary<Keys, Type>> playerBindingsSelector;
        private Dictionary<Keys, Type> playerOneBinds;
        private Dictionary<Keys, Type> playerTwoBinds;
        private Dictionary<Keys, Type> duringAnimationBinds;

        static KeyAssignmentFactory()
        {

        }

        private KeyAssignmentFactory()
        {
            playerOneBinds = new Dictionary<Keys, Type>();
            playerOneBinds.Add(Keys.P, typeof(PauseGameCommand));
            playerOneBinds.Add(Keys.Q, typeof(QuitGame));
            playerOneBinds.Add(Keys.W, typeof(MarioJumpCommand));
            playerOneBinds.Add(Keys.S, typeof(MarioCrouchCommand));
            playerOneBinds.Add(Keys.A, typeof(MarioMoveLeftCommand));
            playerOneBinds.Add(Keys.D, typeof(MarioMoveRightCommand));
            playerOneBinds.Add(Keys.Space, typeof(MarioFireCommand));
            playerOneBinds.Add(Keys.R, typeof(Reset));

            playerTwoBinds = new Dictionary<Keys, Type>();
            playerTwoBinds.Add(Keys.P, typeof(PauseGameCommand));
            playerTwoBinds.Add(Keys.Q, typeof(QuitGame));
            playerTwoBinds.Add(Keys.Up, typeof(MarioJumpCommand));
            playerTwoBinds.Add(Keys.Down, typeof(MarioCrouchCommand));
            playerTwoBinds.Add(Keys.Left, typeof(MarioMoveLeftCommand));
            playerTwoBinds.Add(Keys.Right, typeof(MarioMoveRightCommand));
            playerTwoBinds.Add(Keys.RightShift, typeof(MarioFireCommand));
            playerTwoBinds.Add(Keys.R, typeof(Reset));

            duringAnimationBinds = new Dictionary<Keys, Type>();
            duringAnimationBinds.Add(Keys.P, typeof(PauseGameCommand));
            duringAnimationBinds.Add(Keys.Q, typeof(QuitGame));
            duringAnimationBinds.Add(Keys.R, typeof(Reset));

            playerBindingsSelector = new Dictionary<int, Dictionary<Keys, Type>>()
            {
                {0, playerOneBinds },
                {1, playerTwoBinds }
            };
        }

        internal static KeyAssignmentFactory Instance { get; } = new KeyAssignmentFactory();

        internal Dictionary<Keys, ICommand> GetBindings(IPlayer player)
        {
            Dictionary<Keys, Type> binds = playerBindingsSelector[player.PlayerID];
            Dictionary<Keys, ICommand> retVal = new Dictionary<Keys, ICommand>();

            foreach (Keys key in binds.Keys)
            {
                retVal.Add(key, (ICommand)Activator.CreateInstance(binds[key], player.GameObject));
            }
            /* rename retval */
            return retVal;
        }

        internal Dictionary<Keys,ICommand> GetPausedBinding(IPlayer player)
        {
            Dictionary<Keys, ICommand> retVal = new Dictionary<Keys, ICommand>();

            foreach (Keys key in duringAnimationBinds.Keys)
            {
                retVal.Add(key, (ICommand)Activator.CreateInstance(duringAnimationBinds[key], player.GameObject));
            }
            return retVal;
        }


    }
}
