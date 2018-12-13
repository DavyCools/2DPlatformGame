using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class GremlinFrontAnimation : Animation
    {
        public GremlinFrontAnimation()
        {
            Speed = 5;
        }
        /// <summary>
        /// Voegt frames toe aan de lijst voor de GremlinAnimation
        /// </summary>
        public override void AnimationFrames()
        {
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(0, 0, 48, 48) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(48, 0, 48, 48) });
            AddFrame(new AnimationFrame() { FrameSelector = new Rectangle(96, 0, 48, 48) });
        }
    }
}
