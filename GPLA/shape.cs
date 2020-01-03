using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA
{
    abstract class Shape : Shapesinterface
    {

       
        protected int x, y; 
        public Shape( int x, int y)
        {

            this.x = x; 
            this.y = y; 
           
        }

        public Shape() 
        {
        }

        public virtual void set( params int[] list)
        {
            
            this.x = list[0];
            this.y = list[1];
          
        }
       public virtual void setTriangle(int x,int y,Point[] points)
        {
            this.x = x;
            this.y = y;
            
        }

        public abstract void Draw(Graphics g, Pen pen, Brush brush); 

        public override string ToString()
        {
            return base.ToString() + "    " + this.x + "," + this.y + " : ";
        }

      
    }
}
