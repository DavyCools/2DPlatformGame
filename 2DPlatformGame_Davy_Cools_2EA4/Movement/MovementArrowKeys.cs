using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// De klasse MovementArrowsKeys is verantwoordelijk voor de bewgiging van de hero als er op 1 van de knoppen die de hero bestuurd geklikt wordt
    /// </summary>
    class MovementArrowKeys : Movement
    {
        public override void Update(IMoveableObject hero)
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.Left) && Right == false)
            {
                Left = true;
                //if (!hero.TouchingLeft)
                    hero.ChangeVelocity(-movementSpeed, null);
                    //hero.Velocity.X = -movementSpeed;
            }
            if (stateKey.IsKeyUp(Keys.Left) && Right == false)
            {
                Left = false;
                hero.ChangeVelocity(0, null);
                //hero.Velocity.X = 0;
            }
            if (stateKey.IsKeyDown(Keys.Right) && Left == false)
            {
                Right = true;
                hero.ChangeVelocity(movementSpeed, null);
                //hero.Velocity.X = movementSpeed;
            }
            if (stateKey.IsKeyUp(Keys.Right) && Left == false)
            {
                Right = false;
                hero.ChangeVelocity(0, null);
                //hero.Velocity.X = 0;
            }
            if (stateKey.IsKeyDown(Keys.Up) && hero.Velocity.Y == 0)
            {
                Jump = true;
                //if (!hero.TouchingTop)
                    hero.ChangeVelocity(null, -7.8f);
                    //hero.Velocity.Y = -7.8f;
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
                hero.ChangeVelocity(null, hero.Velocity.Y + 0.2f);
                //hero.Velocity.Y += 0.2f;
            }
            hero.Position += hero.Velocity;
            if (!hero.TouchingGround && hero.Velocity.Y == 0)
            {
                hero.ChangeVelocity(null, 0.2f);
                //hero.Velocity.Y = 0.2f;
            }
        }
    }
}
