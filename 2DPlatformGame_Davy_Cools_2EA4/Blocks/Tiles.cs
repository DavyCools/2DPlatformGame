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
    /// Deze abstracte klasse Tiles is verantwoordelijk
    /// voor de algeme functies van een Tile
    /// Erft over van IDrawObject
    /// </summary>
    abstract class Tiles : IDrawObject
    {
        protected Texture2D texture;
        public Vector2 Position { get; set; }
        public Tiles(ContentManager content, Vector2 _position, string name)
        {
            texture = content.Load<Texture2D>(name);
            Position = _position;
        }
        /// <summary>
        /// Tekent de tile op het scherm
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.AliceBlue);
            //spriteBatch.Draw(texture, CollisionRectangle.Location.ToVector2(), new Rectangle(0, 0, 70, 70), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            //spriteBatch.Draw(texture, Position, new Rectangle(0,0,70,70), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
