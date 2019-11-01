using System;
using System.Collections;
using GPLA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace GPLATEST
{
    [TestClass]
    public class GPLA_TESTS
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
                Form1 test = new Form1();
                test.Check(Currentline, lines);

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
                Form1 test = new Form1();
                test.Check(Currentline, lines);


            }
            /*
            [TestMethod]
           public void runs_commandline_on_enter()
          {
               object s = null;
               Keys k = new Keys();
             

                Form1 test = new Form1();

                 test.Commandline_KeyDown(s, SendKeys.Send("{ENTER}") );// cant simulate keypress.

            }
            */
        }
    }
}
