using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class CollitionChecker
    {
        public bool CheckCollition(ICollide source, ICollide target)
        {
            if (source.CollisionRectangle.Intersects(target.CollisionRectangle))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsTouchingLeft(ICollide source, ICollide target)
        {
            if(source.CollisionRectangle.Right >= target.CollisionRectangle.Left)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsTouchingRight(ICollide source, ICollide target)
        {
            if(source.CollisionRectangle.Left <= target.CollisionRectangle.Right)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsTouchingTop(ICollide source, ICollide target)
        {
            if(source.CollisionRectangle.Bottom >= target.CollisionRectangle.Top)
            {
                return true;    
            }
            else
            {
                return false;
            }
        }
        public bool IsTouchingBottom(ICollide source, ICollide target)
        {
            if(source.CollisionRectangle.Top <= target.CollisionRectangle.Bottom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
