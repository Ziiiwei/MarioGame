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
        private Dictionary<String, SoundEffectInstance> soundAssignments;
        private SoundEffect soundEffect;
        private SoundEffectInstance soundEffectInstance;
        private Song BGM;

        static SoundFactory()
        {
        }

        private SoundFactory()
        {
            StreamReader reader = File.OpenText("MarioGame/Data/DataFiles/SoundData.json");
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var magicNumbers = javaScriptSerializer.Deserialize<SoundDataRoot>(reader.ReadToEnd());
            reader.Close();

            soundAssignments = new Dictionary<String, SoundEffectInstance>();

            foreach (SoundData entry in magicNumbers.Entries)
            {
                String key = entry.SoundName;
                if (key == "BGM")
                {
                    BGM = MarioGame.Instance.Content.Load<Song>(entry.SoundPath);
                }

                else 
                {
                    soundEffect = MarioGame.Instance.Content.Load<SoundEffect>(entry.SoundPath);
                    soundEffectInstance = soundEffect.CreateInstance();
                    if (!soundAssignments.ContainsKey(key))
                    {
                        soundAssignments.Add(key, soundEffectInstance);
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

        public SoundEffectInstance GetSoundEffect(String name)
        {
            String key = name;
            SoundEffectInstance _soundEffect = soundAssignments[name];
            return _soundEffect;
        }
        public Song GetMainBGM()
        {
            return BGM;
        }

        public SoundEffectInstance GetNoTimeBGM()
        {
            SoundEffectInstance BGM = soundAssignments["NoTime"];
            return BGM;
        }
    }
}
