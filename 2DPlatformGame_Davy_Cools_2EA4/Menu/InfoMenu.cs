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
        Texture2D infoTextureControls, infoTextureAttack, infoEndLevel;
        public InfoMenu(ContentManager content)
        {
            infoTextureControls = content.Load<Texture2D>("InfoEnemies");
            infoTextureAttack = content.Load<Texture2D>("ChargedAttackInfo");
            infoEndLevel = content.Load<Texture2D>("EndLevelInfo");
        }
        public void Update(GameTime gameTime)
        {
            
        }
        public void Draw(SpriteBatch spriteBatch, int MiddleScreenWidth)
        {
            spriteBatch.Draw(infoTextureControls, new Vector2(MiddleScreenWidth - 535, 150), null, Color.AliceBlue, 0f, Vector2.Zero, 0.55f, SpriteEffects.None, 0f);
            spriteBatch.Draw(infoTextureAttack, new Vector2(MiddleScreenWidth - 560, 450), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            spriteBatch.Draw(infoEndLevel, new Vector2(MiddleScreenWidth - 535, 380), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
        }
    }
}
