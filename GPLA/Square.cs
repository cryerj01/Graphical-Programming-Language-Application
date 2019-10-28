using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    class Square : Rectangle
    {
        private int size;
        public Square(Color colour, int x, int y, int size) : base(colour, x, y, size, size)
        {
            this.size = size;
        }

        
        public override void draw(Graphics g,Pen pen, Brush brush)
        {
            base.draw(g,pen,brush);
        }

    }
}
