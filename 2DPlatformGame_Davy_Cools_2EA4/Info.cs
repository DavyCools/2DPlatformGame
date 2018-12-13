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
    class Info
    {
        SpriteFont infoFont;
        Vector2 startposition;
        public Info(ContentManager content)
        {
            infoFont = content.Load<SpriteFont>("InfoFont");
            startposition = new Vector2(960, 540);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(infoFont,"Test",new Vector2(startposition.X - 300,startposition.Y - 150), Color.White);
        }
    }
}
