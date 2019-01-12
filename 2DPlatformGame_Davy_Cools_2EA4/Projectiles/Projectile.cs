using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze abstracte klasse (Projectile) definieert 
    /// de properties/methodes die nodig zijn voor een Projectiel
    /// Erft over van: IMoveableObject, IDrawObject, IDeathly
    /// </summary>
    abstract class Projectile : IMoveableObject, IDrawObject, IDeathly
    {
        private Texture2D texture;
        private Vector2 spawnPosition;
        private bool flipAnimation;
        public bool TouchingGround { get; set; }
        public bool TouchingLeft { get; set; }
        public bool TouchingRight { get; set; }
        public bool TouchingTop { get; set; }

        public float MovementSpeed => 5f;

        protected Vector2 velocity;
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        /// <summary>
        /// Aanpassen van de velocity
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ChangeVelocity(float? x, float? y)
        {
            if (x != null)
                velocity.X = (float)x;
            if (y != null)
                velocity.Y = (float)y;
        }
        protected Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        /// <summary>
        /// Aanpassen van de positie
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ChangePosition(float? x, float? y)
        {
            if (x != null)
                position.X = (float)x;
            if (y != null)
                position.Y = (float)y;
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                if (flipAnimation)
                    return new Rectangle((int)Position.X - 20, (int)Position.Y, (texture.Width / 2), (texture.Height / 2));
                else
                    return new Rectangle((int)Position.X - 10, (int)Position.Y, (texture.Width / 2), (texture.Height / 2));
            }
        }

        public bool IsHit { get; set; }

        public Projectile(Texture2D _texture, Vector2 _position, bool _flipAnimation)
        {
            texture = _texture;
            ChangeVelocity(MovementSpeed, 0);
            Position = _position;
            flipAnimation = _flipAnimation;
            if (flipAnimation)
                ChangePosition(Position.X, Position.Y + 30);
            if (!flipAnimation)
                ChangePosition(Position.X + 35, Position.Y + 30);
            spawnPosition = _position;     
        }
        /// <summary>
        /// Update de positie van het projectiel
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (flipAnimation)
            {
                Position -= Velocity;
                if (Position.X < spawnPosition.X - 280)
                    return true;
            }
            else
            {
                Position += Velocity;
                if (Position.X > spawnPosition.X + 280)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Tekent het projectiel
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 0.6f, flipAnimation ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 1f);
        }
    }
}
