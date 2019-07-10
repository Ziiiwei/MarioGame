using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Animation
{
    public class AnimationFactory
    {
        static AnimationFactory() { }
        private AnimationFactory()
        {


        }

        private static readonly AnimationFactory instance = new AnimationFactory();
        public static AnimationFactory Instance { get; } = new AnimationFactory();


    }
}
