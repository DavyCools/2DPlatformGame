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
        public StaticBlock GetExactBlock(int id, ContentManager content, Vector2 _position, List<ICollide> CollisionList)
        {
            StaticBlock block = CreateBlok(id,content,_position);
            CollisionList.Add(block);
            return block;
        }
        protected abstract StaticBlock CreateBlok(int id,ContentManager content, Vector2 _position);
    }
}