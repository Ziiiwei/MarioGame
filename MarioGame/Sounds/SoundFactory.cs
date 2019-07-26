using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Gamespace
{
    internal class SoundFactory
    {
        private static readonly SoundFactory instance = new SoundFactory();
        private Dictionary<String, SoundEffect> soundAssignments;
        private Dictionary<String, SoundEffectInstance> arenaAssignments;

        private SoundEffect soundEffect;
        private SoundEffectInstance soundEffectInstance;
        private SoundEffectInstance MainMenuBGM;
        private SoundEffectInstance SelectBGM;
        private SoundEffectInstance arena1BGM;
        private SoundEffectInstance arena2BGM;
        private SoundEffectInstance arena3BGM;

        static SoundFactory()
        {
        }

        private SoundFactory()
        {
            StreamReader reader = File.OpenText("MarioGame/Data/DataFiles/SoundData.json");
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var magicNumbers = javaScriptSerializer.Deserialize<SoundDataRoot>(reader.ReadToEnd());
            reader.Close();

            soundAssignments = new Dictionary<String, SoundEffect>();
            arenaAssignments = new Dictionary<String, SoundEffectInstance>();

            foreach (SoundData entry in magicNumbers.Entries)
            {
                String key = entry.SoundName;
                if (key == "MainMenu")
                {
                    soundEffect = MarioGame.Instance.Content.Load<SoundEffect>(entry.SoundPath);
                    MainMenuBGM = soundEffect.CreateInstance();
                }
                else if(key == "arena1")
                {
                    soundEffect = MarioGame.Instance.Content.Load<SoundEffect>(entry.SoundPath);
                    soundEffectInstance = soundEffect.CreateInstance();
                    arenaAssignments.Add(key, soundEffectInstance);
                }
                else if (key == "arena2")
                {
                    soundEffect = MarioGame.Instance.Content.Load<SoundEffect>(entry.SoundPath);
                    soundEffectInstance = soundEffect.CreateInstance();
                    arenaAssignments.Add(key, soundEffectInstance);
                }
                else if (key == "NoTime")
                {
                    soundEffect = MarioGame.Instance.Content.Load<SoundEffect>(entry.SoundPath);
                    soundEffectInstance = soundEffect.CreateInstance();
                    arenaAssignments.Add(key, soundEffectInstance);
                }
                else if (key == "Select")
                {
                    soundEffect = MarioGame.Instance.Content.Load<SoundEffect>(entry.SoundPath);
                    SelectBGM = soundEffect.CreateInstance();
                }

                else 
                {
                    soundEffect = MarioGame.Instance.Content.Load<SoundEffect>(entry.SoundPath);
                    //soundEffectInstance = soundEffect.CreateInstance();
                    if (!soundAssignments.ContainsKey(key))
                    {
                        soundAssignments.Add(key, soundEffect);
                    }
                }

            }
        }
        internal static SoundFactory Instance { get; } = new SoundFactory();

        protected class SoundData
        {
            public String SoundName { get; set; }
            public String SoundPath { get; set; }

        }

        protected class SoundDataRoot
        {
            public List<SoundData> Entries { get; set; }
        }

        public SoundEffect GetSoundEffect(String name)
        {
            String key = name;
            SoundEffect _soundEffect = soundAssignments[name];
            return _soundEffect;
        }
        public SoundEffectInstance GetArenaBGM(String name)
        {
            String key = name;
            SoundEffectInstance _soundEffectInstance = arenaAssignments[name];
            return _soundEffectInstance;
        }
        public SoundEffectInstance GetMainBGM()
        {
            return MainMenuBGM;
        }
        public SoundEffectInstance GetSelectBGM()
        {
            return SelectBGM;
        }
        public SoundEffect GetNoTimeBGM()
        {
            SoundEffect BGM = soundAssignments["NoTime"];
            return BGM;
        }
    }
}
