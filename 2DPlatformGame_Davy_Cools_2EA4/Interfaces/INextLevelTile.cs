using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze interface (INextLevelTile) moet gegeven worden aan
    /// alle objecten die de doorgang vormen naar het volgende level
    /// erft over van: ICollide
    /// </summary>
    interface INextLevelTile : ICollide
    {
    }
}
