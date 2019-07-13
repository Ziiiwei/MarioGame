using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Animation;
using Gamespace.Multiplayer;

namespace Gamespace
{
    public partial class World
    {

        public IGameObject FindObject(Type type)
        {
            foreach (IGameObject obj in objectsToDraw)
            {
                if (obj.GetType() == type)
                {
                    return obj;
                }
            }
            return null;
        }
        public void AddAnimationToPlay(IAnimation<IGameObject> animation)
        {
            bool duplicatedAni = false;

            foreach (IAnimation<IGameObject> ani in animationsToPlay)
            {
                if (ani.AnimatiedObj.Uid == animation.AnimatiedObj.Uid)
                {
                    duplicatedAni = true;
                }
            }

            foreach (IAnimation<IGameObject> ani in animationsToAdd)
            {
                if (ani.AnimatiedObj == animation.AnimatiedObj)
                {
                    duplicatedAni = true;
                }
            }

            if (!duplicatedAni)
            {
                animationsToAdd.Add(animation);
                objectsToRemoveFromUpdate.Add(animation.AnimatiedObj);

                foreach (IPlayer player in players)
                {
                    if(player.GameObject == animation.AnimatiedObj)
                    {
                        player.DisableGameControl();
                    }
                }
            }
      
            
        }

        public void RemoveFinishedAnimation(IAnimation<IGameObject> animation)
        {
            animationsToDelete.Add(animation);
            objectsToAddToUpdate.Add(animation.AnimatiedObj);

            foreach (IPlayer player in players)
            {
                if (player.GameObject == animation.AnimatiedObj)
                {
                    player.ResumeControl();
                }
            }
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
