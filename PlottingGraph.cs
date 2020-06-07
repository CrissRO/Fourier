using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Fourier
{
    class PlottingGraph
    {
        private Vector2 position;
        private Vector2 size;
        public List<PlotLine> plots;
        public Vector2 xAxis,yAxis;

        public PlottingGraph(Vector2 position,Vector2 size)
        {
            this.position = position;
            this.size = size;
            plots = new List<PlotLine>();
        }

        public void Plot(PlotLine pl)
        {
            List<Vector2> values = new List<Vector2>();

            float minX = pl.values.Min(v => v.X);
            float maxX = pl.values.Max(v => v.X);
            float minY = pl.values.Min(v => v.Y);
            float maxY = pl.values.Max(v => v.Y);

            float minSize = size.X < size.Y ? size.X : size.Y;
            foreach (Vector2 v in pl.values)
                values.Add(new Vector2(mapValue(v.X, minX, maxX, 0, minSize), position.Y + size.Y/2 -  mapValue(v.Y, minY, maxY, 0, minSize)));

            PlotLine plotLine = new PlotLine(values,pl.color);
            plots.Add(plotLine);
        }
        

        public static float mapValue(float value,float minIn,float maxIn, float minOut, float maxOut)
        {
            return (value - minIn) / (maxIn - minIn) * (maxOut - minOut) + minOut;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (PlotLine pl in plots)
                pl.Draw(spriteBatch,position);
        }



    }
}
