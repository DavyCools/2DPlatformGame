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
    /// <summary>
    /// Deze klasse (hero) is verantwoordelijk voor 
    /// het gedrag van de held
    /// Erft over van: IMoveableObject, IUpdate, IDrawObject, IDeathly
    /// </summary>
    public class Hero : IMoveableObject, IUpdate, IDrawObject, IDeathly
    {
        List<IMoveableObject> projectileList;
        Texture2D bulletTexture;
        bool CanShootFireBall = true;
        public int TotalCoins = 0;
        private int totalLives = 3;
        public int Lives { get { return totalLives; } set { totalLives = value; } }
        public bool IsHit { get; set; }
        Texture2D texture;
        Animation animation, heroAttackAnimation, heroRunAnimation, heroDieAnimation, heroJumpAnimation, heroIdleAnimation, heroHitAnimation;
        bool flipAnimation = false;
        public Movement _Movement { get; set; }
        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, 44, 58); }   //Standaard 44,62 => 4 pixels correctie in de hoogte voor een mooi beeld
        }
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
            projectileList = new List<IMoveableObject>();
            bulletTexture = content.Load<Texture2D>("Bullet");
            texture = content.Load<Texture2D>("IceWizard");
            Position = new Vector2(70, 770);
            Velocity = new Vector2(2, 0);
            heroAttackAnimation = new HeroAttackAnimation();
            heroRunAnimation = new HeroRunAnimation();
            heroDieAnimation = new HeroDieAnimation();
            heroJumpAnimation = new HeroJumpAnimation();
            heroIdleAnimation = new HeroIdleAnimation();
            heroHitAnimation = new HeroHitAnimation();
            animation = heroIdleAnimation;
        }
        /// <summary>
        /// Zorgt voor het juiste gedrag van de hero
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (projectileList != null)
                UpdateProjectiles();
            if (IsHit && totalLives != 0 && animation != heroHitAnimation)
            {
                totalLives--;
                IsHit = false;
                animation = heroHitAnimation;
            }
            if (totalLives == 0)
            {
                if(animation != heroDieAnimation)
                {
                    heroDieAnimation = new HeroDieAnimation();
                    animation = heroDieAnimation;
                }
                if(animation.CurrentFrame != animation.frames[animation.frames.Count - 1])
                    animation.Update(gameTime);
                else
                    IsHit = false;     
            }
            else if(animation == heroHitAnimation)
            {
                if(animation.CurrentFrame != animation.frames[animation.frames.Count - 1])
                    animation.Update(gameTime);
                else if(totalLives != 0)
                {
                    animation = heroIdleAnimation;
                    heroHitAnimation = new HeroHitAnimation();
                    Position = new Vector2(70, 770);
                    IsHit = false;
                }
            }
            else
            {
                if (_Movement.Jump)
                {
                    animation = heroJumpAnimation;
                    if (Velocity.X >= 0 && !_Movement.Left)
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
                    {
                        animation = heroAttackAnimation;
                        Shoot();
                    }
                }
                else
                {
                    animation = heroIdleAnimation;
                }
                _Movement.Update(this);
                animation.Update(gameTime);
                TouchingGround = false;
                TouchingLeft = false;
                TouchingRight = false;
                TouchingTop = false;
            }   
        }
        /// <summary>
        /// Tekent de hero op het scherm en roept voor elke kogel de methode Draw op
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, animation.scale, flipAnimation ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            foreach (FireBallBlue _bullet in projectileList)
            {
                _bullet.Draw(spriteBatch);
            }
        }
        public List<IMoveableObject> GetFireBalls()
        {
            return projectileList;
        }
        /// <summary>
        /// Juiste gedrag voor een projectiel af te vuren
        /// </summary>
        private void Shoot()
        {
            if(CanShootFireBall && animation.CurrentFrame == animation.frames[6])
            {
                AddProjectile();
                CanShootFireBall = false;
            }
            if (animation.CurrentFrame != animation.frames[6])
                CanShootFireBall = true;
        }
        /// <summary>
        /// Voegt een projectiel toe aan de lijst
        /// </summary>
        private void AddProjectile()
        {
            projectileList.Add(new FireBallBlue(bulletTexture, position, flipAnimation));
        }
        /// <summary>
        /// Roept de Update methode toe voor elk projectiel
        /// </summary>
        private void UpdateProjectiles()
        {
            foreach (FireBallBlue _bullet in projectileList.ToList())
            {
                bool remove = _bullet.Update();
                if (remove || _bullet.IsHit)
                {
                    projectileList.Remove(_bullet);
                }
            }
        }
    }
}
