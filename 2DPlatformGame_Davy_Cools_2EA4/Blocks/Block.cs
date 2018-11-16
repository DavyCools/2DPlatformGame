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
    public class Block
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Block(ContentManager content, Vector2 _position, string name)
        {
            texture = content.Load<Texture2D>(name);
            Position = _position;
        }
        
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, Position, Color.AliceBlue);
        }
    }
}
