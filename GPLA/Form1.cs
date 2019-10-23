using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            String input = ControlePanel.Text;
            if (input.Trim() == "")
            {
                MessageBox.Show("Enter a command", "ERROR");
            }
            else
            {
               String[] lines = ControlePanel.Lines.ToArray();
                
               
                int count = 0;
                using (var g = Graphics.FromImage(display.Image))

                    
                    while (lines.Length >= count) {
                        Pen myPen = new Pen(Color.Pink, 2); 
                       
                        Regex regex = new Regex(@"\(([^\)]+)\)");

                        try
                        {
                            String output = regex.Replace(lines[count], "");


                            
                            string line = lines[count];
                           // string insideParentheses = Regex.Match(line, "([0-9][0-9][0-9])").Groups(0).ToString();
                            switch (output.ToLower())
                            {
                                case "circle":
                                    MessageBox.Show("You Drew a Circle", "Messgae");
                                    g.DrawEllipse(myPen, 50, 50, 200, 100);
                                    count++;
                                    break;
                                case "rectangle":
                                    MessageBox.Show("You Drew a Rectangle", "Message");
                                    g.DrawRectangle(myPen, 0, 0, 50, 20);
                                    count++;
                                    break;
                                case "squear":
                                    MessageBox.Show("You Drew a Rectangle", "Message");
                                    g.DrawRectangle(myPen, 0, 30, 50, 50);
                                    count++;
                                    break;
                                case "line":
                                    MessageBox.Show("Your Drew a Line", "Message");
                                    g.DrawLine(myPen, 0, 20, 20, 50);
                                    count++;
                                    break;
                                case "clear":
                                    g.Clear(Color.Transparent);
                                    count++;
                                    break;
                                default:
                                    MessageBox.Show(output + lines[count] + " not a Command", "MEessgae");
                                    count++;
                                    break;

                            }
                            display.Refresh();
                        }
                        catch 
                        {
                            count = lines.Length + 1;
                        }
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
