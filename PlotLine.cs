using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourier
{
    class PlotLine
    {
        public Color color { get; set; }
        public List<Vector2> values;
        public PlotLine(List<Vector2> values,Color color)
        {
            this.values = values;
            this.color = color;
        }

        

        public void Draw(SpriteBatch spriteBatch,Vector2 offset)
        {
            
            foreach (Vector2 v in values)
                Primitives.DrawPoint(spriteBatch, Vector2.Add(v,offset),2, color);
        }
    }
}
