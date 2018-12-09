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
    /// Deze klasse GroundBlockLeftCorner is verantwoordelijk voor
    /// het juiste gedrag van de GroundBlockLeftCorner
    /// Erft over van: StaticTiles
    /// </summary>
    class GroundBlockLeftCorner : StaticTiles
    {
        public GroundBlockLeftCorner(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
        }
    }
}
