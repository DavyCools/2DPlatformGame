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
    class Background
    {
        Texture2D BackgroundTexture;

        public Background(ContentManager content)
        {
            BackgroundTexture = content.Load <Texture2D>("BackgroundLevel1");
        }
        public Rectangle StartPosition;
        public Rectangle SecondPosition;
        public void Initialize(Rectangle _BeginPosition, Rectangle _DrawPosition)
        {
            StartPosition = _BeginPosition;
            SecondPosition = _DrawPosition;
        }
        public void Update(GraphicsDeviceManager graphics)
        {
            //BeginPosition.X -= 1;
            //DrawPosition.X -= 1;
            //if (BeginPosition.X < -(graphics.PreferredBackBufferWidth - graphics.PreferredBackBufferWidth)){
            //BeginPosition.X = -graphics.PreferredBackBufferWidth/2;
            //DrawPosition.X = graphics.PreferredBackBufferWidth * 2 - graphics.PreferredBackBufferWidth / 2;
            //}
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundTexture, StartPosition,Color.White);
            spriteBatch.Draw(BackgroundTexture, SecondPosition, Color.White);
        }
    }
}
