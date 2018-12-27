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
    /// Deze klasse SignTileLevel2 is verantwoordelijk voor
    /// het juiste gedrag van de SignTileLevel2
    /// Erft over van: NonStaticTiles
    /// </summary>
    class SignTileLevel2 : NonStaticTiles
    {
        public SignTileLevel2(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
        }
    }
}
