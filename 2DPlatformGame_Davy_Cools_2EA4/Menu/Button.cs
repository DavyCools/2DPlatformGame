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
    /// <summary>
    /// Deze klasse (Button) is verantwoordelijk
    /// voor het juiste gedrag van een knop
    /// Erft over van: ICollide
    /// </summary>
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
        /// <summary>
        /// Tekent de knop op het scherm
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ButtonTexture, position, null, Color.AliceBlue, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
        /// <summary>
        /// Kijkt na of er op de knop is gedrukt
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        public bool CheckClicked(MouseState mouse)
        {
            if (CollisionRectangle.Intersects(new Rectangle(mouse.X,mouse.Y,0,0)) && mouse.LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }
    }
}
