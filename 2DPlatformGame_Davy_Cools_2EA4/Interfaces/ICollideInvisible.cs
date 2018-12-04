using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze interface (ICollideInvisible) wordt gegeven aan onzichitbare blokken
    /// Onzichtbare blokken worden enkel door enemies gedetecteerd
    /// Erft over van: ICollide
    /// </summary>
    interface ICollideInvisible : ICollide
    {
    }
}
