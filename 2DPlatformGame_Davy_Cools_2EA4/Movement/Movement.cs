using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze abstracte klasse definieert de klassen die nodig zijn om te bewegen
    /// </summary>
    public abstract class Movement
    {
        protected float movementSpeed = 3;
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Jump { get; set; }
        public bool Shoot { get; set; }
        public abstract void Update(IMoveableObject hero);
    }
}
