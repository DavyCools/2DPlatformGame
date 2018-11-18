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

        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)position.X, (int)position.Y, 300, 220); }
        }

        public Vector2 Velocity;
        public Hero(ContentManager content)
        {
            texture = content.Load<Texture2D>("IceWizard");
            position = new Vector2(50, 140);
            //CollisionRectangle = new Rectangle((int)position.X,(int)position.Y,300,220); 
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
            if (_Movement.Jump)
            {
                animation = heroJumpAnimation;
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
                if (Velocity.Y == 0)
                    animation = heroIdleAnimation;
            }
            animation.Update(gameTime);      
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, animation.CurrentFrame.scale,flipAnimation?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f); 
        }
    }
}
