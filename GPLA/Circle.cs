using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    class Circle : Shape
    {
        int radius;
        

        public Circle(Color colour, int x, int y, int radius):base(colour,x,y)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

       

        public override void draw(Graphics g, Pen pen, Brush brush) { 

           
            g.FillEllipse(brush, x, y, radius * 2, radius * 2);
            g.DrawEllipse(pen, x, y, radius * 2, radius * 2);

        }

        public override string ToString() 
        {
            return base.ToString() + "  " + this.radius;
        }
    }
}
