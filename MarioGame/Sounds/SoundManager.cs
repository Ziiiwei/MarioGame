using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Gamespace.Data;

namespace Gamespace.Sounds
{
    public class SoundManager
    {
        private static readonly SoundManager instance = new SoundManager();
        private SoundEffectInstance  soundEffect;
        private Song BGM;
        static SoundManager()
        {
        }
        internal static SoundManager Instance { get; } = new SoundManager();
        public void PlaySoundEffect(String name)
        {
            soundEffect = SoundFactory.Instance.GetSoundEffect(name);
            soundEffect.Play();
        }

        public void PlayBGM()
        {
            BGM = SoundFactory.Instance.GetBGM();
            MediaPlayer.Play(BGM);
            MediaPlayer.Volume = Numbers.VOLUME;
        }

        public void StopBGM()
        {
            MediaPlayer.Stop();
        }

    }
}
