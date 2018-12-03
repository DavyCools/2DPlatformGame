﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze interface (IDeathly) moet gegeven worden aan alle objecten die dodelijk zijn om te weten dat deze dodelijk zijn.
    /// </summary>
    interface IDeathly : ICollide
    {
        bool IsHit { get; set; }
    }
}
