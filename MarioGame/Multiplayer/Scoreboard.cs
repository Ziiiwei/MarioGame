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
    public class Scoreboard
    {
        public int Score { get; set; }

        public int MaxScore { get; set; }
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
  
        }

        public void UpScore(int score)
        {
            Score += score;
            MaxScore += score; 
            if (Score == MarioGame.Instance.WinScore)
            {
                MarioGame.Instance.PlayerWon();
            }
        }

        public void Collect()
        {
            Coins++;
        }

        public void Die()
        {
            Lives--;
            MaxScore = 0;
        }

        public void AddLife()
        {
            Lives++;
        }


    }
}
