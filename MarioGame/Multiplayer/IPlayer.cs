using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Multiplayer
{
    public interface IPlayer
    {
        int GetScore();
        int PlayerID { get; }
        IMario GameObject { get; }
        void Update(GameTime gameTime);
        void DrawPlayersScreen();
        void Release();
        void Respawn();
void DisableGameControl();

 void ResumeControl();
    }
}
