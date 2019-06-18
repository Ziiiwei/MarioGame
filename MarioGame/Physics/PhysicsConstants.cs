using Gamespace.Goombas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class PhysicsConstants
    {
        /* There is a plan to data drive this thing */
        private static readonly PhysicsConstants instance = new PhysicsConstants();
        Dictionary<Type, IPhysicsConstants> constantsAssignments;
        List<List<float>> constants;
        
        static PhysicsConstants()
        {
        }

        private PhysicsConstants()
        {
            constants = new List<List<float>>();

            constantsAssignments = new Dictionary<Type, IPhysicsConstants>();

            List<float> marioDefinitions = new List<float> { 0.3f, 0.3f, 4.3f, 1.3f, 2.3f, 4.3f };
            constantsAssignments.Add(typeof(Mario), new PhysicsConstantsDefinitons(marioDefinitions));

            List<float> enemyDefinitions = new List<float> { 0.3f, 0.3f, 1.3f, 1.3f, 2.3f, 2.3f };
            constantsAssignments.Add(typeof(Goomba), new PhysicsConstantsDefinitons(enemyDefinitions));
        }

        internal static PhysicsConstants Instance
        {
            get
            {
                return instance;
            }
        }

        internal IPhysicsConstants GetConstants(Type t)
        {
            if (constantsAssignments.ContainsKey(t))
            {
                return constantsAssignments[t];
            }
            List<float> nullDefinitions = new List<float> { 0, 0, 0, 0, 0, 0 };
            return new PhysicsConstantsDefinitons(nullDefinitions);
        }

        internal class PhysicsConstantsDefinitons : IPhysicsConstants
        {
            public float GRAVITY { get; protected set; }
            public float FORCE_HORIZONTAL_AGAINST { get; protected set; }
            public float GAMEOBJECT_FORCE_UP { get; protected set; }
            public float GAMEOBJECT_FORCE_HORIZONTAL { get; protected set; }
            public float MAX_HORIZONTAL_V { get; protected set; }
            public float MAX_VERTICAL_V { get; protected set; }

            public PhysicsConstantsDefinitons(List<float> definitions)
            {
                /* This nastyness will not be permanent */
                GRAVITY = definitions[0];
                FORCE_HORIZONTAL_AGAINST = definitions[1];
                GAMEOBJECT_FORCE_UP = definitions[2];
                GAMEOBJECT_FORCE_HORIZONTAL = definitions[3];
                MAX_HORIZONTAL_V = definitions[4];
                MAX_VERTICAL_V = definitions[5];
            }
        }
    }
}
