using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class Plant : Enemy
    {
        public Plant(ContentManager content, Vector2 position, string name) : base(content, position, name)
        {
            animation = new PlantAnimation();
            animation.scale = 1.3f;    
        }
        public override void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            if (Velocity.Y != 0)
                ChangeVelocity(0, Velocity.Y + 0.2f);
            Position += Velocity;
            if (!TouchingGround && Velocity.Y == 0)
                ChangeVelocity(0,0.2f);
            TouchingRight = false;
            TouchingLeft = false;
            TouchingGround = false;
            TouchingTop = false;
        }
    }
}
