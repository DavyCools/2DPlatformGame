using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    abstract class CollectableTiles : StaticTiles, IUpdate
    {
        protected Animation animation;
        public CollectableTiles(ContentManager content, Vector2 _position, string name) : base(content, _position, name)
        {
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
    }
}
