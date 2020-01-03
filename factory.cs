using System;

public class factory
{
	public getShape(String shapeType)
	{
            shapeType.Trim().ToLower();
            switch (shapeType)
            {         
                            
                                case "circle":
                              return new circle();
                                    break;
                                case "rectangle":
                             return new rectangle();
                                    break;
                                case "triangle":
                              return new triangle();
                                    break;
                            }
        }
	}
}
