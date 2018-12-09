using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze abstract klasse (Enemy) is beschrijft
    /// de algeme functionaliteit van een Enemy
    /// Erft over van: IMoveableObject, IUpdate, IDrawobject, IDeathly
    /// </summary>
    abstract class Enemy : IMoveableObject, IUpdate, IDrawObject, IDeathly
    {
        protected Animation animation;
        protected Texture2D texture;
        protected bool flipAnimation = false;
        public bool TouchingGround { get; set; }
        public bool TouchingLeft { get; set; }
        public bool TouchingRight { get; set; }
        public bool TouchingTop { get; set; }
        public virtual float MovementSpeed => 1.5f;
        public bool IsHit { get; set; }
        public Enemy(ContentManager content,Vector2 position, String name)
        {
            texture = content.Load<Texture2D>(name);
            Position = position;
            velocity.X = MovementSpeed;
        }

        public virtual Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, (int)(48 * animation.scale) + 4, (int)(48 * animation.scale) - 4); } //4px correctie voor voeten mooi op de grond te zetten
        }

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public void ChangePosition(float? x, float? y)
        {
            if (x != null)
                position.X = (float)x;
            if (y != null)
                position.Y = (float)y;
        }
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
        /// <summary>
        /// Tekent de enemy op het scherm
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, animation.scale, flipAnimation ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
        }
        /// <summary>
        /// Update de plaats van de enemy
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            if (Velocity.Y == 0 && Velocity.X == 0)
            {
                if (TouchingLeft)
                {
                    velocity.X = MovementSpeed;
                    flipAnimation = false;
                }
                if (TouchingRight)
                {
                    velocity.X = -MovementSpeed;
                    flipAnimation = true;
                }
            }
            if (Velocity.Y != 0)
                velocity.Y += 0.2f;
            Position += Velocity;

            if(!TouchingGround && Velocity.Y == 0)
            {
                velocity.Y = 0.2f;
            }
            TouchingRight = false;
            TouchingLeft = false;
            TouchingGround = false;
            TouchingTop = false;
        }
    }
}
