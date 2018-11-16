using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Verantwoordelijk voor het aanmaken van de juist blok
    /// </summary>
    public class LevelFactory : AbstractLevelFactory
    {
        protected override Block CreateBlok(int id,ContentManager content, Texture2D _texture, Vector2 _position)
        {
            Block b = null;
            if (id == 1)
                b = new TestBlock(content, _position, "blok");
            else if (id == 2)
                b = new TestBlock(content, _position, "blok");
            return b;
        }
    }
}
