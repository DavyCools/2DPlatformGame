using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze abstracte klasse (Animation) is verantwoordelijk voor
    /// het updaten van de animatie
    /// </summary>
    abstract class Animation
    {
        public List<AnimationFrame> frames;
        private double timeInterval = 0;
        private int index = 0;
        protected int Speed { get; set; }
        public AnimationFrame CurrentFrame { get; set; }
        public float scale = 0.2f;
        public Animation()
        {
            frames = new List<AnimationFrame>();
            Speed = 1;
            AnimationFrames();

        }
        /// <summary>
        /// Voegt een frame toe aan de lijst
        /// </summary>
        /// <param name="aFrame"></param>
        public void AddFrame(AnimationFrame aFrame)
        {
            frames.Add(aFrame);
            CurrentFrame = frames[0];
        }
        /// <summary>
        /// Update de animatie naar de volgende frame indien het tijdsinterval is overschreden
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            timeInterval += 256 * Speed * gameTime.ElapsedGameTime.Milliseconds / 1000;
            if (timeInterval >= 256)
            {
                index++;
                if (index > frames.Count - 1)
                {
                    index = 0;
                }
                CurrentFrame = frames[index];
                timeInterval = 0;
            }
        }
        abstract public void AnimationFrames();
    }
}
