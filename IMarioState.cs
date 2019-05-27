﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    interface IMarioState
    {
        void Draw();
        void Update();
        void Jump();
        void MovingRight();
        void MovingLeft();
        void FacingRight();
        void FacingLeft();
        void CrouchRight();
        void CrouchLeft();
        void TakeDamage();
        void Upgrade();
    }
}