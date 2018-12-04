using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (HeroAttackAnimation) is verantwoordelijk voor
    /// de AttackAnimatie van de hero
    /// Erft over van: Animation
    /// </summary>
    class HeroAttackAnimation : Animation
    {
        public HeroAttackAnimation()
        {
            Speed = 10;
        }
        /// <summary>
        /// Voegt frames toe aan de lijst voor de HeroAttackAnimation
        /// </summary>
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(309, 855, 207, 302) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(571, 855, 205, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(830, 855, 162, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1074, 856, 167, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1317, 856, 199, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1551, 856, 199, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1798, 856, 167, 286) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2034, 855, 162, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2265, 855, 205, 287) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2505, 856, 207, 302) });
        }
    }
}