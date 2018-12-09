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
    /// <summary>
    /// Deze klasse Coin is verantwoordelijk voor
    /// het juiste gedrag van de Coin
    /// Erft over van: CollectableTiles
    /// </summary>
    class Coin : CollectableTiles
    {
        private bool firstFrame = true;
        private bool SecondFrame = false;
        public Coin(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            animation = new CoinAnimation() {scale = 0.1f};
            Position += new Vector2(21, 20);
        }
        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y, 25, 25);
        /// <summary>
        /// Tekent de coin op het scherm
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (animation.CurrentFrame == animation.frames[0] && firstFrame)
            {
                Position -= new Vector2(1, 0);
                firstFrame = false;
                SecondFrame = true;
            }
            if (animation.CurrentFrame == animation.frames[1] && SecondFrame)
            {
                Position += new Vector2(1, 0);
                firstFrame = true;
                SecondFrame = false;
            }
            if (animation.CurrentFrame == animation.frames[2] && firstFrame)
            {
                Position += new Vector2(6, 0);
                firstFrame = false;
                SecondFrame = true;
            }
            if (animation.CurrentFrame == animation.frames[3] && SecondFrame)
            {
                Position += new Vector2(4, 0);
                firstFrame = true;
                SecondFrame = false;
            }
            if (animation.CurrentFrame == animation.frames[4] && firstFrame)
            {
                Position -= new Vector2(4, 0);
                firstFrame = false;
                SecondFrame = true;
            } 
            if (animation.CurrentFrame == animation.frames[5] && SecondFrame)
            {
                Position -= new Vector2(6, 0);
                firstFrame = true;
                SecondFrame = false;
            }    
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, animation.scale, SpriteEffects.None, 0f);
        }
    }
}
