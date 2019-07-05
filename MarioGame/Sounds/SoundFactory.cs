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
using Gamespace.Sounds;

namespace Gamespace
{
    internal class SoundFactory
    {
        private static readonly SoundFactory instance = new SoundFactory();
        private Dictionary<String, SoundEffect> soundAssignments;
        private SoundEffect soundEffect;

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

            foreach (SoundData entry in magicNumbers.Entries)
            {
                String key = entry.SoundName;
                soundEffect = MarioGame.Instance.Content.Load<SoundEffect>(entry.SoundPath);
                if (!soundAssignments.ContainsKey(key))
                {
                    soundAssignments.Add(key, soundEffect);
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

        public void PlaySoundEffect(String name)
        {
            String key = name;
            soundAssignments[name].Play();
        }
    }
}
