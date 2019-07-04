using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Gamespace
{
    internal class SoundFactory
    {
        private static readonly SoundFactory instance = new SoundFactory();
        private SoundEffect effect;
        private Song song;
        static SoundFactory()
        {
        }

        private SoundFactory()
        {

        }
    }
}
