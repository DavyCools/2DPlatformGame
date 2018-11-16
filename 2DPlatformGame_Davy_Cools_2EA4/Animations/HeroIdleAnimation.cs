using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class HeroIdleAnimation : Animation
    {
        public HeroIdleAnimation(){
            Speed = 9;
        }
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(306, 175, 207, 302) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(546, 175, 206, 301) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(776, 175, 205, 298) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1007, 175, 203, 295) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1257, 175, 203, 293) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1487, 175, 203, 293) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1717, 175, 203, 295) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(1936, 175, 205, 298) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2146, 175, 206, 301) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(2366, 175, 207, 302) });
        }
    }
}
