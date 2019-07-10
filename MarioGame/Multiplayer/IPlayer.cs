using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Multiplayer
{
    public interface IPlayer
    {
        int PlayerID { get; }
        IMario GameObject { get; }
        void Update();
        void DrawPlayersScreen();
        void Release();
        void UpScore(int score);
    }
}
