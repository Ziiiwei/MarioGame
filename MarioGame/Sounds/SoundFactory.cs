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

namespace Gamespace.Sounds
{
    internal class SoundFactory
    {
        private static readonly SoundFactory instance = new SoundFactory();
        private Dictionary<String, SoundEffectInstance> soundAssignments;

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
                var key = entry.SoundName;
                entry.soundEffect = MarioGame.Instance.Content.Load<SoundEffectInstance>(entry.SoundPath);
                soundAssignments.Add(key, entry.soundEffect);

            }
        }
        internal static SoundFactory Instance { get; } = new SoundFactory();

        protected class SoundData
        {
            public String SoundName { get; set; }
            public String SoundPath { get; set; }
            public SoundEffectInstance soundEffect { get; set; }
        }

        protected class SoundDataRoot
        {
            public List<SoundData> Entries { get; set; }
        }

    }
}
