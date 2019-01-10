using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (PlayMenuState) is verantwoordelijk voor
    /// het tonen van het spel
    /// Erft over van: IMenuState
    /// </summary>
    class PlayMenuState : IMenuState
    {
        MenuManager menuManager;
        public PlayMenuState(ContentManager content, MenuManager _menuManager)
        {
            menuManager = _menuManager;
        }
        /// <summary>
        /// Tekenen van de game
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            menuManager.runningGame.fullGame.Draw(spriteBatch);
        }
        /// <summary>
        /// Updaten van de game
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                menuManager.SetState(menuManager.GetPauseMenuState());
            if (Keyboard.GetState().IsKeyDown(Keys.E))
                if (menuManager.runningGame.fullGame.CheckEndOfLevel())
                    menuManager.SetState(menuManager.GetInbetweenLevelMenuState());
            menuManager.runningGame.fullGame.Update(gameTime);
        }
    }
}
