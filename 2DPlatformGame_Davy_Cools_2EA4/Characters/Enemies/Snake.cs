﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (Snake) is verantwoordelijk
    /// voor de specifieke eigenschappen van een snake
    /// Erft over van: Enemy
    /// </summary>
    class Snake : Enemy
    {
        public Snake(ContentManager content, Vector2 position, string name) : base(content, position, name)
        {
            animation = new SnakeAnimation() {scale = 0.7f};
        }
        public override Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, (int)(48 * animation.scale)-8, (int)(48 * animation.scale) - 8); }
        }
    }
}
