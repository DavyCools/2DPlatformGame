using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class Button : ICollide
    {
        public Texture2D ButtonTexture;
        public float Scale;
        Vector2 position;
        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)position.X, (int)position.Y, (int)(ButtonTexture.Width * Scale), (int)(ButtonTexture.Height * Scale)); } 
        }
        public Button(Vector2 _position)
        {
            position = _position;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ButtonTexture, position, null, Color.AliceBlue, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
        public bool CheckClicked(MouseState mouse)
        {
            if (CollisionRectangle.Intersects(new Rectangle(mouse.X,mouse.Y,0,0)) && mouse.LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }
    }
}
