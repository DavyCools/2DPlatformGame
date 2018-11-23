using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class Bullet
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public int ActiveTime { get; set; }
        public int TotalActiveTime { get; set; }
        public Bullet(Texture2D texture, Vector2 position, Vector2 direction,float speed, int activeTime)
        {
            Texture = texture;
            Position = position;
            Direction = direction;
            Speed = speed;
            ActiveTime = activeTime;
            TotalActiveTime = 0;
        }
        public void Update(GameTime gameTime)
        {
            
            Position = Direction * Speed;
            TotalActiveTime += gameTime.ElapsedGameTime.Milliseconds;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Position,null,Color.White,0f,new Vector2(Texture.Width/2,Texture.Height/2),1f,SpriteEffects.None,1f);
        }
    }
}
