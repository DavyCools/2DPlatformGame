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
    /// Deze klasse (ControlsMenuSTate) is verantwoordelijk voor
    /// het tonen van de controls
    /// Erft over van: IMenuState
    /// </summary>
    class ControlsMenuState : IMenuState
    {
        public int MiddleScreenWidth;
        public int MiddleScreenHeight;
        Texture2D movementControls, pauseControl, endControl;
        MenuManager menuManager;
        Button backButton;
        public ControlsMenuState(ContentManager content, MenuManager _menuManager)
        {
            menuManager = _menuManager;
            MiddleScreenWidth = menuManager.MiddleScreenWidth;
            MiddleScreenHeight = menuManager.MiddleScreenHeight;
            movementControls = content.Load<Texture2D>("MovementKeys");
            pauseControl = content.Load<Texture2D>("PauseKey");
            endControl = content.Load<Texture2D>("EndLevelKey");
            backButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 200)) { Scale = 0.4f };
            backButton.ButtonTexture = content.Load<Texture2D>("BackButton");
        }
        /// <summary>
        /// Update het menu in functie van bepaalde user inputs
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
        /// Tekent de controls
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(movementControls, new Vector2(MiddleScreenWidth - 425, 150), null, Color.AliceBlue, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0f);
            spriteBatch.Draw(pauseControl, new Vector2(MiddleScreenWidth - 425, 400), null, Color.AliceBlue, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0f);
            spriteBatch.Draw(endControl, new Vector2(MiddleScreenWidth - 425, 475), null, Color.AliceBlue, 0f, Vector2.Zero, 0.43f, SpriteEffects.None, 0f);
            backButton.Draw(spriteBatch);
        }
    }
}
