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
    abstract class AbstractLevelFactory
    {
        public IDrawObject GetExactBlock(int id, ContentManager content, Vector2 _position, List<ICollide> CollisionList)
        {
            IDrawObject tempObject = CreateBlok(id, content, _position);           
            if(tempObject is ICollide)
            {
                CollisionList.Add((ICollide)tempObject);
            }
            return tempObject;
        }
        protected abstract IDrawObject CreateBlok(int id,ContentManager content, Vector2 _position);
    }
}