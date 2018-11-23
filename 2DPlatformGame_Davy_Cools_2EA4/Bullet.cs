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
        Texture2D Texture;
        Vector2 Position;
        bool Direction = false;
        float Speed { get; set; }
        int ActiveTime { get; set; }
        int TotalActiveTime { get; set; }
        public Bullet(Texture2D texture, Vector2 position, bool direction, int activeTime)
        {
            Speed = 2;
            Texture = texture;
            Position = position;
            Direction = direction;
            ActiveTime = activeTime;
            TotalActiveTime = 0;
        }
        //public void Update(GameTime gameTime)
        public int Update(int test)
        {
            test++;
            Position.X += Speed;
            return test;
            //TotalActiveTime += gameTime.ElapsedGameTime.Milliseconds;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Position,null,Color.White,0f,new Vector2(Texture.Width/2,Texture.Height/2),1f,SpriteEffects.None,1f);
        }
    }
}
