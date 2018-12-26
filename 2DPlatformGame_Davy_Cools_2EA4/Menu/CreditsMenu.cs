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
    class CreditsMenu : IMenu
    {
        int height = 700;
        Texture2D creditsTexture,creditsBackgroundTexture;
        public CreditsMenu(ContentManager content)
        {
            creditsTexture = content.Load<Texture2D>("Credits");
            creditsBackgroundTexture = content.Load<Texture2D>("CreditsBackground");
        }
        public void Draw(SpriteBatch spriteBatch, int MiddleScreenWidth)
        {
            spriteBatch.Draw(creditsTexture, new Vector2(MiddleScreenWidth - 520, height), null, Color.AliceBlue, 0f, Vector2.Zero, 0.55f, SpriteEffects.None, 0f);
            spriteBatch.Draw(creditsBackgroundTexture, new Vector2(MiddleScreenWidth - 520, 130), null, Color.AliceBlue, 0f, Vector2.Zero, 0.55f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            if(height > 130)
                height -= 1;
        }
    }
}
