using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze interface (ICollide) initialiseert
    /// de CollisionRectangle die gebruikt wordt om te kijken of objecten elkaar raken
    /// </summary>
    public interface ICollide
    {
        Rectangle CollisionRectangle { get;}
    }
}
