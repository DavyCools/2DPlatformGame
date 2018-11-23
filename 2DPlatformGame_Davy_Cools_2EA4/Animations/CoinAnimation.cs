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
            Speed = 5;
        }
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(308, 2035, 205, 295) });
        }
    }
}
