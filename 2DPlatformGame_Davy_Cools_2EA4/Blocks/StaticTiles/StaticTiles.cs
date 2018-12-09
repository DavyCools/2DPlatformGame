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
    /// Deze abstracte klasse StaticTiles is verantwoordelijk voor
    /// het juiste gedrag van de StaticTiles
    /// Erft over van: Tiles, ICollide
    /// </summary>
    abstract class StaticTiles : Tiles, ICollide
    {
        public StaticTiles(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
        }
        public virtual Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height); }
        }
    }
}
