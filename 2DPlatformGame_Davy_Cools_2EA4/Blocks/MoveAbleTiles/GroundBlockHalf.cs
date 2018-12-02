using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class GroundBlockHalf : MoveableTile
    {
        public GroundBlockHalf(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            TouchingLeft = false;
            TouchingRight = true;
        }
        public override void Update(GameTime gameTime)
        {
            if (Position.X <= position.X - 140)
            {
                TouchingLeft = true;
                TouchingRight = false;
            }
            if (Position.X >= position.X + 140)
            {
                TouchingLeft = false;
                TouchingRight = true;
            }
            if (!TouchingLeft)
                Position -= Velocity;
            if (!TouchingRight)
            {
                Position += Velocity;
            }
        }
    }
}
