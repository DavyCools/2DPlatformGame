﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        ContentManager content;
        AbstractLevelFactory levelFactory;
        public Level(ContentManager _content)
        {
            CreateLevelArray();
            BlockArray = new Block[LevelArray.GetLength(0), LevelArray.GetLength(1)];
            content = _content;
            levelFactory = new LevelFactory();
        }
        protected abstract void CreateLevelArray();
        public byte[,] LevelArray;
        public Block[,] BlockArray;
        public void CreateLevel(List<ICollide> CollisionList)
        {
            for (int x = 0; x < BlockArray.GetLength(0); x++)
            {
                for (int y = 0; y < BlockArray.GetLength(1); y++)
                {
                    if (LevelArray[x, y] != 0)
                    {
                        BlockArray[x, y] = levelFactory.GetExactBlock((int)LevelArray[x, y],content, new Vector2(y * 70, x * 70),CollisionList);
                        //BlockArray[x, y] = new Block(content, new Microsoft.Xna.Framework.Vector2(y * 128, x * 64));
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
