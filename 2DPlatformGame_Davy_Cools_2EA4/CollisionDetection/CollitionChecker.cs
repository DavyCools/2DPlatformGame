using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    public class CollitionChecker
    {
        public void CheckCollition(Hero hero, List<ICollide> CollisionList)
        {
            foreach (ICollide tempBlock in CollisionList)
            {
                reset(hero);
                if (hero.Velocity.Y >= 0 && isTouchingTop(hero,tempBlock))
                {
                    hero.Velocity.Y = 0;
                    hero.TouchingGround = true;
                }
                if (hero.Velocity.Y <= 0 && isTouchingBottom(hero, tempBlock))
                {
                    hero.Velocity.Y = 0.2f;
                    hero.TouchingTop = true;
                }
                if (hero.Velocity.X < 0 && isTouchingRight(hero, tempBlock))
                {
                    hero.Velocity.X = 0;
                    hero.position.X += 3;
                    hero.TouchingLeft = true;
                }
                if (hero.Velocity.X > 0 && isTouchingLeft(hero,tempBlock))
                {
                    hero.Velocity.X = 0;
                    hero.position.X -= 3;
                    hero.TouchingRight = true;
                }

                /*if (hero.CollisionRectangle.Intersects(tempBlock.CollisionRectangle))
                {
                    return true;
                }
                else
                {
                    return false;
                }*/
            }       
        }
        private void reset(Hero hero)
        {
            hero.TouchingGround = false;
            hero.TouchingLeft = false;
            hero.TouchingRight = false;
            hero.TouchingTop = false;
        }
        private bool isTouchingLeft(Hero source, ICollide target)
        {
            return source.CollisionRectangle.Right  > target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Top + target.CollisionRectangle.Width / 10 &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Bottom - target.CollisionRectangle.Width / 10;
            
        }
        private bool isTouchingRight(Hero source, ICollide target)
        {
            return source.CollisionRectangle.Left < target.CollisionRectangle.Right &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Right &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Top + target.CollisionRectangle.Width / 10 &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Bottom - target.CollisionRectangle.Width / 10;
        }
        private bool isTouchingTop(Hero source, ICollide target)
        {
            return source.CollisionRectangle.Bottom + source.Velocity.Y > target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Left + target.CollisionRectangle.Width / 10 &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Right - target.CollisionRectangle.Width / 10;
        }
        private bool isTouchingBottom(Hero source, ICollide target)
        {
            return source.CollisionRectangle.Top + source.Velocity.Y < target.CollisionRectangle.Bottom &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Bottom &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Left + target.CollisionRectangle.Width / 10 &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Right - target.CollisionRectangle.Width / 10;
        }
    }
}
