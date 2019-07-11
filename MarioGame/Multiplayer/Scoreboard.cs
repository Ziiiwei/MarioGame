using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Data;
using Gamespace.Sounds;

namespace Gamespace.Multiplayer
{
    internal class Scoreboard
    {
        public int Score { get; set; }
        public int Coins { get; set; }
        public int Lives { get; set; }
        public int Time { get; set; }
        private int StartingTime = Numbers.STARTING_TIME;

        public Scoreboard(int lives)
        {
            Score = 0;
            Coins = 0;
            Lives = lives;
            Time = StartingTime;
        }

        public void Update(GameTime gametime)
        {
            Time = StartingTime - (int)gametime.TotalGameTime.TotalSeconds;
            BGMChange(Time);
        }

        public void UpScore(int score)
        {
            Score += score;
        }

        public void Collect()
        {
            Coins++;
        }

        public void Die()
        {
            Lives--;
        }

        public void AddLife()
        {
            Lives++;
        }

        public void BGMChange(int time)
        {
            if (time == 100)
            {
                SoundManager.Instance.StopBGM();
                SoundManager.Instance.PlaySoundEffect("OutOfTime");
                SoundManager.Instance.PlayNoTimeBGM();
            }
        }
    }
}
