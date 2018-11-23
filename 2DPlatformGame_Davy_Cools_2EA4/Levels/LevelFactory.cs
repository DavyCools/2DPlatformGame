﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Verantwoordelijk voor het aanmaken van de juist blok
    /// </summary>
    public class LevelFactory : AbstractLevelFactory
    {
        protected override StaticBlock CreateBlok(int id,ContentManager content, Vector2 _position)
        {
            StaticBlock b = null;
            if (id == 1)
                b = new GroundBlock(content, _position, "GroundBlock");
            else if (id == 2)
                b = new GroundBlockLeft(content, _position, "GroundBlockLeft");
            else if (id == 3)
                b = new GroundBlockRight(content, _position, "GroundBlockRight");
            else if (id == 4)
                b = new GroundBlockFiller(content, _position, "GroundBlockFiller");
            else if (id == 5)
                b = new GroundBlockLeftCorner(content, _position, "GroundBlockLeftCorner");
            else if (id == 6)
                b = new GroundBlockRightCorner(content, _position, "GroundBlockRightCorner");
            else if (id == 7)
                b = new GroundBlockAlone(content, _position, "GroundBlockAlone");
            else if (id == 8)
                b = new WallBlockLeft(content, _position, "WallBlockLeft");
            else if (id == 9)
                b = new WallBlockRight(content, _position, "WallBlockRight");
            else if (id == 10)
                b = new GroundBlockFillerLeft(content, _position, "GroundBlockFillerLeft");
            else if (id == 11)
                b = new GroundBlockFillerRight(content, _position, "GroundBlockFillerRight");
            else if (id == 12)
                b = new Lava(content, _position, "Lava");
            else if (id == 13)
                b = new LavaFiller(content, _position, "LavaFiller");
            else if (id == 14)
                b = new GroundBlockFillerBoth(content, _position, "GroundBlockFillerBoth");
            return b;
        }
    }
}
