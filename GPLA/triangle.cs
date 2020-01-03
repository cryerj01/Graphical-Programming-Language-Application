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
        private Point[] pnt;
        public Triangle( Point[] pnt) 
        {

            this.pnt = pnt; 
        }
        public Triangle() { }

        public override void setTriangle(int x, int y, Point[] points)
        {
            base.set(x, y);
            this.pnt = points;
        }
        public override void Draw(Graphics g, Pen pen, Brush brush)
        {

            g.DrawPolygon(pen, pnt);
            g.FillPolygon(brush, pnt);
        }
        
        
    }
}
