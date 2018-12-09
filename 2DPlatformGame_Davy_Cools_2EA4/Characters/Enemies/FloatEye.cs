using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (FloatEye) is verantwoordelijk
    /// voor het tekenen van een FloatEye
    /// Erft over van: Enemy, IKillable
    /// </summary>
    class FloatEye : Enemy, IKillable
    {
        public FloatEye(ContentManager content, Vector2 position, string name) : base(content, position, name)
        {
            animation = new FloatEyeAnimation() {scale = 1f};
        }
    }
}
