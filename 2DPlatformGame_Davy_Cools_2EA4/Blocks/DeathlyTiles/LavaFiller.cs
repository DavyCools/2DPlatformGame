﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class LavaFiller : StaticTiles, IDeathly
    {
        public bool IsHit { get; set; }
        public LavaFiller(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
        }
    }
}
