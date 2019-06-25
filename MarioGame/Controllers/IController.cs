using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;


namespace Gamespace.Controllers
{
    public enum PhysicalStatus : int { Fall, Ground, None }
    interface IController
    {
        void Update();

        void SwitchMapping(string bindings);

        bool CommandOverRide(string comand);
    }
}
