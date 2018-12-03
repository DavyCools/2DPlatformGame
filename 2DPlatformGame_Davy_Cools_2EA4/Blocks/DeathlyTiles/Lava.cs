using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class Lava : StaticTiles, IDeathly
    {
        public bool IsHit { get; set; }
        public Lava(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
        }
        public override Rectangle CollisionRectangle => new Rectangle((int)Position.X, (int)Position.Y+40, 70,30);
    }
}
