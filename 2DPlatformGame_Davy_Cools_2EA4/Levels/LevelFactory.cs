using System;
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
    /// Deze klasse (LevelFactory) is verantwoordelijk voor
    /// het aanmaken van de juist blok
    /// Erft over van: AbstractLevelFactory
    /// </summary>
    class LevelFactory : AbstractLevelFactory
    {
        /// <summary>
        /// Maakt het juiste object aan
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        protected override IDrawObject CreateObject(int id,ContentManager content, Vector2 position)
        {
            IDrawObject b = null;
            if (id == 1)
                b = new GroundBlock(content, position, "GroundBlock");
            else if (id == 2)
                b = new GroundBlockLeft(content, position, "GroundBlockLeft");
            else if (id == 3)
                b = new GroundBlockRight(content, position, "GroundBlockRight");
            else if (id == 4)
                b = new GroundBlockFiller(content, position, "GroundBlockFiller");
            else if (id == 5)
                b = new GroundBlockLeftCorner(content, position, "GroundBlockLeftCorner");
            else if (id == 6)
                b = new GroundBlockRightCorner(content, position, "GroundBlockRightCorner");
            else if (id == 7)
                b = new GroundBlockAlone(content, position, "GroundBlockAlone");
            else if (id == 8)
                b = new WallBlockLeft(content, position, "WallBlockLeft");
            else if (id == 9)
                b = new WallBlockRight(content, position, "WallBlockRight");
            else if (id == 10)
                b = new GroundBlockFillerLeft(content, position, "GroundBlockFillerLeft");
            else if (id == 11)
                b = new GroundBlockFillerRight(content, position, "GroundBlockFillerRight");
            else if (id == 12)
                b = new Lava(content, position, "Lava");
            else if (id == 13)
                b = new LavaFiller(content, position, "LavaFiller");
            else if (id == 14)
                b = new GroundBlockFillerBoth(content, position, "GroundBlockFillerBoth");
            else if (id == 15)
                b = new ArrowTileRight(content, position, "ArrowTileRight");
            else if (id == 16)
                b = new SignTileHaveFun(content, position, "SignTileHaveFun");
            else if (id == 17)
                b = new SignTileLevel1(content, position, "SignTileLevel1");
            else if (id == 18)
                b = new SignTileLava(content, position, "SignTileLava");
            else if (id == 19)
                b = new Coin(content, position, "CoinSprite");
            else if (id == 20)
                b = new GroundBlockHalf(content, position, "GroundBlockHalf",2) { TouchingLeft = true, TouchingRight = false };
            else if (id == 21)
                b = new GroundBlockHalf(content, position, "GroundBlockHalf",2) { TouchingLeft = false, TouchingRight = true };
            else if (id == 22)
                b = new GroundBlockHalf(content, position, "GroundBlockHalf", 1) { TouchingLeft = true, TouchingRight = false };
            else if (id == 23)
                b = new GroundBlockHalf(content, position, "GroundBlockHalf", 1) { TouchingLeft = false, TouchingRight = true };
            else if (id == 24)
                b = new SpikeTileSteel(content, position, "SpikeTileSteel");
            else if (id == 25)
                b = new SpikeGroundTrap(content, position, "SpikeGroundTrap");
            else if (id == 50)
                b = new Gremlin(content, position, "GremlinSheet");
            else if (id == 51)
                b = new Plant(content, position, "PlantSheet");
            else if (id == 52)
                b = new FloatEye(content, position, "FloatEyeSheet");
            else if (id == 53)
                b = new Snake(content, position, "SnakeSheet");
            else if (id == 54)
                b = new Beetle(content, position, "BeetleSheet");
            else if (id == 55)
                b = new Flame(content, position, "Flame");
            else if (id == 75)
                b = new DoorTile(content, position, "DoorTile");
            else if (id == 76)
                b = new NormalLantern(content, position, "NormalLantern");
            else if (id == 77)
                b = new Bench(content, position, "Bench");
            else if (id == 78)
                b = new NormalTree(content, position, "NormalTree");
            else if (id == 79)
                b = new NormalSmallTree(content, position, "NormalSmallTree");
            else if (id == 80)
                b = new NormalBushLeft(content, position, "NormalBushLeft");
            else if (id == 81)
                b = new NormalBushRight(content, position, "NormalBushRight");
            else if (id == 82)
                b = new BigTree(content, position, "BigTree");
            else if (id == 83)
                b = new BigTree2(content, position, "BigTree2");
            else if (id == 84)
                b = new GrassBlock(content, position, "GrassBlock");
            else if (id == 85)
                b = new DirtBlockFiller(content, position, "DirtBlockFiller");
            else if (id == 99)
                b = new InvisibleTile(content, position, "InvisibleTile");
            return b;
        }
    }
}
