using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse BigTree2 is verantwoordelijk voor
    /// het juiste gedrag van de BigTree2
    /// Erft over van: NonStaticTiles
    /// </summary>
    class BigTree2 : NonStaticTiles
    {
        public BigTree2(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            Position = new Vector2(Position.X - 140, Position.Y - 320 + 70);
        }
    }
}
