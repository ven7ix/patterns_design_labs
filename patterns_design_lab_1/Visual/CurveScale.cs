using patterns_design_lab_1.Geometry;

namespace patterns_design_lab_1.Visual
{
    internal class CurveScale(ICurve component, double scale) : ICurve
    {
        readonly ICurve component = component;
        readonly double scale = scale;

        public void GetPoint(double t, out IPoint point)
        {
            component.GetPoint(t, out point);

            double x = point.X / scale;
            double y = point.Y / scale;

            point = new Geometry.Point(x, y);
        }
    }
}
