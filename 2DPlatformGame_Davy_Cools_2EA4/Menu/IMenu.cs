﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    public interface IMenu
    {
        void Draw(SpriteBatch spriteBatch, int MiddleScreenWidth);
        void Update(GameTime gameTime);
    }
}
