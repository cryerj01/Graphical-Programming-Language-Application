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
        readonly int radius;
        

        public Circle( int x, int y, int radius):base(x,y)
        {
            
            this.radius = radius;
        }

       

        public override void Draw(Graphics g, Pen pen, Brush brush) { 

           
            g.FillEllipse(brush, x, y, radius * 2, radius * 2);
            g.DrawEllipse(pen, x, y, radius * 2, radius * 2);

        }

        public override string ToString() 
        {
            return base.ToString() + "  " + this.radius;
        }
    }
}
