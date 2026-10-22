using patterns_design_lab_1.Geometry;

namespace patterns_design_lab_1.Visual
{
    public class CurveRotate(ICurve component, double angle, IPoint center) : ICurve
    {
        readonly ICurve component = component;
        readonly double angle = angle;
        readonly IPoint center = center;

        public void GetPoint(double t, out IPoint point)
        {
            component.GetPoint(t, out point);

            double radian_angle = angle * Math.PI / 180;

            double cos = Math.Cos(radian_angle);
            double sin = Math.Sin(radian_angle);

            double x = point.X - center.X;
            double y = point.Y - center.Y;

            double rotated_x = x * cos - y * sin;
            double rotated_y = x * sin + y * cos;

            point = new Geometry.Point(rotated_x + center.X, rotated_y + center.Y);
        }
    }
}
