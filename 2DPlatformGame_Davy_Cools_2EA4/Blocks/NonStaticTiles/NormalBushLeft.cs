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
    /// Deze klasse NormalBushLeft is verantwoordelijk voor
    /// het juiste gedrag van de NormalBushLeft
    /// Erft over van: NonStaticTiles
    /// </summary>
    class NormalBushLeft : NonStaticTiles
    {
        public NormalBushLeft(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
            Position = new Vector2(Position.X, Position.Y - 3);
        }
    }
}
