using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (CollitionChecker) is verantwoordelijk voor 
    /// het controleren of objecten elkaar raken
    /// </summary>
    class CollitionChecker
    {
        public void CheckCollision(List<IMoveableObject> movingCharacterList, List<ICollide> CollisionList)
        {
            foreach(IMoveableObject movingObject in movingCharacterList.ToList())
            {
                foreach (ICollide collisionObject in CollisionList)
                {
                    if(movingObject is Projectile)
                    {
                        if (movingObject.CollisionRectangle.Intersects(collisionObject.CollisionRectangle))
                        {   
                            IDeathly temp = (IDeathly)movingObject;
                            temp.IsHit = true;
                            movingCharacterList.Remove(movingObject);
                        }
                    }
                    else
                    {
                        if (movingObject.Velocity.Y >= 0 && IsTouchingTop(movingObject, collisionObject))
                        {
                            movingObject.ChangeVelocity(null, 0);
                            movingObject.TouchingGround = true;
                        }
                        if (movingObject.Velocity.Y <= 0 && IsTouchingBottom(movingObject, collisionObject))
                        {
                            movingObject.ChangeVelocity(null, 0.2f);
                            movingObject.TouchingTop = true;
                        }
                        if (movingObject.Velocity.X < 0 && IsTouchingRight(movingObject, collisionObject))
                        {
                            movingObject.ChangeVelocity(0, null);
                            movingObject.ChangePosition(movingObject.Position.X + movingObject.MovementSpeed, null);
                            movingObject.TouchingLeft = true;
                        }
                        if (movingObject.Velocity.X > 0 && IsTouchingLeft(movingObject, collisionObject))
                        {
                            movingObject.ChangeVelocity(0, null);
                            movingObject.ChangePosition(movingObject.Position.X - movingObject.MovementSpeed, null);
                            movingObject.TouchingRight = true;
                        }
                    } 
                }
            }
                  
        }
        public List<IDrawObject> CheckCollitionIntersect(List<IMoveableObject> movingCharacterList, List<ICollide> CollisionList)
        {
            List<IDrawObject> _returnTiles = new List<IDrawObject>();
            foreach (IMoveableObject movingObject in movingCharacterList.ToList())
            {
                foreach (ICollide collisionObject in CollisionList.ToList())
                {
                    if (movingObject.CollisionRectangle.Intersects(collisionObject.CollisionRectangle))
                    {
                        if(movingObject is Hero)
                        {
                            if (collisionObject is Coin)
                            {
                                Hero temp = (Hero)movingObject;
                                temp.TotalCoins++;
                                CollisionList.Remove(collisionObject);
                                _returnTiles.Add((IDrawObject)collisionObject);
                            }
                            if(collisionObject is IDeathly)
                            {
                                IDeathly temp = (IDeathly)movingObject;
                                temp.IsHit = true;
                            }
                        }
                        else
                        {
                            IDeathly temp = (IDeathly)movingObject;
                            temp.IsHit = true;
                            if((collisionObject is IKillable))
                            {
                                movingCharacterList.Remove(movingObject);
                                CollisionList.Remove(collisionObject);
                                _returnTiles.Add((IDrawObject)collisionObject);
                            }
                        }
                    }
                }
            }
            return _returnTiles;
        }
        private bool IsTouchingLeft(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Right + source.Velocity.X > target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Bottom;
            
        }
        private bool IsTouchingRight(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Left + source.Velocity.X < target.CollisionRectangle.Right &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Right &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Bottom;
        }
        private bool IsTouchingTop(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Bottom + source.Velocity.Y > target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Right;
        }
        private bool IsTouchingBottom(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Top + source.Velocity.Y < target.CollisionRectangle.Bottom &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Bottom &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Right;
        }
    }
}
