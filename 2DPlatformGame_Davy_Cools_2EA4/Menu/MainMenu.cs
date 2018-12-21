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
    class MainMenu : IMenu
    {
        Texture2D background;
        Texture2D titelTexture;
        Texture2D heroMenutexture;
        Animation heroIdleMenuAnimation;
        Texture2D gremlinTexture;
        Animation gremlinAnimation;
        Texture2D plantTexture;
        Animation plantAnimation;
        public MainMenu(ContentManager content)
        {
            background = content.Load<Texture2D>("MenuImage");
            titelTexture = content.Load<Texture2D>("2DGameName");
            heroMenutexture = content.Load<Texture2D>("IceWizard");
            heroIdleMenuAnimation = new HeroIdleAnimation();
            gremlinTexture = content.Load<Texture2D>("GremlinSheet");
            gremlinAnimation = new GremlinFrontAnimation();
            plantTexture = content.Load<Texture2D>("PlantSheet");
            plantAnimation = new PlantAnimation();
        }
        public void Update(GameTime gameTime)
        {
            heroIdleMenuAnimation.Update(gameTime);
            gremlinAnimation.Update(gameTime);
            plantAnimation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, int MiddleScreenWidth)
        {        
            spriteBatch.Draw(background, new Vector2(0, 0), null, Color.AliceBlue, 0f, Vector2.Zero, 0.667f, SpriteEffects.None, 0f);
            //spriteBatch.Draw(titelTexture, new Vector2(MiddleScreenWidth - 500, 25), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            spriteBatch.Draw(heroMenutexture, new Vector2(285, 539), heroIdleMenuAnimation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
            spriteBatch.Draw(gremlinTexture, new Vector2(940, 572), gremlinAnimation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(gremlinTexture, new Vector2(1182, 572), gremlinAnimation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(plantTexture, new Vector2(1054, 604), plantAnimation.CurrentFrame.FrameSelector, Color.AliceBlue, 0f, Vector2.Zero, 1.25f, SpriteEffects.None, 0f);

        }
    }
}
