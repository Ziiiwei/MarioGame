﻿using System;
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
        private string arena;

        static SoundManager()
        {

            arenaPath = new Dictionary<string, string>
            {
                {"MarioGame/Data/DataFiles/level1.csv", "arena1"},
                {"MarioGame/Data/DataFiles/level2.csv", "arena2"},
                {"MarioGame/Data/DataFiles/level3.csv", "NoTime"},
                {"MarioGame/Data/DataFiles/flatlevel.csv", "arena1"},
            };
        }
  
        private static Dictionary<string, string> arenaPath;
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
        public void PlayArenaBGM(string path)
        {
            ArenaBGM = SoundFactory.Instance.GetSoundEffect(arenaPath[path]);
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
