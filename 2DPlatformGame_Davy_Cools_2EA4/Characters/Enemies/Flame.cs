using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (Flame) is verantwoordelijk
    /// voor het juist gedrag van de Flame
    /// Erft over van: Enemy
    /// </summary>
    class Flame : Enemy
    {
        private float Speed = 3f;
        public Flame(ContentManager content, Vector2 position, string name) : base(content, position, name)
        {
            ChangeVelocity(0, -Speed);
            ChangePosition(Position.X + 28, null);
        }
        public override Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height); }
        }
        /// <summary>
        /// Update de plaats van de flame
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (TouchingTop)
            {
                ChangeVelocity(0, Speed);
                flipAnimation = true;
            }
            if (TouchingGround)
            {
                ChangeVelocity(0, -Speed);
                flipAnimation = false;
            }
            Position += Velocity;
            TouchingRight = false;
            TouchingLeft = false;
            TouchingGround = false;
            TouchingTop = false;
        }
        /// <summary>
        /// Tekent de flame op het scherm
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, new Rectangle(0, 0, texture.Width, texture.Height), Color.AliceBlue, 0f, Vector2.Zero, 1f, flipAnimation ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);

        }
    }
}
