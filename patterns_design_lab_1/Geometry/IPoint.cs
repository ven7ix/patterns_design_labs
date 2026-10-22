namespace patterns_design_lab_1.Geometry
{
    public interface IPoint
    {
        double X { get; set; }
        double Y { get; set; }

        IPoint Add(IPoint other);
        IPoint Multiply(double number);
    }
}
