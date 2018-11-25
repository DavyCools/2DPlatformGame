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
        public void CheckCollision(IMoveableObject movingObject, List<ICollide> CollisionList)
        {
            foreach (ICollide tempBlock in CollisionList)
            {
                    reset(movingObject);
                    if (movingObject.Velocity.Y >= 0 && isTouchingTop(movingObject, tempBlock))
                    {
                        movingObject.ChangeVelocity(null, 0);
                        movingObject.TouchingGround = true;
                    }
                    if (movingObject.Velocity.Y <= 0 && isTouchingBottom(movingObject, tempBlock))
                    {
                        movingObject.ChangeVelocity(null, 0.2f);
                        movingObject.TouchingTop = true;
                    }
                    if (movingObject.Velocity.X < 0 && isTouchingRight(movingObject, tempBlock))
                    {
                        movingObject.ChangeVelocity(0, null);
                        movingObject.ChangePosition(movingObject.Position.X + movingObject.MovementSpeed, null);
                        movingObject.TouchingLeft = true;
                    }
                    if (movingObject.Velocity.X > 0 && isTouchingLeft(movingObject, tempBlock))
                    {
                        movingObject.ChangeVelocity(0, null);
                        movingObject.ChangePosition(movingObject.Position.X - movingObject.MovementSpeed, null);
                        movingObject.TouchingRight = true;
                    }
            }       
        }
        public List<Tiles> CheckCollitionIntersect(Hero hero,List<ICollide> CollisionIntersectList)
        {
            List<Tiles> _returnTiles = new List<Tiles>();
            foreach (ICollide tempObject in CollisionIntersectList.ToList())
            {
                if (hero.CollisionRectangle.Intersects(tempObject.CollisionRectangle) && !(tempObject is IMoveableObject))
                {
                    hero.TotalCoins++;
                    CollisionIntersectList.Remove(tempObject);
                    _returnTiles.Add((Tiles)tempObject);
                }
            }
            return _returnTiles;
        }
        private void reset(IMoveableObject movingObject)
        {
            movingObject.TouchingGround = false;
            movingObject.TouchingLeft = false;
            movingObject.TouchingRight = false;
            movingObject.TouchingTop = false;
        }
        private bool isTouchingLeft(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Right + source.Velocity.X > target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Bottom;
            
        }
        private bool isTouchingRight(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Left + source.Velocity.X < target.CollisionRectangle.Right &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Right &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Bottom;
        }
        private bool isTouchingTop(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Bottom + source.Velocity.Y > target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Right;
        }
        private bool isTouchingBottom(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Top + source.Velocity.Y < target.CollisionRectangle.Bottom &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Bottom &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Right;
        }
    }
}
