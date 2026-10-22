using System.Diagnostics;

namespace patterns_design_lab_1.Geometry
{
    internal class Point(double X, double Y) : IPoint
    {
        public double X { get; set; } = X;
        public double Y { get; set; } = Y;

        public IPoint Add(IPoint other)
        {
            return new Point(X + other.X, Y + other.Y);
        }

        public IPoint Multiply(double number)
        {
            return new Point(X * number, Y * number);
        }
    }
}
