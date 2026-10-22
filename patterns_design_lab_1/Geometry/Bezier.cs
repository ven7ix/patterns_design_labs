namespace patterns_design_lab_1.Geometry
{
    internal class Bezier(IPoint a, IPoint b, IPoint c, IPoint d) : ACurve(a, b)
    {
        protected IPoint c = c;
        protected IPoint d = d;

        public override void GetPoint(double t, out IPoint point)
        {
            point = a.Multiply(Math.Pow(1 - t, 3))
                .Add(c.Multiply(3 * t * Math.Pow(1 - t, 2)))
                .Add(d.Multiply(3 * Math.Pow(t, 2) * (1 - t)))
                .Add(b.Multiply(Math.Pow(t, 3)));
        }
    }
}
