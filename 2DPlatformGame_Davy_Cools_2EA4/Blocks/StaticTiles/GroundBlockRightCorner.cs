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
    /// Deze klasse GroundBlockRightCorner is verantwoordelijk voor
    /// het juiste gedrag van de GroundBlockRightCorner
    /// Erft over van: StaticTiles
    /// </summary>
    class GroundBlockRightCorner : StaticTiles
    {
        public GroundBlockRightCorner(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
        }
    }
}
