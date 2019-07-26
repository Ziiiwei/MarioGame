using Gamespace.Multiplayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Views
{
    internal class PlayableView : IView
    {
        private Scoreboard scoreboard;
        private ICamera cam;
        private GraphicsDevice graphicsDevice;
        private VertexBuffer vertexBuffer;
        private List<VertexPositionColor> vertexPositions;
  

        public PlayableView(Scoreboard scoreboard, ICamera cam, Viewport viewport, GraphicsDevice graphicsDevice)
        {   
            this.scoreboard = scoreboard;
            this.cam = cam;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(MarioGame.Instance.Font,
                "Kills: " + scoreboard.Score + "  Lives: " + scoreboard.Lives + "  Kill-Streak: " + scoreboard.MaxScore,
                cam.CameraPosition, Color.Black);
            World.Instance.DrawWorld(spriteBatch);
        }
    }
}
