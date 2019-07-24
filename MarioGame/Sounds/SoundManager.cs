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
        private SoundEffectInstance MainMenuBGM;
        private SoundEffectInstance SelectBGM;
        private SoundEffectInstance ArenaBGM;

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
            MainMenuBGM = SoundFactory.Instance.GetMainBGM();
            MainMenuBGM.IsLooped = true;
            MainMenuBGM.Play();
        }

        public void StopMainBGM()
        {
            MainMenuBGM.Stop();
        }

        public void PlaySelectBGM()
        {
            SelectBGM = SoundFactory.Instance.GetSoundEffect("Select");
            SelectBGM.IsLooped = true;
            SelectBGM.Volume = 0.5f;
            SelectBGM.Play();
        }

        public void StopSelectBGM()
        {
            SelectBGM.Stop();
        }
        public void PlayArenaBGM()
        {
            ArenaBGM = SoundFactory.Instance.GetSoundEffect("arena1");
            ArenaBGM.IsLooped = true;
            ArenaBGM.Volume = 0.5f;
            ArenaBGM.Play();
        }

        public void StopArenaBGM()
        {
            ArenaBGM.Stop();
        }

    }
}
