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
    public abstract class AbstractLevelFactory
    {
        public Tiles GetExactBlock(int id, ContentManager content, Vector2 _position, List<ICollide> CollisionList)
        {
            Tiles block = CreateBlok(id,content,_position);
            if(block is ICollide)
            {
                CollisionList.Add((ICollide)block);
            }
            return block;
        }
        protected abstract Tiles CreateBlok(int id,ContentManager content, Vector2 _position);
    }
}