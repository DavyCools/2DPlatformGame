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
    abstract class Enemy : IMoveableObject, IUpdate, IDrawObject
    {
        protected Animation animation;
        Texture2D texture;
        private bool flipAnimation = false;
        public bool TouchingGround { get; set; }
        public bool TouchingLeft { get; set; }
        public bool TouchingRight { get; set; }
        public bool TouchingTop { get; set; }
        public float MovementSpeed => 1.5f;
        public Enemy(ContentManager content,Vector2 position, String name)
        {
            texture = content.Load<Texture2D>(name);
            Position = position;
            velocity.X = MovementSpeed;
        }

        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, (int)(48 * animation.scale), (int)(48 * animation.scale) - 4); } //4px correctie voor voeten mooi op de grond te zetten
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
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, animation.scale, flipAnimation ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            //spriteBatch.Draw(texture, Position, animation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 0.7f, flipAnimation ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
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
