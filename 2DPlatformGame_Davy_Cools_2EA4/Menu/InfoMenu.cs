using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class InfoMenu : IMenu
    {
        Texture2D infoTexture;
        public InfoMenu(ContentManager content)
        {
            infoTexture = content.Load<Texture2D>("InfoEnemies");
        }
        public void Update(GameTime gameTime)
        {
            
        }
        public void Draw(SpriteBatch spriteBatch, int MiddleScreenWidth)
        {
            spriteBatch.Draw(infoTexture, new Vector2(MiddleScreenWidth - 535, 150), null, Color.AliceBlue, 0f, Vector2.Zero, 0.55f, SpriteEffects.None, 0f);
        }
    }
}
