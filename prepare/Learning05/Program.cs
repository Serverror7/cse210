using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");
        Square newSquare = new Square();
        newSquare.SetSide(4.0);
        newSquare.SetColor("Red");
        Rectangle newRectangle = new Rectangle();
        newRectangle.SetSize(4.0,5.0);
        newRectangle.SetColor("Blue");
        Circle newCircle = new Circle();
        newCircle.SetRadius(4.0);
        newCircle.SetColor("Green");
        List<Shape> shapes = [newSquare, newRectangle, newCircle];
        for (int i = 0; i < 3;  i++)
        {
            double area = shapes[i].GetArea();
            string color = shapes[i].GetColor();
            Console.WriteLine($"The area of the shape is {area}, and it's color is {color}");
        }
        
    }
}
