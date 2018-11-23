using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    interface IMoveableObject : ICollide
    {
        Vector2 Velocity { get; set; }
        Vector2 Position { get; set; }
        bool TouchingGround { get; set; }
        bool TouchingLeft { get; set; }
        bool TouchingRight { get; set; }
        bool TouchingTop { get; set; }
    }
}
