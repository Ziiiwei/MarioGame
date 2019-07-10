using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.Animation
{
    public interface IAnimation<T>

    {
        T AnimatiedObj { get; set;}

        void Start();
        void Play();
        void PlayNextFrame();
        void AddFrame(IKeyFrame<T> frame);
        void Finished();
       


    }
}
