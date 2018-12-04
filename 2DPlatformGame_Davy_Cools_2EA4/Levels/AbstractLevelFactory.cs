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
    /// Deze abstract klasse (AbsctractLevelFactory) is verantwoordelijk voor 
    /// het teruggeven van de juiste objecten
    /// </summary>
    abstract class AbstractLevelFactory
    {
        public IDrawObject GetExactObject(int id, ContentManager content, Vector2 _position, List<ICollide> CollisionList)
        {
            IDrawObject currentObject = CreateObject(id, content, _position);           
            if(currentObject is ICollide)
            {
                CollisionList.Add((ICollide)currentObject);
            }
            return currentObject;
        }
        protected abstract IDrawObject CreateObject(int id,ContentManager content, Vector2 _position);
    }
}