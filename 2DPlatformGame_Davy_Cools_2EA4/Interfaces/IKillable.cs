using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze interface (IKillable) moet gegeven worden aan
    /// alle objecten die kunnen doodgaan
    /// </summary>
    interface IKillable
    {
        bool IsHit { get; set; }
    }
}
