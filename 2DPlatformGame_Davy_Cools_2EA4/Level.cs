using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class Level
    {
        public Texture2D Texture;
        public byte[,] Level1 = new byte[,]
        {
            { 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0 },
            { 1,0,1,0,1,0,0,0,0,1 },
            { 0,1,0,1,0,1,1,1,1,1 },
        };
        public Block[,] BlockArray = new Block[6,10];
        public void CreateWorld()
        {
            for (int x = 0; x < BlockArray.GetLength(0); x++)
            {
                for (int y = 0; y < BlockArray.GetLength(1); y++)
                {
                    if (Level1[x, y] == 1)
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
