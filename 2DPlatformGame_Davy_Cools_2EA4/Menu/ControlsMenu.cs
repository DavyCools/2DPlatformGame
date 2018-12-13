using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class ControlsMenu : IMenu
    {
        Texture2D movementControls;
        Texture2D pauseControl;
        public ControlsMenu(ContentManager content)
        {
            movementControls = content.Load<Texture2D>("MovementKeys");
            pauseControl = content.Load<Texture2D>("PauseKey");
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, int MiddleScreenWidth)
        {
            spriteBatch.Draw(movementControls, new Vector2(MiddleScreenWidth - 425, 150), null, Color.AliceBlue, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0f);
            spriteBatch.Draw(pauseControl, new Vector2(MiddleScreenWidth - 425, 450), null, Color.AliceBlue, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0f);
        }
    }
}
