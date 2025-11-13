public class Rectangle : Shape
{
    private double _width;
    private double _length;
    public void SetSize(double width, double length)
    {
        _width = width;
        _length = length;
    }
    public double GetWidth()
    {
        return _width;
    }
    public double GetLength()
    {
        return _length;
    }
    public override double GetArea()
    {
        return _width * _length;
    }
}
