using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (HeroDieAnimation) is verantwoordelijk voor
    /// de DieAnimatie van de hero
    /// Erft over van: Animation
    /// </summary>
    class HeroDieAnimation : Animation
    {
        public HeroDieAnimation()
        {
            Speed = 10;
        }
        /// <summary>
        /// Voegt frames toe aan de lijst voor de HeroDieAnimation
        /// </summary>
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(335, 2695, 210, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(600, 2696, 163, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(835, 2699, 176, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1101, 2701, 183, 285) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1336, 2705, 187, 280) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1606, 2711, 201, 271) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1852, 2721, 222, 256) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2088, 2765, 261, 235) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2372, 2834, 304, 210) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2693, 2869, 521, 210) });
        }
    }
}
