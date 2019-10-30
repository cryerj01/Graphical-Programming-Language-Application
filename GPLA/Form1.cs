using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;




namespace GPLA
{
    
    public partial class Form1 : Form
    {
        
        private readonly Pen pen = new Pen(Color.Cyan, 2);
        private Brush brush = new SolidBrush(Color.Black);
        private int x=0, y=0;
        

        public Form1()
        {
            InitializeComponent();
            display.Image = new Bitmap(Size.Width, Size.Height);
           

        }

        private void Check( ArrayList Currentline, String[]lines)
        {
            using (var g = Graphics.FromImage(display.Image))
            {
                int count = 0;
                while (lines.Length >= count)
                {
                    
                    try
                    {
                        string[] element = (String[])Currentline[count];

                        switch (element[0].ToLower())
                        {
                            case "circle":

                                int radius;
                                if (!int.TryParse(element[1], out radius))
                                {
                                    new Circle(x, y, 100).Draw(g, pen, brush);
                                }
                                else
                                {
                                    int.TryParse(element[1], out radius);
                                    new Circle(x, y, radius).Draw(g, pen, brush);
                                }
                                break;
                            case "rectangle":

                                int width;

                                int height;
                                if (!int.TryParse(element[1], out width) || !int.TryParse(element[2], out height))
                                {
                                    new Rectangle(x, y, 10, 20).Draw(g, pen, brush);

                                }
                                else
                                {
                                    int.TryParse(element[1], out width);
                                    int.TryParse(element[2], out height);
                                    new Rectangle(x, y, width, height).Draw(g, pen, brush);
                                }
                                break;
                            case "Square":
                                int side;
                                if (!int.TryParse(element[1], out side))
                                {
                                    new Square(x, y, 20).Draw(g, pen, brush);
                                }
                                else
                                {
                                    int.TryParse(element[1], out side);
                                    new Square(x, y, side).Draw(g, pen, brush);
                                }

                                break;
                            case "line":
                                int point1, point2;
                                if (!int.TryParse(element[1], out point1) || !int.TryParse(element[2], out point2))
                                {
                                    g.DrawLine(pen, x, y, 10, 10);

                                }
                                else
                                {
                                    int.TryParse(element[1], out point1);
                                    int.TryParse(element[2], out point2);
                                    g.DrawLine(pen, x, y, point1, point2);

                                }
                                break;
                            case "pencolor":
                                try
                                {
                                    pen.Color = Color.FromName(element[1]);
                                }
                                catch
                                {
                                    pen.Color = Color.Black;
                                }
                                break;
                            case "brushcolor":
                                try
                                {
                                    brush = new SolidBrush(Color.FromName(element[1]));
                                }
                                catch
                                {
                                    brush = new SolidBrush(Color.Black);
                                }
                                break;
                            case "triangle":
                                int p1, p2, p3;
                                if (!int.TryParse(element[1], out p1) || !int.TryParse(element[2], out p2) || !int.TryParse(element[3], out p3))
                                {
                                    System.Drawing.Point pointa = new System.Drawing.Point(100, 200);
                                    System.Drawing.Point pointb = new System.Drawing.Point(200, 50);
                                    System.Drawing.Point pointc = new System.Drawing.Point(50, 100);

                                    System.Drawing.Point[] pnt = { pointa, pointb, pointc };
                                    new Triangle(pnt).Draw(g, pen, brush);
                                }
                                else
                                {
                                    int.TryParse(element[1], out p1);
                                    int.TryParse(element[2], out p2);
                                    int.TryParse(element[3], out p3);
                                    System.Drawing.Point pointa = new System.Drawing.Point(p1, p2);
                                    System.Drawing.Point pointb = new System.Drawing.Point(p2, p3);
                                    System.Drawing.Point pointc = new System.Drawing.Point(p3, p1);

                                    System.Drawing.Point[] pnt = { pointa, pointb, pointc };
                                    new Triangle(pnt).Draw(g, pen, brush);
                                }
                                break;
                            case "clear":
                                g.Clear(Color.Transparent);
                                g.Dispose();
                                break;
                            case "setx":
                                int.TryParse(element[1], out x);
                                break;
                            case "sety":
                                int.TryParse(element[1], out y);
                                break;
                            case "setxy":
                                int.TryParse(element[1], out x);
                                int.TryParse(element[1], out y);

                                break;
                            default:
                                MessageBox.Show(element[0] + " not a Command", "MEessgae");
                                break;

                        }

                    }
                    catch
                    {

                    }
                    count++;

                }
               
            } 
                
        }


        private void Commandline_KeyDown(object sender, KeyEventArgs e)
           {
            if (e.KeyCode == Keys.Enter)
            {
                
                String input = commandline.Text;
                if (input.Trim() == "")
                {
                    MessageBox.Show("Enter a command", "ERROR");

                }
                else
                {
                    String[] line;
                    String[] lines;
                    ArrayList Currentline = new ArrayList();
                    int i = 0;
                    if (input.ToLower().Trim() == "run")
                    {
                        lines = ControlePanel.Lines.ToArray();
                        while (lines.Length != i)
                        {

                            line = lines[i].Split(' ');
                            Currentline.Add(line);
                            i++;
                        }

                    }
                    else
                    {
                        lines = commandline.Lines.ToArray();
                        line = commandline.Text.Split(' ');
                        Currentline.Add(line);
                        

                    }
                    Check(Currentline, lines);
                    display.Refresh();
                   
                }
            }
          

        }
        
    }
    
}
