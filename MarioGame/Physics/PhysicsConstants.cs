using Gamespace.Blocks;
using Gamespace.Goombas;
using Gamespace.Items;
using Gamespace.Koopas;
using Gamespace.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class PhysicsConstants
    {
        Dictionary<Type, (float g,float a,float x,float y,float f)> constantsAssignments;
        List<List<float>> constants;
        
        static PhysicsConstants() {}
        private PhysicsConstants()
        {
            constants = new List<List<float>>();

            constantsAssignments = new Dictionary<Type, (float g, float a, float x, float y, float f)>
            {
                {
                    typeof(Mario),
                    (0.5f, 0.5f, 5f, 10f, 1f)
                },
                {
                    typeof(NullGameObject),
                    (0.0f, 0.0f, 0.0f, 0.0f, 0.0f)
                },
                {
                    typeof(Goomba),
                    (2f, 0.5f, 3f, 3f, 1f )
                },
                {
                    typeof(Koopa),
                    (2f, 0.5f, 3f, 3f, 1f )
                },
                {
                    typeof(KoopaFlippedState),
                    (2f, 0.5f, 8f, 8f, 1f )
                },
                {
                    typeof(RedShroom),
                    (3f, 3f, 3f, 3f, 3f )
                },
                {
                    typeof(GreenShroom),
                    (3f, 3f, 3f, 3f, 3f )
                },
                {
                    typeof(BrickBlock),
                    (5.2f, 1.2f, 7f, 7f, 3.0f )

                },
                {
                    typeof(Star),
                    (0.0f, 0.0f, 0.0f, 0.0f, 0.0f)
                },
                {
                    typeof(Fireball),
                    (1.0f, 2.0f, 10f, 10f, 5f)
                },
                {
                    typeof(Bullet1),
                    (1.0f, 2.0f, 10f, 8f, 5f)
                }
            };
        }
           
          

      
        internal static PhysicsConstants Instance { get; } = new PhysicsConstants();

        internal (float g, float a, float x, float y, float f) GetConstants(Type t)
        {
            if (constantsAssignments.ContainsKey(t))
            {
                return constantsAssignments[t];
            }

            return (0f, 0f, 0f, 0f, 0f);
        }
    }
}
