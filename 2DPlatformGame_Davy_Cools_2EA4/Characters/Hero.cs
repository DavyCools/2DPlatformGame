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
    public class Hero : ICollide
    {
        Texture2D texture;
        public Vector2 position;
        Animation animation;
        Animation heroAttackAnimation;
        Animation heroRunAnimation;
        Animation heroDieAnimation;
        Animation heroJumpAnimation;
        Animation heroIdleAnimation;
        bool flipAnimation = false;
        public Movement _Movement { get; set; }
        public bool TouchingGround = false;
        public bool TouchingLeft = false;
        public bool TouchingRight = false;
        public bool TouchingTop = false;
        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)position.X, (int)position.Y, 44, 58); }   //Standaard 44,62 => 4 pixels correctie in de hoogte voor een mooi beeld
        }

        public Vector2 Velocity;
        public Hero(ContentManager content)
        {
            texture = content.Load<Texture2D>("IceWizard");
            position = new Vector2(70, 0);
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
            //Velocity = _Movement.Update(Velocity);
            
            if (_Movement.Jump)
            {
                animation = heroJumpAnimation;
            }
            if (_Movement.Left)
            {
                if (Velocity.Y == 0)
                    animation = heroRunAnimation;
                flipAnimation = true;
            }               
            if (_Movement.Right)
            {
                if (Velocity.Y == 0)
                    animation = heroRunAnimation;
                flipAnimation = false;
            }
            if (_Movement.Shoot)
            {
                if (Velocity.Y == 0)
                    animation = heroAttackAnimation;
            }
            if (Velocity.X == 0 && Velocity.Y == 0)
            {
                animation = heroIdleAnimation;
            }
            //if (!TouchingGround && Velocity.Y == 0)
            //{
            //    Velocity.Y = 0.2f;
            //}
            _Movement.Update(this);
            animation.Update(gameTime);      
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, animation.CurrentFrame.scale,flipAnimation?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f); 
        }
    }
}
