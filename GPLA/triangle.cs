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
        readonly Point[] pnt;
        public Triangle( Point[] pnt) 
        {

            this.pnt = pnt; 
        }


        public override void Draw(Graphics g, Pen pen, Brush brush)
        {

            g.DrawPolygon(pen, pnt);
            g.FillPolygon(brush, pnt);
        }
        
        
    }
}
