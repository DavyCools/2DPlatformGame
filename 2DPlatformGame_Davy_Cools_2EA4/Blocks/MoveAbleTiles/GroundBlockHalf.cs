using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class GroundBlockHalf : StaticTiles, IMoveableObject, IUpdate
    {
        public GroundBlockHalf(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            ChangeVelocity(MovementSpeed, 0);
            TouchingLeft = false;
            TouchingRight = true;
            position = Position;
        }
        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, 70, 35);

        public bool TouchingGround { get; set; }
        public bool TouchingLeft { get; set; }
        public bool TouchingRight { get; set; }
        public bool TouchingTop { get; set; }

        public float MovementSpeed => 1f;

        private Vector2 velocity;
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public void ChangeVelocity(float? x, float? y)
        {
            if (x != null)
                velocity.X = (float)x;
            if (y != null)
                velocity.Y = (float)y;
        }
        private Vector2 position;
        public void ChangePosition(float? x, float? y)
        {
            if (x != null)
                position.X = (float)x;
            if (y != null)
                position.Y = (float)y;
        }

        public void Update(GameTime gameTime)
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
