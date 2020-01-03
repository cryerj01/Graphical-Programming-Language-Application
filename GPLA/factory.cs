using GPLA;
using System;

 class factory
{
    public Shape getShape(String shapeType)
    {
        shapeType = shapeType.ToLower().Trim(); //yoi could argue that you want a specific word string to create an object but I'm allowing any case combination


        if (shapeType.Equals("circle"))
        {
            return new Circle();

        }
        else if (shapeType.Equals("rectangle"))
        {
            return new Rectangle();

        }
        else if (shapeType.Equals("triangle"))
        {
           return new Triangle();
        }
        else { 
            //if we get here then what has been passed in is inkown so throw an appropriate exception
            System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapeType + " does not exist");
            throw argEx;
        }


    }
}
