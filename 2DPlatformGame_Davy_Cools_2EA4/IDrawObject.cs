using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    public interface IDrawObject
    {
        Vector2 Position { get; set; }
        void Draw(SpriteBatch spriteBatch);
    }
}
