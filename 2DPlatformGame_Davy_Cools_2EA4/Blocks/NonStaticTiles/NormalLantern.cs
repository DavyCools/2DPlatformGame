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
    /// Deze klasse NormalLantern is verantwoordelijk voor
    /// het juiste gedrag van de NormalLantern
    /// Erft over van: NonStaticTiles
    /// </summary>
    class NormalLantern : NonStaticTiles
    {
        public NormalLantern(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            Position = new Vector2(Position.X + 19, Position.Y - 100);
        }
    }
}
