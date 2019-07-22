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
        Dictionary<Type, IPhysicsConstants> constantsAssignments;
        List<List<float>> constants;
        
        static PhysicsConstants() {}
        private PhysicsConstants()
        {
            constants = new List<List<float>>();

            constantsAssignments = new Dictionary<Type, IPhysicsConstants>();

            List<float> zeroDefinitions = new List<float> { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };

            List<float> marioDefinitions = new List<float> { 12.5f, 0.5f, 5f, 12f, 1f };
            constantsAssignments.Add(typeof(Mario), new PhysicsConstantsDefinitons(marioDefinitions));

            List<float> enemyDefinitions = new List<float> { 2f, 0.5f, 4f, 4f, 1f };
            constantsAssignments.Add(typeof(Goomba), new PhysicsConstantsDefinitons(enemyDefinitions));
            constantsAssignments.Add(typeof(Koopa), new PhysicsConstantsDefinitons(enemyDefinitions));

            List<float> shellDefinitions = new List<float> { 2f, 0.5f, 8f, 8f, 1f };
            constantsAssignments.Add(typeof(KoopaFlippedState), new PhysicsConstantsDefinitons(shellDefinitions));

            List<float> shroomDefinitions = new List<float> { 3f, 3f, 3f, 3f, 3f };
            constantsAssignments.Add(typeof(RedShroom), new PhysicsConstantsDefinitons(shroomDefinitions));
            constantsAssignments.Add(typeof(GreenShroom), new PhysicsConstantsDefinitons(shroomDefinitions));

            List<float> brickBlockDefinitions = new List<float> { 5.2f, 1.2f, 7f, 7f, 3.0f };
            constantsAssignments.Add(typeof(BrickBlock), new PhysicsConstantsDefinitons(brickBlockDefinitions));

            List<float> fireballDefinitions = new List<float> { 1.0f, 0.1f, 5f, 2f, 5f };
            constantsAssignments.Add(typeof(Fireball), new PhysicsConstantsDefinitons(fireballDefinitions));

            constantsAssignments.Add(typeof(Star), new PhysicsConstantsDefinitons(zeroDefinitions));

            constantsAssignments.Add(typeof(NullGameObject), new PhysicsConstantsDefinitons(zeroDefinitions));
        }

        internal static PhysicsConstants Instance { get; } = new PhysicsConstants();

        internal IPhysicsConstants GetConstants(Type t)
        {
            if (constantsAssignments.ContainsKey(t))
            {
                return constantsAssignments[t];
            }
            List<float> nullDefinitions = new List<float> { 0, 0, 0, 0, 0,};
            return new PhysicsConstantsDefinitons(nullDefinitions);
        }

        internal IPhysics GetNullPhysics()
        {
            IGameObject nullGameObject = new NullGameObject();
            return new Physics(nullGameObject, new Vector2(0, 0), PhysicsConstants.Instance.GetConstants(nullGameObject.GetType()));
        }

        internal class PhysicsConstantsDefinitons : IPhysicsConstants
        {

            public float gravityConstant { get; }
            public float accelConstant { get; }
            public float max_X_V { get; }
            public float max_Y_V { get; }
            public float frictionConstant { get; }
            public PhysicsConstantsDefinitons(List<float> definitions)
            {
                gravityConstant = definitions[1];
                accelConstant = definitions[0];
                max_X_V = definitions[2];
                max_Y_V = definitions[3];
                frictionConstant = definitions[4];
            }
        }
    }
}
