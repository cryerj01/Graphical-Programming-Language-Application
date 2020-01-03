using System.Drawing;

namespace GPLA
{
     
        interface Shapesinterface
        {
            void set(params int[] list);
            void setTriangle(int x, int y, Point[] points);
            void Draw(Graphics g, Pen pen, Brush brush);

        }
    
}