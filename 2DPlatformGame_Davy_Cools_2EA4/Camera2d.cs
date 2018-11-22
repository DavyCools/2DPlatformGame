using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class Camera2d
    {
        public Matrix Transform { get; private set; }
        public float Zoom { get; set; }
        public void Follow(Hero hero)
        {
            Matrix scale = Matrix.CreateScale(Zoom, Zoom, 1);
            var position = Matrix.CreateTranslation(
                -hero.position.X - (hero.CollisionRectangle.Width / 2),
                -hero.position.Y - (hero.CollisionRectangle.Height / 2),
                0);
            var offset = Matrix.CreateTranslation(
                Game1.ScreenWidth/2 / Zoom,
                Game1.ScreenHeight/2 / Zoom,
                0);
            Transform = position * offset * scale;
        }
    }
}
