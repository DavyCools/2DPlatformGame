using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (InfoMenuState) is verantwoordelijk voor
    /// het tonen van de info
    /// Erft over van: IMenuState
    /// </summary>
    class InfoMenuState : IMenuState
    {
        public int MiddleScreenWidth;
        public int MiddleScreenHeight;
        Texture2D infoTextureControls, infoTextureAttack, infoEndLevel;
        MenuManager menuManager;
        Button backButton;
        public InfoMenuState(ContentManager content, MenuManager _menuManager)
        {
            menuManager = _menuManager;
            MiddleScreenWidth = menuManager.MiddleScreenWidth;
            MiddleScreenHeight = menuManager.MiddleScreenHeight;
            infoTextureControls = content.Load<Texture2D>("InfoEnemies");
            infoTextureAttack = content.Load<Texture2D>("ChargedAttackInfo");
            infoEndLevel = content.Load<Texture2D>("EndLevelInfo");
            backButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 200)) { Scale = 0.4f };
            backButton.ButtonTexture = content.Load<Texture2D>("BackButton");
        }
        /// <summary>
        /// Update het infomenu in functie van bepaalde user inputs
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (backButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.SetState(menuManager.GetMainMenuState());
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// Tekent de info
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(infoTextureControls, new Vector2(MiddleScreenWidth - 535, 150), null, Color.AliceBlue, 0f, Vector2.Zero, 0.55f, SpriteEffects.None, 0f);
            spriteBatch.Draw(infoTextureAttack, new Vector2(MiddleScreenWidth - 560, 450), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            spriteBatch.Draw(infoEndLevel, new Vector2(MiddleScreenWidth - 535, 380), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            backButton.Draw(spriteBatch);
        }
    }
}
