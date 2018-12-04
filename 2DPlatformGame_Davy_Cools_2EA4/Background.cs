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
    /// Deze klasse is verantwoordelijk voor
    /// het aanmaken van de achergrond
    /// </summary>
    class Background
    {
        private Texture2D backgroundTexture;
        private Rectangle[] backgroundArray;
        private int positionX;
        private int positionY;
        private int screenWidth;
        private int screenHeight;
        private int backgroundWidth = 2560;
        public Background(ContentManager content)
        {
            positionX = -(Game1.ScreenWidth / 2);
            positionY = -Game1.ScreenHeight + 100;
            screenWidth = Game1.ScreenWidth * 2;
            screenHeight = Game1.ScreenHeight * 2;
            backgroundTexture = content.Load <Texture2D>("BackgroundLevel1");
            backgroundArray = new Rectangle[] { new Rectangle(positionX,positionY,screenWidth, screenHeight),
                              new Rectangle(positionX + backgroundWidth,positionY,screenWidth,screenHeight),
                              new Rectangle(positionX + backgroundWidth*2,positionY,screenWidth,screenHeight),
                              new Rectangle(positionX + backgroundWidth*3,positionY,screenWidth,screenHeight)
            };
        }
        public void Update(float position)
        {
            /*if (position > positionX + backgroundWidth)
            {
                positionX += backgroundWidth;
                backgroundArray[index].X += backgroundWidth;
                index++;
            }
            else if (position < positionX - backgroundWidth)
            {
                positionX -= backgroundWidth/2;
                backgroundArray[0].X -= backgroundWidth;
                index--;
            }*/
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, backgroundArray[0],Color.White);
            spriteBatch.Draw(backgroundTexture, backgroundArray[1], Color.White);
            spriteBatch.Draw(backgroundTexture, backgroundArray[2], Color.White);
            spriteBatch.Draw(backgroundTexture, backgroundArray[3], Color.White);
        }
    }
}
