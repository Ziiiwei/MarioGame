using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Animation;

namespace Gamespace
{
    public partial class World
    {
        public void AddAnimationToPlay(IAnimation<IGameObject> animation)
        {
            animationsToAdd.Add(animation);
            objectsToRemoveFromUpdate.Add(animation.AnimatiedObj);
            
        }

        public void RemoveFinishedAnimation(IAnimation<IGameObject> animation)
        {
            animationsToDelete.Add(animation);
            objectsToAddToUpdate.Add(animation.AnimatiedObj);
        }

        public void RemoveFromUpdate(IGameObject gameObject)
        {
            objectsToRemoveFromUpdate.Add(gameObject);
        }

        public void AddToUpdate(IGameObject gameObject)
        {
            objectsToAddToUpdate.Add(gameObject);
        }
    }
}
