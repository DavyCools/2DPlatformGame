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
    class Coin : CollectAbleTiles
    {
        bool one = true;
        bool two = false;
        public Coin(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            animation = new CoinAnimation();
            Position += new Vector2(21, 20);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (animation.CurrentFrame == animation.frames[0] && one)
            {
                Position -= new Vector2(1, 0);
                one = false;
                two = true;
            }
            if (animation.CurrentFrame == animation.frames[1] && two)
            {
                Position += new Vector2(1, 0);
                one = true;
                two = false;
            }
            if (animation.CurrentFrame == animation.frames[2] && one)
            {
                Position += new Vector2(6, 0);
                one = false;
                two = true;
            }
            if (animation.CurrentFrame == animation.frames[3] && two)
            {
                Position += new Vector2(4, 0);
                one = true;
                two = false;
            }
            if (animation.CurrentFrame == animation.frames[4] && one)
            {
                Position -= new Vector2(4, 0);
                one = false;
                two = true;
            } 
            if (animation.CurrentFrame == animation.frames[5] && two)
            {
                Position -= new Vector2(6, 0);
                one = true;
                two = false;
            }    
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
        }
        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, 25, 25);
    }
}
