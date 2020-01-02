using Microsoft.Build.Tasks;
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
        private  string[] vars = new string[50];
        private int[] varsParams = new int[50];
        private int loopcount;
        private bool loopflag= false;
        private Color pencol = Color.Black;
        private Color brushcol = Color.Cyan;
        private Random rnd = new Random();


        public Form1()
        {
            InitializeComponent();
            display.Image = new Bitmap(Size.Width, Size.Height);
           

        }

        private void Check( ArrayList Currentline, string[] lines,int linecount)
        {

           
                int count = 0;
               
                while (lines.Length >= count)
                {
                Graphics g = Graphics.FromImage(display.Image);
                Pen pen = new Pen(pencol, 2);
                Brush brush = new SolidBrush(brushcol);

                try
                    {
                        string[] element = (String[])Currentline[count];
                    

                        switch (element[0].ToLower())
                        {
                            case "circle":

                                int radius;
                                if (!int.TryParse(element[1], out radius))
                                {
                                   
                                 radius = varCall((string)element[1]);
                                    new Circle(x, y, radius).Draw(g, pen, brush);
                                }
                                else if(int.TryParse(element[1], out radius))
                                {
                                    int.TryParse(element[1], out radius);
                                new Circle(x, y, radius).Draw(g, pen, brush);
                                }
                            else
                            {
                                MessageBox.Show("enter a radius or use a variable", "error");
                            }
                                break;
                            case "rectangle":

                                int width;

                                int height;
                                if (!int.TryParse(element[1], out width) || !int.TryParse(element[2], out height))
                                {
                                width = varCall(element[1]);
                                height = varCall(element[2]);
                                    new Rectangle(x, y, width, height).Draw(g, pen, brush);

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
                                side = varCall(element[1]);
                                    new Square(x, y, side).Draw(g, pen, brush);
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
                              point1  = varCall(element[1]);
                              point2 = varCall(element[2]);
                                g.DrawLine(pen, x, y, point1, point1);

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
                                if (element[1] != "rand")
                                {
                                    pencol = Color.FromName(element[1]);
                                }
                                else
                                {
                                    pencol = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                                }
                                }
                                catch
                                {
                                    pencol = Color.Black;
                                }
                                break;
                            case "brushcolor":
                                try
                                {
                                if (element[1] != "rand")
                                {
                                    brushcol = Color.FromName(element[1]);
                                }
                                else
                                {
                                   brushcol = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                                }
                                     
                                }
                                catch
                                {   
                                    brushcol = Color.Black;
                                }
                                break;
                            case "triangle":
                                int p1, p2, p3;

                                if (!int.TryParse(element[1], out p1) || !int.TryParse(element[2], out p2) || !int.TryParse(element[3], out p3))
                                {
                                p1 = varCall(element[1]);
                                p2 = varCall(element[2]);
                                p3 = varCall(element[3]);
                                System.Drawing.Point pointa = new System.Drawing.Point(p1, p2);
                                System.Drawing.Point pointb = new System.Drawing.Point(p2, p3);
                                System.Drawing.Point pointc = new System.Drawing.Point(p3, p1);

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
                            if (int.TryParse(element[1], out x))
                            {
                                int.TryParse(element[1], out x);
                            }
                            else
                            {
                                x = varCall(element[1]);
                            }
                                break;
                            case "sety":
                            if (int.TryParse(element[1], out y))
                            {
                                int.TryParse(element[1], out y);
                            }
                            else
                            {
                                y = varCall(element[1]);
                            }
                            break;
                            case "setxy":

                            if (int.TryParse(element[1], out x)&& int.TryParse(element[2], out y))
                            {
                                int.TryParse(element[1], out x);
                                int.TryParse(element[2], out y);
                            }
                            else
                            {
                                x = varCall(element[1]);
                                y = varCall(element[2]);
                            }

                                break;

                            case "var":
                                VarCheck(element[1], element[2]);
                                break;
                        case "loop":
                           
                                int loopmax = 0;
                                    loopcount=0;
                                int next = count;
                                if(int.TryParse(element[1], out loopmax))
                            {
                                int.TryParse(element[1], out loopmax);
                            }
                            else
                            {
                                loopmax = varCall(element[1]);
                            }

                                next++;
                                int k = 0;
                                string[] looplines = new string[50];
                                string lineloopread = null;
                                ArrayList loopedcommands = new ArrayList();
                               
                                    while (next != Currentline.Count)
                                    {

                                        if (lines[next] == "end")
                                        {
                                        loopcount++;
                                        lopper(loopedcommands, looplines, loopmax);
                                       
                                        }
                                        else
                                        {
                                            lineloopread = Currentline[next].ToString();
                                            looplines[k] = lineloopread;
                                            loopedcommands.Add(Currentline[next]);
                                            next++;
                                            k++;
                                        }
                                        
                                    }
                                
                                break;
                            case "end":

                                break;
                        case "factory":

                            x = rnd.Next(display.Width);
                            y = rnd.Next(display.Height);
                           
                            width = rnd.Next(display.Width);
                            height = rnd.Next(display.Height);

                            brushcol =Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                            pencol = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                            switch (element[1].ToLower().Trim())
                            {
                                case "circle":
                                    radius = rnd.Next(display.Width / 4);
                                    new Circle(x, y, radius).Draw(g, pen, brush);
                                    break;
                                case "rectangle":
                                    width = rnd.Next(display.Width);
                                    height = rnd.Next(display.Height);
                                    new Rectangle(x, y, width, height).Draw(g, pen, brush);
                                    break;
                                case "triangle":
                                    p1 = rnd.Next(display.Width);
                                    p2 = rnd.Next(display.Width);
                                    p3 = rnd.Next(display.Width);

                                    System.Drawing.Point pointa = new System.Drawing.Point(p1, p2);
                                    System.Drawing.Point pointb = new System.Drawing.Point(p2, p3);
                                    System.Drawing.Point pointc = new System.Drawing.Point(p3, p1);

                                    System.Drawing.Point[] pnt = { pointa, pointb, pointc };
                                    new Triangle(pnt).Draw(g, pen, brush);

                                    break;
                            }
                            break;
                            default: 
                                if (element[0].Trim() == null)
                                {

                                }
                                else 
                                {
                                    int i = 0;
                                    if (vars[0] != null)
                                    {
                                        while (49 >= i)
                                        {
                                            if (vars[i] == element[0])
                                            {
                                              //  MessageBox.Show(element[0] + " called", "whoop");
                                                if (!int.TryParse(element[1], out varsParams[i]))
                                                {
                                                    MessageBox.Show(element[0] + "is all ready set to " +element[1], "whoop");
                                                }
                                                else
                                                {
                                                    int.TryParse(element[1], out varsParams[i]);
                                                    MessageBox.Show(element[0] + " now set to " +element[1], "whoop");
                                                }
                                                 i = 50;
                                            }
                                            else if (i != vars.Length)
                                            {
                                                i++;
                                            }
                                          
                                        }
                                                                            }
                                    else
                                    {
                                    MessageBox.Show(element[0] + " not a Command", "MEessgae");
                                    }
                                }
                                break;
                            
                        }
                          display.Refresh();

                   }
                    catch
                   {
                  
                    }
                    pen.Dispose();
                    brush.Dispose();
                    count++;

                }
               
             
                
        }

        private void lopper(ArrayList loopedcommands, string[] looplines ,int loopmax)
        {
            string[] looplengh = new string[100];
            loopcount = 0;
            if (loopcount < loopmax)
            {                 
                while (loopcount < loopmax)
                {
                    int lengh = looplines.Length;
                    Check(loopedcommands, looplines, lengh);
                    loopcount++;
                    label1.Text = "loop count" + loopcount;
                    display.Refresh();
                }             
                                
            }            
        }

        private void VarCheck(string element1, string element2)
        {
            int i = 0;
            try
            {
                if (vars[0] == null && varsParams[0] == 0)  // arrays max is [49];
                {
                    vars[0] = element1;//name 
                    int.TryParse(element2, out varsParams[0]);//value
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
                                i++;
                            }
                        }
                        else if (i >= vars.Length)
                        {
                            i++;
                        }
                        else
                        {
                            vars[i++] = element1;
                            int.TryParse(element2, out varsParams[i]);
                            
                        }
                    }
                }
            
            }
            catch
            {
           
            }
            
        }

        private int  varCall(string variable)
        {
            int i = 0;
            int number = -1;
            while (49 >= i)
            {
                if (vars[i] == variable)
                {

                number =   varsParams[i] ;
                i = 50;
                }
                else
                {
                    i++;
                }
              
            }
            if (number == 0)
            {
                MessageBox.Show("not a variable", "error");
            }
            return number;

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
                    int length = lines.Length;
                    Check(Currentline, lines, length);
                  
                   
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
