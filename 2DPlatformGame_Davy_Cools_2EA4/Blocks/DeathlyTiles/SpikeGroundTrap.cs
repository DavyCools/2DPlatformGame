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
    /// Deze klasse SpikeGroundTrap is verantwoordelijk voor
    /// het juiste gedrag van de SpikeGroundTrap
    /// Erft over van: StaticTiles, IDeathly
    /// </summary>
    class SpikeGroundTrap : StaticTiles, IDeathly
    {
        public bool IsHit { get; set; }
        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X + 6, (int)Position.Y, 60, 39);
        public SpikeGroundTrap(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            Position = new Vector2(Position.X, Position.Y + 31);
        }
    }
}
