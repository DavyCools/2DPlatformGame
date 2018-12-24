﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (FloatEyeAnimation) is verantwoordelijk voor
    /// de FloatEye animatie
    /// Erft over van: Animation
    /// </summary>
    class FloatEyeAnimation : Animation
    {
        public FloatEyeAnimation()
        {
            Speed = 5;
        }
        /// <summary>
        /// Voegt frames toe aan de lijst voor de FloatEyeAnimation
        /// </summary>
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(0, 96, 48, 48) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(48, 96, 48, 48) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(96, 96, 48, 48) });
        }
    }
}
