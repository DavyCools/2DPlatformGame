using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (HeroHitAnimation) is verantwoordelijk voor
    /// de HitAnimatie van de hero
    /// Erft over van: Animation
    /// </summary>
    class HeroHitAnimation : Animation
    {
        public HeroHitAnimation()
        {
            Speed = 20;
        }
        /// <summary>
        /// Voegt frames toe aan de lijst voor de HeroHitAnimation
        /// </summary>
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(307, 2355, 203, 294) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(568, 2355, 210, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(805, 2356, 210, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1077, 2356, 220, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1323, 2357, 215, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1584, 2357, 204, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1827, 2356, 205, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2065, 2356, 220, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2299, 2355, 210, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2527, 2355, 203, 294) });
        }
    }
}
