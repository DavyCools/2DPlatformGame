using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    public class Hero : IMoveableObject
    {
        Texture2D texture;
        //public Vector2 Position;
        //public Vector2 Velocity;
        Animation animation, heroAttackAnimation, heroRunAnimation, heroDieAnimation, heroJumpAnimation, heroIdleAnimation;
        bool flipAnimation = false;
        public Movement _Movement { get; set; }
        //public bool TouchingGround = false;
        //public bool TouchingLeft = false;
        //public bool TouchingRight = false;
        //public bool TouchingTop = false;
        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, 44, 58); }   //Standaard 44,62 => 4 pixels correctie in de hoogte voor een mooi beeld
        }
        //public Vector2 Position { get; set; }
        public bool TouchingGround { get; set; }
        public bool TouchingLeft { get; set; }
        public bool TouchingRight { get; set; }
        public bool TouchingTop { get; set; }
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
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float MovementSpeed => 3f;
        public void ChangePosition(float? x, float? y)
        {
            if (x != null)
                position.X = (float)x;
            if (y != null)
                position.Y = (float)y;
        }

        public Hero(ContentManager content)
        {
            texture = content.Load<Texture2D>("IceWizard");
            Position = new Vector2(70, 0);
            Velocity = new Vector2(2, 0);
            heroAttackAnimation = new HeroAttackAnimation();
            heroRunAnimation = new HeroRunAnimation();
            heroDieAnimation = new HeroDieAnimation();
            heroJumpAnimation = new HeroJumpAnimation();
            heroIdleAnimation = new HeroIdleAnimation();
            animation = heroIdleAnimation; 
        }

        public void Update(GameTime gameTime)
        {   
            if (_Movement.Jump)
            {
                animation = heroJumpAnimation;
                if (Velocity.X >= 0)
                {
                    flipAnimation = false;
                }
                else
                {
                    flipAnimation = true;
                }
            }
            else if (_Movement.Left)
            {
                if (Velocity.Y == 0)
                    animation = heroRunAnimation;
                flipAnimation = true;
            }               
            else if (_Movement.Right)
            {
                if (Velocity.Y == 0)
                    animation = heroRunAnimation;
                flipAnimation = false;
            }
            else if (_Movement.Shoot)
            {
                if (Velocity.Y == 0)
                    animation = heroAttackAnimation;
            }
            else
            {
                animation = heroIdleAnimation;
            }
            _Movement.Update(this);
            animation.Update(gameTime);      
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, animation.CurrentFrame.scale,flipAnimation?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f); 
        }
    }
}
