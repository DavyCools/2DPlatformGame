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
    /// Deze klasse (MovementArrowsKeys) is verantwoordelijk voor 
    /// de bewgeging van een meegegeven beweegbaar object (IMoveableObject) als er op 1 van de gedefinieerde knoppen wordt gedrukt.
    /// Erft over van: Movement
    /// </summary>
    class MovementArrowKeys : Movement
    {
        /// <summary>
        /// Controleert welke knop er ingedrukt is
        /// </summary>
        /// <param name="moveableObject"></param>
        public override void Update(IMoveableObject moveableObject)
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.T) && TeleportCheat)
                moveableObject.ChangePosition(11561, 642);
            if (stateKey.IsKeyDown(Keys.Left) && Right == false)
            {
                Left = true;
                moveableObject.ChangeVelocity(-movementSpeed, null);
            }
            if (stateKey.IsKeyUp(Keys.Left) && Right == false)
            {
                Left = false;
                moveableObject.ChangeVelocity(0, null);
            }
            if (stateKey.IsKeyDown(Keys.Right) && Left == false)
            {
                Right = true;
                moveableObject.ChangeVelocity(movementSpeed, null);
            }
            if (stateKey.IsKeyUp(Keys.Right) && Left == false)
            {
                Right = false;
                moveableObject.ChangeVelocity(0, null);
            }
            if (stateKey.IsKeyDown(Keys.Up) && moveableObject.Velocity.Y == 0)
            {
                Jump = true;
                moveableObject.ChangeVelocity(null, -7.8f);
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
            if (moveableObject.Velocity.Y != 0)
            {
                moveableObject.ChangeVelocity(null, moveableObject.Velocity.Y + 0.2f);
            }
            moveableObject.Position += moveableObject.Velocity;
            if (!moveableObject.TouchingGround && moveableObject.Velocity.Y == 0)
            {
                moveableObject.ChangeVelocity(null, 0.2f);
            }
        }
    }
}
