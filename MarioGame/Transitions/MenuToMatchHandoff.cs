using Gamespace.Data;
using Gamespace.Multiplayer;
using Gamespace.Transitions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class MenuToMatchHandoff
    {
        private static List<IPlayer> players;

        public MenuToMatchHandoff(GameMenu menu, GraphicsDevice graphicsDevice)
        {
            MarioGame.Instance.PlayerCount = menu.PlayerCount;

            players = new List<IPlayer>()
            {
                new Player(typeof(Mario), new SpriteBatch(graphicsDevice), new Vector2(Numbers.PLAYER_ONE_X, Numbers.STARTING_Y)),
                new Player(typeof(Mario), new SpriteBatch(graphicsDevice), new Vector2(Numbers.PLAYER_TWO_X, Numbers.STARTING_Y)),
                new Player(typeof(Mario), new SpriteBatch(graphicsDevice), new Vector2(200, 300)),
                new Player(typeof(Mario), new SpriteBatch(graphicsDevice), new Vector2(200, 400))
            };

            for (int i = 1; i <= menu.PlayerCount; i++)
            {
                World.Instance.AddPlayer(players[i-1]);
            }

            string path = MarioGame.Instance.ArenaPaths[menu.ArenaSelected].Item2;

            LevelLoader levelLoader = new LevelLoader(World.Instance, path);

            

        }
    }
}
