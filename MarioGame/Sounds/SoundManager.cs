﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

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

        public void PlayMainBGM()
        {
            BGM = SoundFactory.Instance.GetMainBGM();
            MediaPlayer.Play(BGM);
            MediaPlayer.Volume = 0.4f;
        }

        public void StopBGM()
        {
            MediaPlayer.Stop();
        }

        public void PlayNoTimeBGM()
        {
            soundEffect = SoundFactory.Instance.GetNoTimeBGM();
            soundEffect.Play();
            soundEffect.Volume = 0.4f;
        }

    }
}
