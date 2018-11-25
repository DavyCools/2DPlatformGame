using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class FireBall
    {
        Texture2D Texture;
        Vector2 Position;
        bool Direction;
        float Speed;
        public FireBall(Texture2D texture, Vector2 position, bool direction)
        {
            Speed = 5;
            Texture = texture;
            Position = position;
            Position.X += 50;
            Position.Y += 25;
            Direction = direction;
        }
        public void Update()
        {
            Position.X += Speed;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Position,null,Color.White,0f,new Vector2(Texture.Width/2,Texture.Height/2),0.6f,SpriteEffects.None,1f);
        }
    }
}
