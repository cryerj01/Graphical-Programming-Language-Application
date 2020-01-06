using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;




namespace GPLA
{

    public partial class Form1 : Form
    {

        private int x = 0, y = 0;//default draw position
        private int loopmax;//used in loop
        private int loopstart;//used in loop
        private int loopend; //used in loop
        private int loopcount;//used in loop
        private int errorcount = 0;

        private string[] element; //used to see each part of the commandes inputted in the checker
        private string[] vars = new string[50];    //stores the variables names
        private int[] varsParams = new int[50];   //stores the varables numbers in the corrsponding position to vars
        private int[] errorline = new int[50];    // used to show what lines the errors are on

        private bool loopflag = false;//used in loop
        private bool ifResult = false;//used in the if checker
        private bool iffaslse = false;//used to skip the line not used in the if
        private bool check = false;//used in syntax check

        private Color pencol = Color.Black;//universal colour for pen
        private Color brushcol = Color.Cyan;// universal colour for brush
        private Random rnd = new Random();//used to make random number for colour changes and factory shapes

        private Shape shape1; // used in producing factory shapes
        private factory factory = new factory();// 

        public Form1()
        {
            InitializeComponent();
            display.Image = new Bitmap(Size.Width, Size.Height);


        }

        public void excicute(ArrayList Currentline, string[] lines, int linecount)// excicution of the code to display the shapes
        {


            int count = 0;
            int skip = 0;
           

            while (lines.Length >= count)
            {
                Graphics g = Graphics.FromImage(display.Image);
                Pen pen = new Pen(pencol, 2);
                Brush brush = new SolidBrush(brushcol);

                try
                {
                   if(skip != 0)
                    {
                        if (skip == count)
                        {
                            count++;
                            skip = 0;
                        }
                    }
                   
                    element = (String[])Currentline[count];


                    switch (element[0].ToLower())
                    {
                        case "circle":

                            int radius;
                            if (!int.TryParse(element[1], out radius))
                            {

                                radius = varCall((string)element[1]);
                                new Circle(x, y, radius).Draw(g, pen, brush);
                            }
                            else if (int.TryParse(element[1], out radius))
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
                                point1 = varCall(element[1]);
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
                                System.Drawing.Point pointa1 = new System.Drawing.Point(p1, p2);
                                System.Drawing.Point pointb1 = new System.Drawing.Point(p2, p3);
                                System.Drawing.Point pointc1 = new System.Drawing.Point(p3, p1);

                                System.Drawing.Point[] pnt1 = { pointa1, pointb1, pointc1 };
                                new Triangle(pnt1).Draw(g, pen, brush);
                            }
                            else
                            {
                                int.TryParse(element[1], out p1);
                                int.TryParse(element[2], out p2);
                                int.TryParse(element[3], out p3);
                                System.Drawing.Point pointa1 = new System.Drawing.Point(p1, p2);
                                System.Drawing.Point pointb1 = new System.Drawing.Point(p2, p3);
                                System.Drawing.Point pointc1 = new System.Drawing.Point(p3, p1);

                                System.Drawing.Point[] pnt1 = { pointa1, pointb1, pointc1 };
                                new Triangle(pnt1).Draw(g, pen, brush);
                            }
                            break;
                        case "clear":
                            g.Clear(Color.Transparent);
                            g.Dispose();
                            break;
                        case "movex":
                            if (int.TryParse(element[1], out x))
                            {
                                int.TryParse(element[1], out x);
                            }
                            else
                            {
                                x = varCall(element[1]);
                            }
                            break;
                        case "movey":
                            if (int.TryParse(element[1], out y))
                            {
                                int.TryParse(element[1], out y);
                            }
                            else
                            {
                                y = varCall(element[1]);
                            }
                            break;
                        case "moveto":

                            if (int.TryParse(element[1], out x) && int.TryParse(element[2], out y))
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
                            loopflag = true;
                            loopmax = 0;
                            loopcount = 0;
                            loopstart = count;

                            if (int.TryParse(element[1], out loopmax))
                            {
                                int.TryParse(element[1], out loopmax);
                            }
                            else
                            {
                                loopmax = varCall(element[1]);
                            }

                            if (lines[count] == "end" && loopcount != loopmax)
                            {
                                count = loopend;
                                loopflag = false;
                                break;
                            }
                            else if (lines[count] == "end" && loopcount != loopmax)
                            {
                                loopcount++;
                                loopend = count++;
                                count = loopstart;
                                count++;
                                break;

                            }
                            else
                            {
                                loopcount++;
                                break;
                            }
                        case "end":
                            if (loopcount == loopmax || loopcount > loopmax)
                            {

                            }
                            else
                            {
                                count = loopstart;
                            }


                            break;
                        case "factory":
                            // factory Shape = new factory;

                            x = rnd.Next(display.Width);
                            y = rnd.Next(display.Height);


                            brushcol = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                            pencol = Color.Black;

                            shape1 = factory.getShape(element[1]);
                            if (element[1].ToLower().Trim() == "circle")
                            {
                                radius = rnd.Next(Size.Width / 4);
                                shape1.set(x, y, radius);
                            }
                            else if (element[1].ToLower().Trim() == "rectangle")
                            {
                                width = rnd.Next(display.Width);
                                height = rnd.Next(display.Height);
                                shape1.set(x, y, width, height);
                            }
                            else if (element[1].ToLower().Trim() == "triangle")
                            {
                                p1 = rnd.Next(display.Width);
                                p2 = rnd.Next(display.Width);
                                p3 = rnd.Next(display.Width);
                                System.Drawing.Point pointa = new System.Drawing.Point(p1, p2);
                                System.Drawing.Point pointb = new System.Drawing.Point(p2, p3);
                                System.Drawing.Point pointc = new System.Drawing.Point(p3, p1);
                                System.Drawing.Point[] pnt = { pointa, pointb, pointc };
                                shape1.setTriangle(x, y, pnt);
                            }
                            shape1.Draw(g, pen, brush);
                            display.Refresh();
                            break;
                        case "if":
                            int left;
                            int right;
                            string condition;
                            if (element.Length > 4)
                            {
                                MessageBox.Show("need more input", "Error");
                            }
                            else
                            {
                                if (!int.TryParse(element[1], out left))
                                {
                                    left = varCall(element[1]);
                                }
                                else
                                {
                                    int.TryParse(element[1], out left);
                                }

                                if (!int.TryParse(element[3], out right))
                                {
                                    right = varCall(element[3]);
                                }
                                else
                                {
                                    int.TryParse(element[3], out right);
                                }
                                condition = element[2];
                                ifcheck(left, condition, right);
                                if (ifResult == true)
                                {

                                    skip = count;
                                    skip++;
                                    skip++;

                                   
                                  //  MessageBox.Show("If statment is true", "Whoop!!");
                                    break;
                                }
                                else
                                {
                                    //   MessageBox.Show("If statment is not true", "Error");
                                    count++;
                                    
                                }




                            }

                            break;
                        case "endif":
                            skip = 0;
                            iffaslse = false;
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
                                                MessageBox.Show(element[0] + "is all ready set to " + element[1], "whoop");
                                            }
                                            else
                                            {
                                                int.TryParse(element[1], out varsParams[i]);
                                                MessageBox.Show(element[0] + " now set to " + element[1], "whoop");
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
                    if (loopflag == true)
                    {
                        loopcount++;
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

        private bool ifcheck(int left, string condition, int right) // used to check if sattment 
        {
            switch (condition)
            {

                case "=":
                    if (left == right)
                    {
                        ifResult = true;
                    }
                    else
                    {
                        ifResult = false;
                    }
                    break;
                case ">":
                    if (left > right)
                    {
                        ifResult = true;
                    }
                    else
                    {
                        ifResult = false;
                    }

                    break;
                case "<":
                    if (left < right)
                    {
                        ifResult = true;
                    }
                    else
                    {
                        ifResult = false;
                    }

                    break;
                case "!":
                    if (left != right)
                    {
                        ifResult = true;
                    }
                    else
                    {
                        ifResult = false;
                    }

                    break;
               
                default:
                    MessageBox.Show("condition is not correct please check", "error");

                    break;

            }

            return ifResult;
        }


        private void VarCheck(string element1, string element2) //used to check if the var is set if not to set it or re set it 
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

        private int varCall(string variable) //used to call the valuse of the assined varable if it is there
        {
            int i = 0;
            int number = -1;
            while (49 >= i)
            {
                if (vars[i] == variable)
                {

                    number = varsParams[i];
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

        private void Commandline_KeyDown(object sender, KeyEventArgs e) //used to run the program
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
                    int L = 0;
                    Array.Clear(vars, 0, vars.Length);//used to cleare the vars array befreo exicution
                    Array.Clear(varsParams, 0, varsParams.Length);
                    string errors = string.Join(", ", errorline.Where(x => x != 0));
                    
                    
                    if (check == false)
                    { 
                       
                        MessageBox.Show("Errors on lines :" + errors + ".", "error");
                    }
                    else
                    {

                        excicute(Currentline, lines, length);
                    }


                }
            }


        }

        public void Check(ArrayList currentline, string[] lines, int length)// checks the syntax of the user input
        {
            int count = 0;
            int errors = 0;
            errorcount = 0;
            check = true;
            int k = 0;
            int linenumber = 0;

            
            while (lines.Length >= count)
            {

                errors = errorcount;
                try
                {
                    element = (String[])currentline[count];


                    switch (element[0].ToLower())
                    {
                        case "circle":
                            if (element.Length != 2)
                            {
                                errorcount++;
                            }

                            break;
                        case "rectangle":
                            if (element.Length != 3)
                            {
                                errorcount++;
                            }

                            break;
                        case "Square":
                            if (element.Length != 3  )
                            {
                                errorcount++;
                            }
                            break;
                        case "line":
                            if (element.Length != 3  )
                            {
                                errorcount++;
                            }

                            break;
                        case "pencolor":
                            if (element.Length != 2  )
                            {
                                errorcount++;
                            }
                            break;
                        case "brushcolor":
                            if (element.Length != 2  )
                            {
                                errorcount++;
                            }
                            break;
                        case "triangle":
                            if (element.Length != 4  )
                            {
                                errorcount++;
                            }

                            break;
                        case "clear":


                            break;
                        case "movex":
                            if (element.Length != 2  )
                            {
                                errorcount++;
                            }

                            break;
                        case "movey":
                            if (element.Length != 2  )
                            {
                                errorcount++;
                            }

                            break;
                        case "moveto":
                            if (element.Length != 3  )
                            {
                                errorcount++;
                            }


                            break;

                        case "var":

                            if (element.Length != 3 )
                            {
                                errorcount++;
                            }
                            else
                            {
                                VarCheck(element[1], element[2]);
                            }

                            break;
                        case "loop":
                            if (element.Length != 2  )
                            {
                                errorcount++;
                            }
                            break;
                        case "end":
                            if (element.Length != 1)
                            {
                                errorcount++;
                            }
                            break;
                        case "factory":
                            if (element.Length != 2 )
                            {
                                errorcount++;
                            }

                            break;
                        case "if":
                            if (element.Length != 4)
                            {
                                errorcount++;
                            }                         

                            break;
                        case "endif":
                            if (element.Length != 1)
                            {
                                errorcount++;
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
                                                MessageBox.Show(element[0] + "is all ready set to " + element[1], "whoop");
                                            }
                                            else
                                            {
                                                int.TryParse(element[1], out varsParams[i]);
                                                MessageBox.Show(element[0] + " now set to " + element[1], "whoop");
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
                                    errorcount++;
                                }
                            }
                            break;


                    }
                    if (errors != errorcount)
                    {
                        linenumber = count;
                        linenumber++;
                        errorline[k] = linenumber;
                        k++;
                        errors++;


                    }
                }
                catch
                {
                 
                }
                count++;
                if (errorcount != 0)
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
             }

        }

        private void button1_Click(object sender, EventArgs e) //load file to richtextbox
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

        private void button2_Click(object sender, EventArgs e) //save what is in the richtextbox
        {
            MemoryStream userInput = new MemoryStream(Encoding.UTF8.GetBytes(ControlePanel.Text));

            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "txt";
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
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
