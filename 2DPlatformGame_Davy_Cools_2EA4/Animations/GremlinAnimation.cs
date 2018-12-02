using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class GremlinAnimation : Animation
    {
        public GremlinAnimation()
        {
            Speed = 5;
        }
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(0, 96, 48, 48) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(48, 96, 48, 48) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(96, 96, 48, 48) });
        }
    }
}
