using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class Level1 : Level
    {
        public Level1(ContentManager _content) : base(_content)
        {
        }

        protected override void CreateLevelArray()
        {
            LevelArray = new byte[,]
            {
            { 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0 },
            { 1,0,1,0,1,0,0,0,0,1 },
            { 0,1,0,1,0,1,1,1,1,1 },
            };
        }
    }
}
