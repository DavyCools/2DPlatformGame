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
    /// Deze klasse GroundBlockHalf is verantwoordelijk voor
    /// het juiste gedrag van de GroundBlockHalf
    /// Erft over van: MoveableTile
    /// </summary>
    class GroundBlockHalf : MoveableTile
    {
        public GroundBlockHalf(ContentManager content, Vector2 _position, string name, int _amountOfBlocks) : base(content, _position, name, _amountOfBlocks)
        {
            TouchingLeft = false;
            TouchingRight = true;
        }
        /// <summary>
        /// Update de plaats
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (Position.X <= position.X - amountOfBlocks)
            {
                TouchingLeft = true;
                TouchingRight = false;
            }
            if (Position.X >= position.X + amountOfBlocks)
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
