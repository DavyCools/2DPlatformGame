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
        public Block GetExactBlock(int id, ContentManager content, Texture2D _texture, Vector2 _position, List<ICollide> CollisionList)
        {
            Block block = CreateBlok(id,content,_texture,_position);
            CollisionList.Add(block);
            return block;
        }
        protected abstract Block CreateBlok(int id,ContentManager content, Texture2D _texture, Vector2 _position);
    }
}