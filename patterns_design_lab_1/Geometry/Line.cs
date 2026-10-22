namespace patterns_design_lab_1.Geometry
{
    internal class Line(IPoint a, IPoint b) : ACurve(a, b)
    {
        public override void GetPoint(double t, out IPoint point)
        {
            point = a.Multiply(1 - t).Add(b.Multiply(t));
        }
    }
}
