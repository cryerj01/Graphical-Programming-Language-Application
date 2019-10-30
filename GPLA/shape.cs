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

       
        protected int x, y; 
        public Shape( int x, int y)
        {

            this.x = x; 
            this.y = y; 
           
        }

        protected Shape()
        {
           
        }

        public abstract void Draw(Graphics g, Pen pen, Brush brush); 

        public override string ToString()
        {
            return base.ToString() + "    " + this.x + "," + this.y + " : ";
        }

    }
}
