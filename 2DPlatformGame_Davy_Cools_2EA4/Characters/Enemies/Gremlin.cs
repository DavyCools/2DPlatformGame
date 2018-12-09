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
    /// <summary>
    /// Deze klasse (Gremlin) is verantwoordelijk
    /// voor de specifieke eigenschappen van een gremlin
    /// Erft over van: Enemy, IKillable
    /// </summary>
    class Gremlin : Enemy, IKillable
    {
        public Gremlin(ContentManager content,Vector2 position, string name) : base(content,position, name)
        {
            animation = new GremlinAnimation() {scale = 0.7f};
        }
    }
}
