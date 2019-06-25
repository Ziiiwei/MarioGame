using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Gamespace.Commands;

namespace Gamespace.Controllers
{
    class PhysicsController : IController
    {
      
        private Dictionary<string, ICommand> PhysicEventLog;
        private AbstractGameObject obj;
        private (PhysicalStatus, Side) previous_status;
        private List<string> commandToExcute;

        public PhysicsController(MarioGame game)
        {
            obj = (AbstractGameObject)World.Instance.Mario;
            previous_status = obj.GameObjectPhysics.ObjectPhysicalState;

            PhysicEventLog = new Dictionary<string, ICommand>();

            PhysicEventLog.Add("Land", new MarioCrouchCommand(World.Instance.Mario));

            commandToExcute = new List<string>();
        }

        public bool CommandOverRide(string comand)
        {
            bool c = (comand == "R_Click" || comand == "Q_Click");
            return (obj.GameObjectPhysics.ObjectPhysicalState.Item1 == PhysicalStatus.Fall && !c);
        }

        public void SwitchMapping(string bindings)
        {
            // Nothing
        }

        public void Update()
        {
            (PhysicalStatus, Side) status;
            status = obj.GameObjectPhysics.ObjectPhysicalState;

            if (previous_status.Item1==PhysicalStatus.Fall && status.Item1 == PhysicalStatus.Ground)
            {
                commandToExcute.Add("Land");
            }


            foreach (String s in commandToExcute)
            {

                if (PhysicEventLog.ContainsKey(s))
                {
                    PhysicEventLog[s].Execute();
                }
            }

            commandToExcute.Clear();
            previous_status = status;

        }

      
    }
}
