using Gamespace.Goombas;
using Gamespace.Items;
using Gamespace.Koopas;
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

            List<float> marioDefinitions = new List<float> { 1f, 2f, 4f, 10f, 1f };
            constantsAssignments.Add(typeof(Mario), new PhysicsConstantsDefinitons(marioDefinitions));

            List<float> enemyDefinitions = new List<float> { 1f, 1f, 0.8f, 1f, 1f };
            constantsAssignments.Add(typeof(Goomba), new PhysicsConstantsDefinitons(enemyDefinitions));
            constantsAssignments.Add(typeof(Koopa), new PhysicsConstantsDefinitons(enemyDefinitions));

            List<float> redShroomDefinitions = new List<float> { 0.5f, 0.5f, 0.5f, 0.5f, 0.5f };
            constantsAssignments.Add(typeof(RedShroom), new PhysicsConstantsDefinitons(redShroomDefinitions));

            List<float> starDefinitions = new List<float> { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
            constantsAssignments.Add(typeof(Star), new PhysicsConstantsDefinitons(redShroomDefinitions));
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

        internal class PhysicsConstantsDefinitons : IPhysicsConstants
        {

            public float G { get; }
            public float A { get; }
            public float MAX_X_V { get; }
            public float MAX_Y_V { get; }
            public float FRICTION { get; }
            public PhysicsConstantsDefinitons(List<float> definitions)
            {
                /* This nastyness will not be permanent */
                G = definitions[1];
                A = definitions[0];
                MAX_X_V = definitions[2];
                MAX_Y_V = definitions[3];
                FRICTION = definitions[4];
            }
        }
    }
}
