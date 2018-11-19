﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    public abstract class Block : ICollide
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, 70, 70); }
        }

        public Block(ContentManager content, Vector2 _position, string name)
        {
            texture = content.Load<Texture2D>(name);
            Position = _position;
        }
        public void Initialise(float x, float y)
        {
            
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.AliceBlue);
            //spriteBatch.Draw(texture, CollisionRectangle.Location.ToVector2(), new Rectangle(0, 0, 70, 70), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            //spriteBatch.Draw(texture, Position, new Rectangle(0,0,70,70), Color.AliceBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
