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
        private Color col = Color.Black;
        private Pen pen = new Pen(Color.Black, 2);
        private Brush brush = new SolidBrush(Color.Black);
        private int x=0, y=0;

        public Form1()
        {
            InitializeComponent();
            display.Image = new Bitmap(Size.Width, Size.Height);


        }

        private void check( ArrayList Currentline, String[]lines)
        {
            using (var g = Graphics.FromImage(display.Image))
            {
                int count = 0;
                while (lines.Length >= count)
                {

                    try
                    {
                        string[] element = (String[])Currentline[count];
                        int j = 0;
                        switch (element[j].ToLower())
                        {
                            case "circle":
                               
                                int radius = int.Parse(element[1]);
                                new Circle(col,x,y,radius).draw(g,pen,brush);
                                break;
                            case "rectangle":
                               
                                int width = int.Parse(element[1]);
                                int height = int.Parse(element[2]);
                                new Rectangle(col,x,y,width, height).draw(g,pen,brush);

                                break;
                            case "squear":
                               
                                int side = int.Parse(element[1]);
                                new Square(col, x, y,side ).draw(g,pen,brush);
                                break;
                            case "line":                                
                                g.DrawLine(pen, x,y, int.Parse(element[1]), int.Parse(element[2]));
                                break;
                            case "pencolor":
                                pen.Color = Color.FromName(element[1]);
                                break;
                            case "brushcolor":
                               brush = new SolidBrush(Color.FromName(element[1]));
                                break;
                            case "clear":
                                g.Clear(Color.Transparent);
                                g.Dispose();
                                break;
                            case "setx":
                                x = int.Parse(element[1]);
                                break;
                            case "sety":
                                y = int.Parse(element[1]);
                                break;
                            case "setxy":
                                x = int.Parse(element[1]);
                                y = int.Parse(element[2]);
                                break;
                            default:
                                MessageBox.Show(element[0]+ " not a Command", "MEessgae");
                                break;

                        }
                       
                    }
                    catch
                    {
                        
                    } count++;
                    
                }display.Refresh();
                    pen.Dispose();
                    brush.Dispose();
            }
        }

        private void commandline_KeyDown(object sender, KeyEventArgs e)
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

                    
                    if (input.ToLower() == "run")
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
                        i++;



                    }
                    check(Currentline, lines);
                }
            }
           

        }
    }
    
}
