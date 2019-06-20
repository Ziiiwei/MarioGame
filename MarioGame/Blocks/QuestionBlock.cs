using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    internal class QuestionBlock : AbstractGameObject, IBlock, IDestroyable
    {
        public QuestionBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {

        }

        public void Destroy()
        {
            Vector2 newBlockPosition = positionOnScreen;
            World.Instance.RemoveFromWorld(Uid);
            World.Instance.AddGameObject(new UsedBlock(newBlockPosition));
        }
    }
}
