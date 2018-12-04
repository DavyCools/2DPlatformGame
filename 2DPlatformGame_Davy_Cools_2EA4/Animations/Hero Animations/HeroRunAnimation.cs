using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (HeroRunAnimation) is verantwoordelijk voor
    /// de RunAnimatie van de hero
    /// Erft over van: Animation
    /// </summary>
    class HeroRunAnimation : Animation
    {
        public HeroRunAnimation()
        {
            Speed = 22;
        }
        /// <summary>
        /// Voegt frames toe aan de lijst voor de HeroRunAnimation
        /// </summary>
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(314, 1576, 217, 285) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(542, 1575, 215, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(789, 1574, 211, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1026, 1573, 210, 298) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1255, 1572, 208, 308) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1485, 1572, 208, 308) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1716, 1573, 210, 298) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1959, 1574, 211, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2202, 1575, 215, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2444, 1576, 217, 285) });
        }
    }
}
