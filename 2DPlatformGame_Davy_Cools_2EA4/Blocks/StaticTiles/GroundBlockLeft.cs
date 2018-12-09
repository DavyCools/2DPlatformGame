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
    /// Deze klasse GroundBlockLeft is verantwoordelijk voor
    /// het juiste gedrag van de GroundBlockLeft
    /// Erft over van: StaticTiles
    /// </summary>
    class GroundBlockLeft : StaticTiles
    {
        public GroundBlockLeft(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
        }
    }
}
