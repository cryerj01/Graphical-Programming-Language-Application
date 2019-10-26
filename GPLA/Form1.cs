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

        private Pen pen = new Pen(Color.Pink, 2);

        public Form1()
        {
            InitializeComponent();
            display.Image = new Bitmap(Size.Width, Size.Height);


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            String input = ControlePanel.Text;
            if (input.Trim() == "")
            {
                MessageBox.Show("Enter a command", "ERROR");
            }
            else
            {
               String[] lines = ControlePanel.Lines.ToArray();
               // MessageBox.Show(lines.ToString(), "test");
                
                ArrayList Currentline = new ArrayList();
                String[] line;
                int i = 0;

                while (lines.Length != i) {

                    line = lines[i].Split(' ');
                    Currentline.Add(line);
                    i++;
                }
                int count = 0;
                using (var g = Graphics.FromImage(display.Image))
                {
                    while (lines.Length >= count)
                    {
                        

                       Pen myPen = new Pen(Color.Pink, 2);
                        
                        try
                        {
                            string[] element = (String[])Currentline[count];
                            int j = 0;
                            switch (element[j].ToLower())
                            {
                                case "circle":
                                    MessageBox.Show("You Drew a Circle", "Messgae");
                                    int radius = int.Parse(element[1]);
                                    Circle(radius);                                    
                                    break;
                                case "rectangle":
                                    MessageBox.Show("You Drew a Rectangle", "Message");
                                    int width = int.Parse(element[1]);
                                    int hight = int.Parse(element[2]);
                                    Rectangle(width, hight);
                                                                       
                                    break;
                                case "squear":
                                    MessageBox.Show("You Drew a Rectangle", "Message");
                                    g.DrawRectangle(myPen, 0, 30, 50, 50);                                    
                                    break;
                                case "line":
                                    MessageBox.Show("Your Drew a Line", "Message");
                                    g.DrawLine(myPen, 0, 20, 20, 50);                                    
                                    break;
                                case "clear":
                                    g.Clear(Color.Transparent);                                    
                                    break;
                                default:
                                    MessageBox.Show(Currentline.ToString() + "line "+ lines[count] + " not a Command", "MEessgae");
                                    break;

                            }
                            display.Refresh();
                            myPen.Dispose();
                            count++;
                        }
                        catch
                        {
                            count = lines.Length + 1;
                        }
                    }
                }
            }
        }

        private void Rectangle(int width, int hight)
        {
            using (var g = Graphics.FromImage(display.Image))
            {
                ; // get a reference to Graphics object
                Pen myPen = new Pen(Color.Pink, 2);
                g.DrawRectangle(myPen, 0, 0, width, hight);
            }
        }
        private void Circle(int radius) 
        {
            using (var g = Graphics.FromImage(display.Image)) { 
                          
            g.DrawEllipse(pen, 50, 50, 2*radius, 2 * radius);
            }
        }


        private void f11(object sender, KeyPressEventArgs e)
        {
            if (e.Equals(Keys.Enter) )
            {   // need to chenck if run is used in bottom input if not do thing.
                //move switch in to own methord called checker.
                // need to remove run button and need change event.
                Run.PerformClick();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    
}
