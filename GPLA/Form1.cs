using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA
{
    public partial class Form1 : Form
    {
       
        Pen pen = new Pen(Color.Blue, 5);

        public Form1()
        {
            InitializeComponent();
            display.Image = new Bitmap(Size.Width, Size.Height);


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String input = command.Text;
            if (input.Trim() == "")
            {
                MessageBox.Show("Enter a command", "ERROR");
            }
            else
            {
                input = command.Text.Trim();
                int x = 0;
                using (var g = Graphics.FromImage(display.Image))
                {
                    Pen myPen = new Pen(Color.Pink, 2);
                    switch (input.ToLower())
                    {
                        case "circle":
                            MessageBox.Show("You Drew a Circle", "Messgae");


                            g.DrawEllipse(myPen, 50, 50, 200, 100);
                            

                            break;
                        case "rectangle":
                            MessageBox.Show("You Drew a Rectangle", "Message");
                            g.DrawRectangle(myPen,0, 0, 50, 20);
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
                            MessageBox.Show("This is not a Shape", "MEessgae");
                            x = -1;
                            break;

                    }
                    display.Refresh();
                    
                } if (x == -1)
                {

                }
                else {
                Button btn = sender as Button;
                listBox1.Items.Add(input);
                command.Clear();
                    x = 0;
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void command_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Run.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void drawCircle(PaintEventArgs e)
        {
            Graphics g = e.Graphics; // get a reference to Graphics object
            Pen myPen = new Pen(Color.Pink, 2);


            g.DrawEllipse(myPen, 50, 50, 200, 100);

        }


        private void Run_Paint(object sender, PaintEventArgs e)
        {

        }

        private void display_Paint(object sender, PaintEventArgs e)
        {

        }

        private void display_Click(object sender, EventArgs e)
        {

        }
    }
}
