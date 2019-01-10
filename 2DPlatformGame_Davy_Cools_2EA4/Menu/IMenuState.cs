using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze interface (IMenuState) is verantwoordelijk voor
    /// de methoden te definieren van een menu
    /// Erft over van: IMenuState
    /// </summary>
    interface IMenuState
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
