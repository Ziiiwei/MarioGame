/* Referenced: https://stackoverflow.com/questions/4232795/how-to-iterate-over-each-active-gamepad-in-xna */
using Gamespace.Controllers;
using Gamespace.Transitions;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class MenuInputController : IController
    {

        private readonly Dictionary<Keys, Delegate> keyBinds;
        private readonly Dictionary<Buttons, Delegate> buttonBinds;
        private readonly GameMenu menu;

        public MenuInputController(GameMenu menu)
        {
            this.menu = menu;

            keyBinds = new Dictionary<Keys, Delegate>()
            {
                {Keys.Up, new Action(() => Update()) }
            };

            buttonBinds = new Dictionary<Buttons, Delegate>()
            {
                {Buttons.DPadUp, new Action(() => Update()) }
            };
        }

        public void Update()
        {
            
        }
    }
}
