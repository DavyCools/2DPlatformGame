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
    /// Deze klasse Bench is verantwoordelijk voor
    /// het juiste gedrag van de Bench
    /// Erft over van: NonStaticTiles
    /// </summary>
    class Bench : NonStaticTiles
    {
        public Bench(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            Position = new Vector2(Position.X, Position.Y + 21);
        }
    }
}
