using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    public class FireBall : IMoveableObject
    {
        Texture2D Texture;
        private bool flipAnimation;
        private Vector2 spawnPosition;
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
        public void ChangePosition(float? x, float? y)
        {
            if (x != null)
                position.X = (float)x;
            if (y != null)
                position.Y = (float)y;
        }

        public Rectangle CollisionRectangle => throw new NotImplementedException();

        public FireBall(Texture2D texture, Vector2 _position, bool _direction)
        {
            Texture = texture;
            ChangeVelocity(MovementSpeed, 0);
            Position = _position;
            flipAnimation = _direction;
            if(flipAnimation)
                Position += new Vector2(0,30);
            if(!flipAnimation)
                Position += new Vector2(35, 30);
            spawnPosition = Position;
            
        }
        public bool Update()
        {
            if (flipAnimation)
            {
                Position -= Velocity;
                if (Position.X < spawnPosition.X - 280)
                    return true;
            }   
            else{
                Position += Velocity;
                if (Position.X > spawnPosition.X + 280)
                    return true;
            }               
            return false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Position,null,Color.White,0f,new Vector2(Texture.Width/2,Texture.Height/2),0.6f, flipAnimation ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 1f);
        }
    }
}
