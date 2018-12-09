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
    /// Deze klasse NormalTree is verantwoordelijk voor
    /// het juiste gedrag van de NormalTree
    /// Erft over van: NonStaticTiles
    /// </summary>
    class NormalTree : NonStaticTiles
    {
        public NormalTree(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            Position = new Vector2(Position.X + 10, Position.Y - 111);
        }
    }
}
