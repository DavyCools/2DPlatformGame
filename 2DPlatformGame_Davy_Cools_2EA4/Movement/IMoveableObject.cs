using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    public interface IMoveableObject : ICollide, IDrawObject
    {
        Vector2 Velocity { get; set;}
        void ChangeVelocity(float? x, float? y);
        //Vector2 Position { get; set; }
        void ChangePosition(float? x, float? y);
        bool TouchingGround { get; set; }
        bool TouchingLeft { get; set; }
        bool TouchingRight { get; set; }
        bool TouchingTop { get; set; }
        float MovementSpeed { get; }
    }
}
