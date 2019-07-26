﻿using Gamespace;
using Gamespace.Multiplayer;
using Gamespace.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    class Soldier : Mario
    {
        public Soldier(Vector2 positionOnScreen, Scoreboard scoreboard, IPlayer player) : base(positionOnScreen, scoreboard, player)
        {
            PowerUpState = new MarioFireState();
        }
        public Soldier(Vector2 positionOnScreen) : base(positionOnScreen)
        {

        }
        public override void PowerDown()
        {
        }

        public override void PowerUp()
        {
        }

        public override void UpdateArt()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, "");
        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, State.GetType().Name, "");
        }

        public override void Die()
        {
            base.Die();
        }
    }
}
