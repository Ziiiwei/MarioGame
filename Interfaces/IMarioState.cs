﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface IMarioState
    {
        void Jump(IMario mario);
        void Crouch(IMario mario);
        void MoveRight(IMario mario);
        void MoveLeft(IMario mario);
    }
}
