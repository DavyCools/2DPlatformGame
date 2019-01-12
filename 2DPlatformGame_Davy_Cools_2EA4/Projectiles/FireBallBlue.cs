using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (FireBallBlue) is verantwoordelijk voor 
    /// de eigenschappen van een blauwe vuurbal
    /// Erft over van: Projectile
    /// </summary>
    class FireBallBlue : Projectile
    {
        public FireBallBlue(Texture2D _texture, Vector2 _position, bool _flipAnimation) : base(_texture, _position, _flipAnimation)
        {
            
        }
    }
}
