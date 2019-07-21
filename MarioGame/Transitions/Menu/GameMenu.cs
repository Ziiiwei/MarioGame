using Gamespace.Controllers;
using Gamespace.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Transitions
{
    internal class GameMenu
    {
        private IView view;
        private IController input;

        public GameMenu()
        {
            view = new ContinueScreen();
            input = new TitleScreenInput(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            view.Draw(spriteBatch);
        }

        public void Update()
        {
            input.Update();
        }

        public void ExitTitleScreen()
        {
            MarioGame.Instance.OnMenuSelectionsComplete();
            input = new MenuInputController(this);
        }
    }
}
