using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (MenuManager) is verantwoordelijk voor
    /// het tonen van het juiste menu
    /// </summary>
    class MenuManager
    {
        public int MiddleScreenWidth;
        public int MiddleScreenHeight;
        public Game1 runningGame;
        IMenuState controlsMenuState;
        IMenuState creditsMenuState;
        IMenuState infoMenuState;
        IMenuState mainMenuState;
        IMenuState currentMenuState;
        IMenuState playMenuState;
        IMenuState pauseMenuState;
        IMenuState inbetweenLevelMenuState;
        MenuBackground menuBackground;
        public MouseState mouseState;
        Texture2D titelTexture;
        public MenuManager(ContentManager content, Game1 game)
        {
            runningGame = game;
            MiddleScreenWidth = runningGame.MiddleScreenWidth;
            MiddleScreenHeight = runningGame.MiddleScreenHeight;
            controlsMenuState = new ControlsMenuState(content, this);
            creditsMenuState = new CreditsMenuState(content, this);
            infoMenuState = new InfoMenuState(content, this);
            mainMenuState = new MainMenuState(content, this);
            playMenuState = new PlayMenuState(content, this);
            pauseMenuState = new PauseMenuState(content, this);
            inbetweenLevelMenuState = new InbetweenLevelMenuState(content, this);
            menuBackground = new MenuBackground(content);
            titelTexture = content.Load<Texture2D>("2DGameName");
            currentMenuState = mainMenuState;
        }
        /// <summary>
        /// Updaten van het huidige menu
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (currentMenuState != playMenuState)
            {
                menuBackground.Update(gameTime);
                runningGame.IsMouseVisible = true;
            }
            else
                runningGame.IsMouseVisible = false;

            currentMenuState.Update(gameTime);
        }
        /// <summary>
        /// Tekenen van het huidige menu
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentMenuState != playMenuState)
            {
                spriteBatch.Begin();
                menuBackground.Draw(spriteBatch, MiddleScreenWidth);
                if (currentMenuState != inbetweenLevelMenuState)
                {
                    spriteBatch.Draw(titelTexture, new Vector2(MiddleScreenWidth - 500, 25), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
                }
            }
            currentMenuState.Draw(spriteBatch);
        }
        /// <summary>
        /// Het huidige menu veranderen met de meegegeven
        /// </summary>
        /// <param name="tempState"></param>
        public void SetState(IMenuState tempState)
        {
            currentMenuState = tempState;
        }
        /// <summary>
        /// Teruggeven van de controlsMenuState
        /// </summary>
        /// <returns></returns>
        public IMenuState GetControlsMenuState()
        {
            return controlsMenuState;
        }
        /// <summary>
        /// Teruggeven van de creditsMenuState
        /// </summary>
        /// <returns></returns>
        public IMenuState GetCreditsMenuState()
        {
            return creditsMenuState;
        }
        /// <summary>
        /// Teruggeven van de infoMenuState
        /// </summary>
        /// <returns></returns>
        public IMenuState GetInfoMenuState()
        {
            return infoMenuState;
        }
        /// <summary>
        /// Teruggeven van de mainMenuState
        /// </summary>
        /// <returns></returns>
        public IMenuState GetMainMenuState()
        {
            return mainMenuState;
        }
        /// <summary>
        /// Teruggeven van de playMenuState
        /// </summary>
        /// <returns></returns>
        public IMenuState GetPlayMenuState()
        {
            return playMenuState;
        }
        /// <summary>
        /// Teruggeven van de pauseMenuState
        /// </summary>
        /// <returns></returns>
        public IMenuState GetPauseMenuState()
        {
            return pauseMenuState;
        }
        /// <summary>
        /// Teruggeven van de inbetweenLevelMenuState
        /// </summary>
        /// <returns></returns>
        public IMenuState GetInbetweenLevelMenuState()
        {
            return inbetweenLevelMenuState;
        }
    }
}
