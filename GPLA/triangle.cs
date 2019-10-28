using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    class Triangle : Shape
    {
        Point[] pnt;
        public Triangle(Color colour, Point[] pnt) : base(colour)
        {

            this.pnt = pnt; 
        }


        public override void draw(Graphics g, Pen pen, Brush brush)
        {

            g.DrawPolygon(pen, pnt);
        }

        
    }
}
