using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Multiplayer
{
    public interface IPlayer
    {
        IGameObject GameObject { get; }
        void Update();
        void DrawPlayersScreen();
    }
}
