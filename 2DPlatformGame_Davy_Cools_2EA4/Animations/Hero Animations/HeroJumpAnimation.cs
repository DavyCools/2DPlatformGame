using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (HeroJumpAnimation) is verantwoordelijk voor
    /// de JumpAnimatie van de hero
    /// Erft over van: Animation
    /// </summary>
    class HeroJumpAnimation : Animation
    {
        public HeroJumpAnimation()
        {
            Speed = 15;
        }
        /// <summary>
        /// Voegt frames toe aan de lijst voor de HeroJumpAnimation
        /// </summary>
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(308, 2035, 205, 295) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(547, 2036, 210, 292) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(785, 2040, 220, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1035, 2043, 224, 283) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1286, 2013, 215, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1538, 1961, 211, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1770, 1934, 214, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2009, 1960, 211, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2238, 2008, 204, 282) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2459, 2035, 205, 295) });
        }
    }
}
