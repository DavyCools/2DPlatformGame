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
    class Hero
    {
        Texture2D texture;
        public Vector2 position;
        public Rectangle CollisionDetection;
        Animation animation;
        Animation heroAttackAnimation;
        Animation heroRunAnimation;
        Animation heroDieAnimation;
        Animation heroJumpAnimation;
        Animation heroIdleAnimation;
        bool flipAnimation = false;
        public Movement _Movement { get; set; }
        public Vector2 Velocity;
        public Hero(ContentManager content)
        {
            texture = content.Load<Texture2D>("IceWizard");
            position = new Vector2(50, 140);
            CollisionDetection = new Rectangle((int)position.X,(int)position.Y,300,220);
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
            Velocity = _Movement.Update(Velocity);
            position += Velocity;
            if (position.Y >= 140)
            {
                Velocity.Y = 0f;
            }
            if (_Movement.Left)
            {
                animation = heroRunAnimation;
                flipAnimation = true;
            }               
            else if (_Movement.Right)
            {
                animation = heroRunAnimation;
                flipAnimation = false;
            }
            else if (_Movement.Jump)
            {
                animation = heroJumpAnimation;
            }
            else if (_Movement.Shoot)
            {
                animation = heroAttackAnimation;
            }
            else
            {
                animation = heroIdleAnimation;
            }
            CollisionDetection.X = (int)position.X;
            CollisionDetection.Y = (int)position.Y;
            animation.Update(gameTime);      
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, animation.CurrentFrame.scale,flipAnimation?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f); 
        }
        public Rectangle GetCollisionRectangle()
        {
            return CollisionDetection;
        }
    }
}
