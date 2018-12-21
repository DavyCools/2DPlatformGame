using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// Deze klasse (Camera2d) is verantwoordelijk voor
    /// het volgen van een beweegbaar object
    /// </summary>
    class Camera2d
    {
        public Matrix Transform { get; private set; }
        public float Zoom { get; set; }
        /// <summary>
        /// Volgt het meegegeven object zodat deze steeds in het midden van het scherm blijft
        /// </summary>
        /// <param name="Character"></param>
        public void Follow(IMoveableObject Character)
        {
            Matrix scale = Matrix.CreateScale(Zoom, Zoom, 1);
            var position = Matrix.CreateTranslation(
                -Character.Position.X - (Character.CollisionRectangle.Width / 2),
                -Character.Position.Y - (Character.CollisionRectangle.Height / 2),
                0);
            var offset = Matrix.CreateTranslation(
                GameMenuScreen.ScreenWidth/2 / Zoom,
                GameMenuScreen.ScreenHeight/2 / Zoom,
                0);
            Transform = position * offset * scale;
        }
    }
}
