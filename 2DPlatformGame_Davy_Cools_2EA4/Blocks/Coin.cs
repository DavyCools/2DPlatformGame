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
    class Coin : StaticTiles, IUpdate
    {
        Animation coinAnimation;
        bool one = true;
        bool two = true;
        bool three = true;
        bool four = true;
        bool five = true;
        bool six = true;
        public Coin(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            coinAnimation = new CoinAnimation();
            Position += new Vector2(21, 20);
        }
        public void Update(GameTime gameTime)
        {
            coinAnimation.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (coinAnimation.CurrentFrame == coinAnimation.frames[0] && one)
            {
                Position -= new Vector2(1, 0);
                one = false;
                six = true;
            }
            if (coinAnimation.CurrentFrame == coinAnimation.frames[1] && two)
            {
                Position += new Vector2(1, 0);
                two = false;
                one = true;
            }
            if (coinAnimation.CurrentFrame == coinAnimation.frames[2] && three)
            {
                Position += new Vector2(6, 0);
                three = false;
                two = true;
            }
            if (coinAnimation.CurrentFrame == coinAnimation.frames[3] && four)
            {
                Position += new Vector2(4, 0);
                four = false;
                three = true;
            }
            if (coinAnimation.CurrentFrame == coinAnimation.frames[4] && five)
            {
                Position -= new Vector2(4, 0);
                five = false;
                four = true;
            } 
            if (coinAnimation.CurrentFrame == coinAnimation.frames[5] && six)
            {
                Position -= new Vector2(6, 0);
                six = false;
                five = true;
            }    
            spriteBatch.Draw(texture, Position, coinAnimation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
        }
        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, 25, 25);
    }
}
