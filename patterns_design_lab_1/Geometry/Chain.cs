namespace patterns_design_lab_1.Geometry
{
    internal class Chain(ICurve first, ICurve second) : ICurve
    {
        readonly ICurve first = first;
        readonly ICurve second = second;

        public void GetPoint(double t, out IPoint point)
        {
            if (t <= 0.5)
            {
                first.GetPoint(2 * t, out point);
            }
            else
            {
                second.GetPoint(2 * t - 1, out point);
            }
        }
    }
}
