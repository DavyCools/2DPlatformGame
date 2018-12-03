using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    abstract class Animation
    {
        public List<AnimationFrame> frames;
        double x = 0;
        int index = 0;
        public int Speed { get; set; }
        public AnimationFrame CurrentFrame { get; set; }
        public float scale = 0.2f;
        public Animation()
        {
            frames = new List<AnimationFrame>();
            Speed = 1;
            AnimationFrames();

        }
        public void AddFrame(AnimationFrame aFrame)
        {
            frames.Add(aFrame);
            CurrentFrame = frames[0];
        }
        public void Update(GameTime gameTime)
        {
            x += 256 * Speed * gameTime.ElapsedGameTime.Milliseconds / 1000;
            if (x >= 256)
            {
                index++;
                if (index > frames.Count - 1)
                {
                    index = 0;
                }
                CurrentFrame = frames[index];
                x = 0;
            }
        }
        public void Reset()
        {
            CurrentFrame = frames[0];
        }
        abstract public void AnimationFrames();
    }
}
