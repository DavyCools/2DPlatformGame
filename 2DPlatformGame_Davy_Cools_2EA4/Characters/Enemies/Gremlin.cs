using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class Gremlin : Enemy
    {
        public Gremlin(ContentManager content,Vector2 position, string name) : base(content,position, name)
        {
            animation = new GremlinAnimation();
            animation.scale = 0.7f;
        }
    }
}
