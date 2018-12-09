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
    /// Deze klasse SpikeTileSteel is verantwoordelijk voor
    /// het juiste gedrag van de SpikeTileSteel
    /// Erft over van: StaticTiles, IDeathly
    /// </summary>
    class SpikeTileSteel : StaticTiles, IDeathly
    {
        public bool IsHit { get; set; }
        public SpikeTileSteel(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
        }
    }
}
