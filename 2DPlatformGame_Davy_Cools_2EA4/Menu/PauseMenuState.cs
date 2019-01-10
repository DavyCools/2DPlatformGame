using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Threading;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (PauseMenuState) is verantwoordelijk voor
    /// het tonen van het pauzemenu
    /// Erft over van: IMenuState
    /// </summary>
    class PauseMenuState : IMenuState
    {
        public int MiddleScreenWidth;
        public int MiddleScreenHeight;
        Button resumeButton, restartButton, quitButton;
        MenuManager menuManager;
        public PauseMenuState(ContentManager content, MenuManager _menuManager)
        {
            menuManager = _menuManager;
            MiddleScreenWidth = menuManager.MiddleScreenWidth;
            MiddleScreenHeight = menuManager.MiddleScreenHeight;
            resumeButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 - 200)) { Scale = 0.4f };
            restartButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 - 100)) { Scale = 0.4f };
            quitButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 200)) { Scale = 0.4f };
            resumeButton.ButtonTexture = content.Load<Texture2D>("ResumeButton");
            restartButton.ButtonTexture = content.Load<Texture2D>("RestartButton");
            quitButton.ButtonTexture = content.Load<Texture2D>("QuitButton");
            
        }
        /// <summary>
        /// Tekent het pauzemenu
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            resumeButton.Draw(spriteBatch);
            restartButton.Draw(spriteBatch);
            quitButton.Draw(spriteBatch);
        }
        /// <summary>
        /// Update door middel van de user inputs
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (resumeButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.SetState(menuManager.GetPlayMenuState());
            }
            if (quitButton.CheckClicked(menuManager.mouseState))
            {
                //fullGame.ResetCurrentLevel();
                menuManager.runningGame.fullGame.Initialize(menuManager.runningGame.Content, menuManager.runningGame.ScreenHeight, menuManager.runningGame.ScreenWidth);
                menuManager.runningGame.fullGame.LoadContent(menuManager.runningGame.Content);
                menuManager.SetState(menuManager.GetMainMenuState());
                Thread.Sleep(100);
            }
            if (restartButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.SetState(menuManager.GetPlayMenuState());
                menuManager.runningGame.fullGame.ResetCurrentLevel();
            }
        }
    }
}
