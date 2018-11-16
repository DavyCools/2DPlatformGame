using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class CollitionChecker
    {
        public bool CheckCollition(Collide source, Collide target)
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
    }
}
