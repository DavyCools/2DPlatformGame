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
    /// <summary>
    /// Deze klasse (MenuBackground) is verantwoordelijk voor
    /// het tonen van de achtergrond van een menu
    /// Erft over van: IMenuState
    /// </summary>
    class MenuBackground
    {
        Texture2D background;
        Texture2D heroMenutexture;
        Animation heroIdleMenuAnimation;
        Texture2D gremlinTexture;
        Animation gremlinAnimation;
        Texture2D plantTexture;
        Animation plantAnimation;
        Texture2D tKeyTexture;
        public MenuBackground(ContentManager content)
        {
            background = content.Load<Texture2D>("MenuImage");
            heroMenutexture = content.Load<Texture2D>("IceWizard");
            heroIdleMenuAnimation = new HeroIdleAnimation();
            gremlinTexture = content.Load<Texture2D>("GremlinSheet");
            gremlinAnimation = new GremlinFrontAnimation();
            plantTexture = content.Load<Texture2D>("PlantSheet");
            plantAnimation = new PlantAnimation();
            tKeyTexture = content.Load<Texture2D>("TKey");
        }
        /// <summary>
        /// Update de achtergrond van een menu
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            heroIdleMenuAnimation.Update(gameTime);
            gremlinAnimation.Update(gameTime);
            plantAnimation.Update(gameTime);
        }
        /// <summary>
        /// Tekent de achtergrond van een menu
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="MiddleScreenWidth"></param>
        public void Draw(SpriteBatch spriteBatch, int MiddleScreenWidth)
        {
            spriteBatch.Draw(background, new Vector2(0, 0), null, Color.AliceBlue, 0f, Vector2.Zero, 0.667f, SpriteEffects.None, 0f);
            spriteBatch.Draw(heroMenutexture, new Vector2(285, 539), heroIdleMenuAnimation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
            spriteBatch.Draw(gremlinTexture, new Vector2(940, 572), gremlinAnimation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(gremlinTexture, new Vector2(1182, 572), gremlinAnimation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(plantTexture, new Vector2(1054, 604), plantAnimation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 1.25f, SpriteEffects.None, 0f);
            spriteBatch.Draw(tKeyTexture, new Vector2(1075, 677), null, Color.AliceBlue, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);

        }
    }
}
