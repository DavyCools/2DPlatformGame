using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze abstracte klasse MoveableTile is verantwoordelijk voor
    /// het juiste gedrag van een beweegbare Tile
    /// Erft over van: StaticTiles, IMoveableObject, IUpdate
    /// </summary>
    abstract class MoveableTile : StaticTiles, IMoveableObject, IUpdate
    {
        protected int amountOfBlocks = 70;
        public MoveableTile(ContentManager content, Vector2 _position, string name, int _amountOfBlocks) : base(content, _position, name)
        {
            ChangeVelocity(MovementSpeed, 0);
            position = Position;
            amountOfBlocks *= _amountOfBlocks;
        }
        public bool TouchingGround { get; set; }
        public bool TouchingLeft { get; set; }
        public bool TouchingRight { get; set; }
        public bool TouchingTop { get; set; }

        public float MovementSpeed => 1.5f;
   
        protected Vector2 velocity;
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
        protected Vector2 position;
        public void ChangePosition(float? x, float? y)
        {
            if (x != null)
                position.X = (float)x;
            if (y != null)
                position.Y = (float)y;
        }
        public abstract void Update(GameTime gameTime);
    }
}
