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
    /// Deze klasse (Beetle) is verantwoordelijk voor
    /// voor de specifieke eigenschappen van een Beetle
    /// Erft over van: Enemy, IKillable
    /// </summary>
    class Beetle : Enemy, IKillable
    {
        public Beetle(ContentManager content, Vector2 position, string name) : base(content, position, name)
        {
            animation = new BeetleAnimation() { scale = 0.7f };
            
        }
        public override float MovementSpeed => 2.2f;
        public override Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, (int)(48 * animation.scale), (int)(48 * animation.scale)-8); }
        }
    }
}
