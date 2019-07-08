using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Views
{
    internal class ViewFactory
    {
        private static readonly ViewFactory instance = new ViewFactory();
        private Dictionary<String, IView> views;

        static ViewFactory() { }

        private ViewFactory()
        {
            views = new Dictionary<String, IView>()
            {

            };
        }

        public ViewFactory Instance { get => instance; }





    }
}
