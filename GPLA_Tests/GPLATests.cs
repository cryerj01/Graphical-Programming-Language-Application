using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPLA;
using System.Collections;
using System.Windows.Forms;

namespace GPLA_Tests
{
    [TestClass]
    public class GPLATests
    {

        [TestMethod]
        public void _draw_shapes_with_variables()
        {
            ArrayList Currentline = new ArrayList();
            String[] lines = { "Circle 100", "Square 100", "Rectangle 10 20", "Triangle 40 50 60" };
            string[] line;
            int i = 0;
            while (lines.Length > i)
            {
                line = lines[i].Split(' ');
                Currentline.Add(line);
                i++;
            }
            int linecount = 4;
            Form1 test = new Form1();
            test.excicute(Currentline, lines,linecount);

        }
        [TestMethod]
            public void draw_shapes_no_variables()
        {
            ArrayList Currentline = new ArrayList();
            String[] lines = { "Circle", "Square", "Rectangle", "Triangle" };
            string[] line;
            int i = 0;
            while (lines.Length > i)
            {
                line = lines[i].Split(' ');
                Currentline.Add(line);
                i++;
            }
            int linecount = 4;
            Form1 test = new Form1();
            test.excicute(Currentline, lines, linecount);


        }
       
        

        [TestMethod]
        public void exicuteWorkswithErrors()
        {
            ArrayList Currentline = new ArrayList();
            String[] lines = { "Circle 12j", "Square j1ho2 ", "Rectangle 12b", "Triangle 100 200 150" };
            string[] line;
            int i = 0;
            while (lines.Length > i)
            {
                line = lines[i].Split(' ');
                Currentline.Add(line);
                i++;
            }
            int linecount = 4;
            Form1 test = new Form1();
            test.Check(Currentline, lines, linecount);
        }

        [TestMethod]

        public void loopAndFactoryWork()
        {
            ArrayList Currentline = new ArrayList();
            String[] lines = { "loop 2000", "Factory Circle", "end" };
            string[] line;
            int i = 0;
            while (lines.Length > i)
            {
                line = lines[i].Split(' ');
                Currentline.Add(line);
                i++;
            }
            int linecount = 3;
            Form1 test = new Form1();
            test.excicute(Currentline, lines, linecount);

        }
        [TestMethod]
        public void ifstatmentworks()
        {
            ArrayList Currentline = new ArrayList();
            String[] lines = { "if 10 > 20", "brushcolor green", "brishcolor red", "circle 100" };
            string[] line;
            int i = 0;
            while (lines.Length > i)
            {
                line = lines[i].Split(' ');
                Currentline.Add(line);
                i++;
            }
            int linecount = 3;
            Form1 test = new Form1();
            test.excicute(Currentline, lines, linecount);

        }

        [TestMethod]
        public void factoryshpaeswork()
        {
            ArrayList Currentline = new ArrayList();
            String[] lines = { "factory rectangle", "Factory Circle", "factory triangle" };
            string[] line;
            int i = 0;
            while (lines.Length > i)
            {
                line = lines[i].Split(' ');
                Currentline.Add(line);
                i++;
            }
            int linecount = 3;
            Form1 test = new Form1();
            test.excicute(Currentline, lines, linecount);
        }
        
    }
}
