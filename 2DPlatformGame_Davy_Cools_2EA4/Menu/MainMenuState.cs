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
    /// Deze klasse (MainMenuState) is verantwoordelijk voor
    /// het tonen van het hoofdmenu
    /// Erft over van: IMenuState
    /// </summary>
    class MainMenuState : IMenuState
    {
        public int MiddleScreenWidth;
        public int MiddleScreenHeight;
        Texture2D checkboxOffTexture,checkboxOnTexture;
        Button playButton, infoButton, controlsButton, creditsButton, exitButton, checkboxCheatsButton, checkboxFullscreenButton;
        MenuManager menuManager;
        SpriteFont scoreFont;
        bool checkboxCheat = false;
        public MainMenuState(ContentManager content, MenuManager _menuManager)
        {
            menuManager = _menuManager;
            MiddleScreenWidth = menuManager.MiddleScreenWidth;
            MiddleScreenHeight = menuManager.MiddleScreenHeight;
            playButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 - 200)) { Scale = 0.4f };
            infoButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 - 100)) { Scale = 0.4f };
            controlsButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178)) { Scale = 0.4f };
            creditsButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 100)) { Scale = 0.4f };
            exitButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 200)) { Scale = 0.4f };
            checkboxCheatsButton = new Button(new Vector2(MiddleScreenWidth - 15, MiddleScreenHeight + 95)) { Scale = 0.1f };
            checkboxFullscreenButton = new Button(new Vector2(MiddleScreenWidth + 220, MiddleScreenHeight + 95)) { Scale = 0.1f };
            scoreFont = content.Load<SpriteFont>("ScoreFont");
            playButton.ButtonTexture = content.Load<Texture2D>("PlayButton");
            infoButton.ButtonTexture = content.Load<Texture2D>("InfoButton");
            controlsButton.ButtonTexture = content.Load<Texture2D>("controlsButton");
            creditsButton.ButtonTexture = content.Load<Texture2D>("CreditsButton");
            exitButton.ButtonTexture = content.Load<Texture2D>("ExitButton");
            checkboxOffTexture = content.Load<Texture2D>("CheckboxOff");
            checkboxOnTexture = content.Load<Texture2D>("CheckboxOn");
            checkboxCheatsButton.ButtonTexture = checkboxOffTexture;
            checkboxFullscreenButton.ButtonTexture = checkboxOffTexture;

        }
        /// <summary>
        /// Tekent het hoofdmenu
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(scoreFont, "Fullscreen", (new Vector2(MiddleScreenWidth + 190, MiddleScreenHeight + 145)), Color.Black);
            if (checkboxCheatsButton.ButtonTexture == checkboxOnTexture)
                spriteBatch.DrawString(scoreFont, "Cheats on ", (new Vector2(MiddleScreenWidth - 35, MiddleScreenHeight + 145)), Color.Black);
            else
                spriteBatch.DrawString(scoreFont, "Cheats off", (new Vector2(MiddleScreenWidth - 35, MiddleScreenHeight + 145)), Color.Black);
            playButton.Draw(spriteBatch);
            infoButton.Draw(spriteBatch);
            controlsButton.Draw(spriteBatch);
            creditsButton.Draw(spriteBatch);
            exitButton.Draw(spriteBatch);
            checkboxCheatsButton.Draw(spriteBatch);
            checkboxFullscreenButton.Draw(spriteBatch);
        }
        /// <summary>
        /// Update het hoofdmenu in functie van bepaalde user inputs
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (playButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.SetState(menuManager.GetPlayMenuState());
                menuManager.runningGame.fullGame.SetCheats(checkboxCheat);
            }
            if (infoButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.SetState(menuManager.GetInfoMenuState());
            }
            if (controlsButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.SetState(menuManager.GetControlsMenuState());
            }
            if (creditsButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.SetState(menuManager.GetCreditsMenuState());
            }
            if (exitButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.runningGame.Exit();
            }
            if (checkboxFullscreenButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.runningGame.graphics.ToggleFullScreen();
                if (checkboxFullscreenButton.ButtonTexture == checkboxOffTexture)
                    checkboxFullscreenButton.ButtonTexture = checkboxOnTexture;
                else
                    checkboxFullscreenButton.ButtonTexture = checkboxOffTexture;
                Thread.Sleep(100);
            }
            if (checkboxCheatsButton.CheckClicked(menuManager.mouseState))
            {
                checkboxCheat = !checkboxCheat;
                if (checkboxCheatsButton.ButtonTexture == checkboxOffTexture)
                    checkboxCheatsButton.ButtonTexture = checkboxOnTexture;
                else
                    checkboxCheatsButton.ButtonTexture = checkboxOffTexture;
                Thread.Sleep(100);
            }
        }
    }
}
