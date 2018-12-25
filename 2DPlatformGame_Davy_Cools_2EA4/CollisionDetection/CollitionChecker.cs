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
        /// <summary>
        /// Controleert of een bepaald object een ander bepaald opbject raakt
        /// </summary>
        /// <param name="movingObjectList"></param>
        /// <param name="CollisionList"></param>
        /// <returns></returns>
        public List<IDrawObject> CheckCollition(List<IMoveableObject> movingObjectList, List<ICollide> CollisionList)
        {
            List<IDrawObject> _returnTiles = new List<IDrawObject>();
            foreach (IMoveableObject source in movingObjectList.ToList())
            {
                foreach (ICollide target in CollisionList.ToList())
                {
                    if (source is Hero)
                    {
                        if (target is IDeathly)
                        {
                            if(source.CollisionRectangle.Intersects(target.CollisionRectangle))
                                ((IDeathly)source).IsHit = true;
                        }
                        else if (target is Coin)
                        {
                            if (source.CollisionRectangle.Intersects(target.CollisionRectangle))
                            {
                                ((Hero)source).TotalCoins++;
                                CollisionList.Remove(target);
                                _returnTiles.Add((IDrawObject)target);
                            }   
                        }
                        else if (!(target is ICollideInvisible))
                        {
                            IsTouchingSides(source,target);
                        }
                    }
                    else if (source is Enemy)
                    {
                        if(target is IDeathly)
                        {
                            if (source.CollisionRectangle.Intersects(target.CollisionRectangle))
                                ((IDeathly)target).IsHit = true;
                        }
                        else if (!(target is Enemy) && !(target is CollectableTiles))
                        {
                            IsTouchingSides(source, target);
                        }
                    }
                    else if (source is Projectile)
                    {
                        if(target is IKillable)
                        {
                            if (source.CollisionRectangle.Intersects(target.CollisionRectangle))
                            {
                                ((IDeathly)source).IsHit = true;
                                ((IDeathly)target).IsHit = true;
                                _returnTiles.Add((IDrawObject)target);
                                CollisionList.Remove(target);
                            }   
                        }
                        else if (!(target is ICollideInvisible || target is CollectableTiles))
                        {
                            if (source.CollisionRectangle.Intersects(target.CollisionRectangle))
                            {
                                ((IDeathly)source).IsHit = true;
                            }   
                        }
                    }
                }
            }
            return _returnTiles;
        }
        /// <summary>
        /// Controleert aan welke kant een object het ander object raakt
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        private void IsTouchingSides(IMoveableObject source, ICollide target)
        {
            if (source.Velocity.Y >= 0 && IsTouchingTop(source, target))
            {
                source.ChangeVelocity(null, 0);
                source.TouchingGround = true;
            }
            if(!(source is Enemy) || source is Flame)
            if (source.Velocity.Y <= 0 && IsTouchingBottom(source, target))
            {
                source.ChangeVelocity(null, 0.2f);
                source.TouchingTop = true;
            }
            if(!(source is Flame)){
                if (source.Velocity.X < 0 && IsTouchingRight(source, target))
                {
                    source.ChangeVelocity(0, null);
                    source.ChangePosition(source.Position.X + source.MovementSpeed, null);
                    source.TouchingLeft = true;
                }
                if (source.Velocity.X > 0 && IsTouchingLeft(source, target))
                {
                    source.ChangeVelocity(0, null);
                    source.ChangePosition(source.Position.X - source.MovementSpeed, null);
                    source.TouchingRight = true;
                }
            }
            
        }
        /// <summary>
        /// Controleert of het de source het target links raakt
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool IsTouchingLeft(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Right + source.Velocity.X > target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Bottom;
            
        }
        /// <summary>
        /// Controleert of de source het target rechts raakt
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool IsTouchingRight(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Left + source.Velocity.X < target.CollisionRectangle.Right &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Right &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Bottom;
        }
        /// <summary>
        /// Controleert of de source het target vanboven raakt
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool IsTouchingTop(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Bottom + source.Velocity.Y > target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Top < target.CollisionRectangle.Top &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Right;
        }
        /// <summary>
        /// Controleert of de source het target vanonder raakt
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool IsTouchingBottom(IMoveableObject source, ICollide target)
        {
            return source.CollisionRectangle.Top + source.Velocity.Y < target.CollisionRectangle.Bottom &&
                   source.CollisionRectangle.Bottom > target.CollisionRectangle.Bottom &&
                   source.CollisionRectangle.Right > target.CollisionRectangle.Left &&
                   source.CollisionRectangle.Left < target.CollisionRectangle.Right;
        }
    }
}
