using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    abstract class Shape
    {

        protected Color colour;
        protected int x, y; 
        public Shape(Color colour, int x, int y)
        {

            this.colour = colour; 
            this.x = x; 
            this.y = y; 
           
        }

        protected Shape(Color colour)
        {
            this.colour = colour;
        }

        public abstract void draw(Graphics g, Pen pen, Brush brush); 

        public override string ToString()
        {
            return base.ToString() + "    " + this.x + "," + this.y + " : ";
        }

    }
}
