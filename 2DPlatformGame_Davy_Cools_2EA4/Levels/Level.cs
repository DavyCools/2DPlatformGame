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
    abstract class Level
    {
        ContentManager content;
        AbstractLevelFactory levelFactory;
        public Level(ContentManager _content)
        {
            CreateLevelArray();
            //TilesArray = new Tiles[LevelArray.GetLength(0), LevelArray.GetLength(1)];
            TilesList = new List<Tiles>();
            content = _content;
            levelFactory = new LevelFactory();
        }
        protected abstract void CreateLevelArray();
        public byte[,] LevelArray;
        //public Tiles[,] TilesArray;
        public List<Tiles> TilesList;
        public void CreateLevel(List<ICollide> CollisionList)
        {
            for (int x = 0; x < LevelArray.GetLength(0); x++) //Er stond TilesArray in plaats van LevelArray
            {
                for (int y = 0; y < LevelArray.GetLength(1); y++)  //Er stond TilesArray in plaats van LevelArray
                {
                    if (LevelArray[x, y] != 0)
                    {
                        //TilesArray[x, y] = levelFactory.GetExactBlock((int)LevelArray[x, y],content, new Vector2(y * 70, x * 70),CollisionList);
                        TilesList.Add(levelFactory.GetExactBlock((int)LevelArray[x, y], content, new Vector2(y * 70, x * 70), CollisionList));
                    }
                }
            }
        }
        public void DrawLevel(SpriteBatch spritebatch)
        {
            foreach (Tiles tempTile in TilesList)
            {
                tempTile.Draw(spritebatch);
            }
            /*for (int x = 0; x < TilesArray.GetLength(0); x++)
            {
                for (int y = 0; y < TilesArray.GetLength(1); y++)
                {
                    if (TilesArray[x, y] != null && !(TilesArray[x, y] is IUpdate))
                    {
                        TilesArray[x, y].Draw(spritebatch);
                    }
                }
            }*/
        }
        public void RemoveTile(List<Tiles> _tiles)
        {
            foreach (Tiles _tile in _tiles)
            {
                TilesList.Remove(_tile);
            }
        }
    }
}
