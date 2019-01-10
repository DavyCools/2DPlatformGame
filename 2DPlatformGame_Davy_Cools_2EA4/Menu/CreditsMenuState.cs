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
    /// Deze klasse (CreditsMenuState) is verantwoordelijk voor
    /// het tonen van de credits
    /// Erft over van: IMenuState
    /// </summary>
    class CreditsMenuState : IMenuState
    {
        public int MiddleScreenWidth;
        public int MiddleScreenHeight;
        int height = 700;
        Texture2D creditsTexture, creditsBackgroundTexture;
        MenuManager menuManager;
        Button backButton;
        public CreditsMenuState(ContentManager content, MenuManager _menuManager)
        {
            menuManager = _menuManager;
            MiddleScreenWidth = menuManager.MiddleScreenWidth;
            MiddleScreenHeight = menuManager.MiddleScreenHeight;
            creditsTexture = content.Load<Texture2D>("Credits");
            creditsBackgroundTexture = content.Load<Texture2D>("CreditsBackground");
            backButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 200)) { Scale = 0.4f };
            backButton.ButtonTexture = content.Load<Texture2D>("BackButton");
        }
        /// <summary>
        /// Tekent de credits
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(creditsBackgroundTexture, new Vector2(MiddleScreenWidth - 520, 130), null, Color.AliceBlue, 0f, Vector2.Zero, 0.55f, SpriteEffects.None, 0f);
            spriteBatch.Draw(creditsTexture, new Vector2(MiddleScreenWidth - 520, height), null, Color.AliceBlue, 0f, Vector2.Zero, 0.55f, SpriteEffects.None, 0f);
            backButton.Draw(spriteBatch);
        }
        /// <summary>
        /// Update de credits
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (height > 130)
                height -= 1;
            if (backButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.SetState(menuManager.GetMainMenuState());
                Thread.Sleep(100);
            }
        }
    }
}
