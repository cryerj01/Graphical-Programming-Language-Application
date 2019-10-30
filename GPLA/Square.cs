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
        readonly int size;
        public Square(int x, int y, int size) : base( x, y, size, size)
        {
            this.size = size;
        }

        
        public override void Draw(Graphics g,Pen pen, Brush brush)
        {
            base.Draw(g,pen,brush);
        }

    }
}
