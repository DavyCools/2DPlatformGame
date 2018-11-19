using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class MovementArrowKeys : Movement
    {
        public override void Update(Hero hero)
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Left) && Right == false)
            {
                Left = true;
                if (!hero.TouchingLeft)
                    hero.Velocity.X = -movementSpeed;
            }
            if (stateKey.IsKeyUp(Keys.Left) && Right == false)
            {
                Left = false;
                hero.Velocity.X = 0;
            }
            if (stateKey.IsKeyDown(Keys.Right) && Left == false)
            {
                Right = true;
                    hero.Velocity.X = movementSpeed;
            }
            if (stateKey.IsKeyUp(Keys.Right) && Left == false)
            {
                Right = false;
                hero.Velocity.X = 0;
            }
            if (stateKey.IsKeyDown(Keys.Up) && hero.Velocity.Y == 0)
            {
                Jump = true;
                if(!hero.TouchingTop)
                hero.Velocity.Y = -8;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                Jump = false;
            }
            if (stateKey.IsKeyDown(Keys.Space))
            {
                Shoot = true;
            }
            if (stateKey.IsKeyUp(Keys.Space))
            {
                Shoot = false;
            }
            if (hero.Velocity.Y != 0)
            {
                hero.Velocity.Y += 0.2f;
            }
            hero.position += hero.Velocity;
            if (!hero.TouchingGround && hero.Velocity.Y == 0)
            {
                hero.Velocity.Y = 0.2f;
            }
        }
    }
}
