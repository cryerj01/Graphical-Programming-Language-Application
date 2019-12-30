using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

       
       
        private int x = 0, y = 0;
        private static int varCount = 0;
        private  string[] vars = new string[50];
        private  string[] varsParams = new string[50];


        public Form1()
        {
            InitializeComponent();
            display.Image = new Bitmap(Size.Width, Size.Height);
           

        }

        private void Check( ArrayList Currentline)
        {

            using (var g = Graphics.FromImage(display.Image))
            {
                int count = 0;
                while (lines.Length >= count)
                {
                    Pen pen = new Pen(Color.Cyan, 2);
                    Brush brush = new SolidBrush(Color.Black);

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

                            case "var":
                                VarCheck(element[1],element[2]);
                                break;
                            case "loop":
                                int loopmax=0;
                                int next = count;
                                int.TryParse(element[1],out loopmax);

                                next++;
                                int k=0;
                                ArrayList loopedcommands= new ArrayList();

                                if (element[next] == "end")
                                {
                                    lopper(loopedcommands);
                                }
                                else
                                {
                                    loopedcommands[k] = Currentline[next];
                                }
                                

                                
                                break;
                            default: 
                                if (element[0].Trim() == null)
                                {

                                }
                                else 
                                {
                                    int i = 0;
                                    bool varthere = true;
                                    if (vars[0] != null)
                                    {
                                        while (49 >= i)
                                        {
                                            if (vars[i] == element[0])
                                            {
                                                MessageBox.Show(element[0] + " called", "whoop");
                                                i = 50;
                                            }
                                            else if (i != vars.Length)
                                            {
                                                i++;
                                            }
                                            else
                                            {
                                                varthere = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        varthere = false;
                                    }
                                    if (varthere == false) {
                                        MessageBox.Show(element[0] + " not a Command", "MEessgae");
                                    }
                                }
                                break;

                        }

                    }
                    catch
                    {
                  
                    }
                    pen.Dispose();
                    brush.Dispose();
                    count++;

                }
               
            } 
                
        }

        private void lopper(ArrayList loopedcommands)
        {
            Check(loopedcommands);
        }

        private void VarCheck(string element1, string element2)
        {
            int i = 0;
            try
            {
                if (vars[0] == null && varsParams[0] == null)  // arrays max is [49];
                {
                    vars[0] = element1;//name 
                    varsParams[0] = element2;//value
                }
                else
                {
                    while (49 >= i)
                    {
                        if (vars[i].Equals(element1))//if names are the same
                        {
                            if (varsParams[i].Equals(element2))
                            {
                                MessageBox.Show("Variable already decleard", "Error");

                                i = vars.Length;
                            }
                            else
                            {
                                
                            }
                        }
                        else if (i >= vars.Length)
                        {
                            i++;
                        }
                        else
                        {
                            vars[i++] = element1;
                            varsParams[i] = element2;
                        }
                    }
                }
              //  MessageBox.Show("var created", "DING DING DING!!!");
            }
            catch
            {
             //   MessageBox.Show("DIDNT LIKE SOMETHING ", "ERROR!!");
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
                    Check(Currentline);
                    display.Refresh();
                   
                }
            }
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            openFile1.DefaultExt = "*.txt";
            openFile1.Filter = "TXT Files|*.txt";
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile1.FileName.Length > 0)
            {
             ControlePanel.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
            }
            openFile1.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemoryStream userInput = new MemoryStream(Encoding.UTF8.GetBytes(ControlePanel.Text));
           
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "txt";
            save.Filter ="Text files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = save.ShowDialog();
            Stream fileStream;
           
            if (result == DialogResult.OK)
            {                
                
                fileStream = save.OpenFile();
                userInput.Position = 0;
                userInput.WriteTo(fileStream);
                fileStream.Close();
                userInput.Close();
                
            }
            save.Dispose();
        }

    
    }
    
}
