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
        private static List<Vector2> spawnPoints;

        public MenuToMatchHandoff(GameMenu menu, GraphicsDevice graphicsDevice)
        {
            MarioGame.Instance.PlayerCount = menu.PlayerCount;

            spawnPoints = new List<Vector2>()
            {
                new Vector2(200, 200),
                new Vector2(200, 300),
                new Vector2(300, 350),
                new Vector2(300, 400)
            };

            for (int i = 1; i <= menu.PlayerCount; i++)
            {

                World.Instance.AddPlayer(new Player(typeof(Mario), new SpriteBatch(graphicsDevice), spawnPoints[i-1]));
            }

            string path = MarioGame.Instance.ArenaPaths[menu.ArenaSelected].Item2;

            LevelLoader levelLoader = new LevelLoader(World.Instance, path);

        }
    }
}
