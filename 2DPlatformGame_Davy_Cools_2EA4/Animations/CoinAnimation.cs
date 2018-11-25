using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class CoinAnimation : Animation
    {
        public CoinAnimation()
        {
            Speed = 6;
        }
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(0, 0, 250, 250) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(280, 0, 222, 250) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(552, 0, 120, 250) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(120, 303, 40, 250) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(283, 303, 120, 250) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(464, 303, 222, 250) });
        }
    }
}
