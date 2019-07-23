using Gamespace.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Characters
{
    internal abstract class MovingCharacterState : ICharacterState
    {
        protected ICharacter character;

        protected MovingCharacterState(ICharacter character)
        {
            this.character = character;
        }
        public virtual void Crouch() { }
        public virtual void Jump() { }
        public virtual void MoveLeft() { }
        public virtual void MoveRight() { }
        public virtual void Land() { }
        public virtual void FrictionStop() { }
        public virtual void Fire() { }
        public virtual void ClimbUp() { }
        public virtual void ClimbDown() { }
        public virtual void Stand() { }
        public virtual bool Jumpable()
        {
            return true;
        }
        
    }
}
