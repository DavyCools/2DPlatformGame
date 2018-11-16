using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    abstract class Level
    {
        public Level()
        {
            CreateLevelArray();
            BlockArray = new Block[LevelArray.GetLength(0), LevelArray.GetLength(1)];
            CreateWorld();
        }
        protected abstract void CreateLevelArray();
        public Texture2D Texture;
        public byte[,] LevelArray;
        public Block[,] BlockArray;
        public void CreateWorld()
        {
            for (int x = 0; x < BlockArray.GetLength(0); x++)
            {
                for (int y = 0; y < BlockArray.GetLength(1); y++)
                {
                    if (LevelArray[x, y] == 1)
                    {
                        BlockArray[x, y] = new Block(Texture, new Microsoft.Xna.Framework.Vector2(y * 128, x * 64));
                    }
                }
            }
        }
        public void DrawLevel(SpriteBatch spritebatch)
        {
            for (int x = 0; x < BlockArray.GetLength(0); x++)
            {
                for (int y = 0; y < BlockArray.GetLength(1); y++)
                {
                    if (BlockArray[x, y] != null)
                    {
                        BlockArray[x, y].Draw(spritebatch);
                    }
                }
            }
        }
    }
}
