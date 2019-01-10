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
    /// Deze klasse (InBetweenLevelMenuState) is verantwoordelijk voor
    /// het tonen van het menu tussen de levels door
    /// Erft over van: IMenuState
    /// </summary>
    class InbetweenLevelMenuState : IMenuState
    {
        public int MiddleScreenWidth;
        public int MiddleScreenHeight;
        MenuManager menuManager;
        Button quitButton, continueButton;
        public InbetweenLevelMenuState(ContentManager content, MenuManager _menuManager)
        {
            menuManager = _menuManager;
            MiddleScreenWidth = menuManager.MiddleScreenWidth;
            MiddleScreenHeight = menuManager.MiddleScreenHeight;
            continueButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 100)) { Scale = 0.4f };
            quitButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 200)) { Scale = 0.4f };
            continueButton.ButtonTexture = content.Load<Texture2D>("ContinueButton");
            quitButton.ButtonTexture = content.Load<Texture2D>("QuitButton");
        }
        /// <summary>
        /// Tekent het menu tussen de levels door
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            menuManager.runningGame.fullGame.DrawEndLevelStars(spriteBatch);
            continueButton.Draw(spriteBatch);
            quitButton.Draw(spriteBatch);
        }
        /// <summary>
        /// Update het menu tussen de levels door in functie van bepaalde user inputs
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (quitButton.CheckClicked(menuManager.mouseState))
            {
                //fullGame.ResetCurrentLevel();
                menuManager.runningGame.fullGame.Initialize(menuManager.runningGame.Content, menuManager.runningGame.ScreenHeight, menuManager.runningGame.ScreenWidth);
                menuManager.runningGame.fullGame.LoadContent(menuManager.runningGame.Content);
                menuManager.SetState(menuManager.GetMainMenuState());
                Thread.Sleep(100);
            }
            if (continueButton.CheckClicked(menuManager.mouseState))
            {
                menuManager.SetState(menuManager.GetPlayMenuState());
            }
        }
    }
}
