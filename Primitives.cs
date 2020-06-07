using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourier
{
    
    class Primitives
    {
        public static Texture2D point { get; set; }


        public static void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end,Color color)
        {
            Vector2 edge = end - start;
            float angle =(float)Math.Atan2(edge.Y, edge.X);

            sb.Draw(point,
                new Rectangle(
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), 
                    1), 
                null,
                color,
                angle,
                Vector2.Zero,
                SpriteEffects.None,
                0);

        }


        public static void DrawPoint(SpriteBatch sb, Vector2 position,int size, Color color)
        {
            
            sb.Draw(point,
                new Rectangle(
                    (int)position.X - size / 2,
                    (int)position.Y - size / 2,
                    size,
                    size),
                null,
                color,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                0);

        }

    }
}
