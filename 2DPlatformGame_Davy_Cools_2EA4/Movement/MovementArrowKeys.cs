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
        public override Vector2 Update(Vector2 velocity)
        {
            KeyboardState stateKey = Keyboard.GetState();
            
            if (stateKey.IsKeyDown(Keys.Left) && Right == false)
            {
                Left = true;
                velocity.X = -movementSpeed;
            }
            if (stateKey.IsKeyUp(Keys.Left) && Right == false)
            {
                Left = false;
                velocity.X = 0;
            }
            if (stateKey.IsKeyDown(Keys.Right) && Left == false)
            {
                Right = true;
                velocity.X = movementSpeed;
            }
            if (stateKey.IsKeyUp(Keys.Right) && Left == false)
            {
                Right = false;
                velocity.X = 0;
            }
            if (stateKey.IsKeyDown(Keys.Up) && velocity.Y == 0)
            {
                Jump = true;
                velocity.Y = -5;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                Jump = false;
            }
            if (stateKey.IsKeyDown(Keys.Down))
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
            if(velocity.Y != 0)
            {
                velocity.Y += 0.2f;
            }
            return velocity;
        }
    }
}
