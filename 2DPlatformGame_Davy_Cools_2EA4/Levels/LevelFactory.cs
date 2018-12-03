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
    class LevelFactory : AbstractLevelFactory
    {
        protected override IDrawObject CreateBlok(int id,ContentManager content, Vector2 _position)
        {
            IDrawObject b = null;
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
            else if (id == 15)
                b = new ArrowTileRight(content, _position, "ArrowTileRight");
            else if (id == 16)
                b = new SignTileHaveFun(content, _position, "SignTileHaveFun");
            else if (id == 17)
                b = new SignTileLevel1(content, _position, "SignTileLevel1");
            else if (id == 18)
                b = new SignTileLava(content, _position, "SignTileLava");
            else if (id == 19)
                b = new Coin(content, _position, "CoinSprite");
            else if (id == 20)
                b = new GroundBlockHalf(content, _position, "GroundBlockHalf") { TouchingLeft = true, TouchingRight = false };
            else if (id == 21)
                b = new GroundBlockHalf(content, _position, "GroundBlockHalf") { TouchingLeft = false, TouchingRight = true };
            else if (id == 50)
                b = new Gremlin(content, _position, "GremlinSheet");
            else if (id == 51)
                b = new Plant(content, _position, "PlantSheet");
            else if (id == 52)
                b = new FloatEye(content, _position, "FloatEyeSheet");
            return b;
        }
    }
}
