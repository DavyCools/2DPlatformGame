using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (Level) is verantwoordelijk voor
    /// voor het aanmaken van een level.
    /// </summary>
    abstract class Level
    {
        ContentManager content;
        AbstractLevelFactory levelFactory;
        public Level(ContentManager _content)
        {
            CreateLevelArray();
            TilesList = new List<IDrawObject>();
            content = _content;
            levelFactory = new LevelFactory();
        }
        protected abstract void CreateLevelArray();
        public byte[,] LevelArray;
        public List<IDrawObject> TilesList;
        /// <summary>
        /// Maakt het level aan
        /// </summary>
        /// <param name="CollisionList"></param>
        public void CreateLevel(List<ICollide> CollisionList)
        {
            for (int x = 0; x < LevelArray.GetLength(0); x++)
            {
                for (int y = 0; y < LevelArray.GetLength(1); y++)
                {
                    if (LevelArray[x, y] != 0)
                    {
                        TilesList.Add(levelFactory.GetExactObject((int)LevelArray[x, y], content, new Vector2(y * 70, x * 70), CollisionList));
                    }
                }
            }
        }
        /// <summary>
        /// Tekent het level op het scherm
        /// </summary>
        /// <param name="spritebatch"></param>
        public void DrawLevel(SpriteBatch spritebatch)
        {
            foreach (IDrawObject tempTile in TilesList)
            {
                tempTile.Draw(spritebatch);
            }
        }
        /// <summary>
        /// Verwijderd de meegegeven lijst uit het level
        /// </summary>
        /// <param name="_tiles"></param>
        public void RemoveTile(List<IDrawObject> _tiles)
        {
            foreach (IDrawObject _tile in _tiles)
            {
                TilesList.Remove(_tile);
            }
        }
    }
}
