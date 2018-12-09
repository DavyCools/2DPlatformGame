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
    /// Deze klasse SignTileLevel1 is verantwoordelijk voor
    /// het juiste gedrag van de SignTileLevel1
    /// Erft over van: NonStaticTiles
    /// </summary>
    class SignTileLevel1 : NonStaticTiles
    {
        public SignTileLevel1(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
        }
    }
}
