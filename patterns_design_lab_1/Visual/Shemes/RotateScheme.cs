using patterns_design_lab_1.Geometry;
using Point = patterns_design_lab_1.Geometry.Point;

namespace patterns_design_lab_1.Visual.Shemes
{
    public class RotateScheme(ICurveVisualizationScheme component, IPoint center, double angle) : ICurveVisualizationScheme
    {
        readonly ICurveVisualizationScheme component = component;
        readonly IPoint center = center;
        double cos = 1, sin = 0;
        public double Angle
        {
            get => angle;
            set
            {
                angle = value;
                double radian_angle = Angle * Math.PI / 180;
                cos = Math.Cos(radian_angle);
                sin = Math.Sin(radian_angle);
            }
        }

        public void DrawEndPoint(IPoint point)
        {
            point = RotatePoint(point);

            component.DrawEndPoint(point);
        }

        public void DrawSegment(IPoint start, IPoint end)
        {
            start = RotatePoint(start);
            end = RotatePoint(end);

            component.DrawSegment(start, end);
        }

        public void DrawStartPoint(IPoint point)
        {
            point = RotatePoint(point);

            component.DrawStartPoint(point);
        }

        Point RotatePoint(IPoint point)
        {
            double x = point.X - center.X;
            double y = point.Y - center.Y;

            double rotated_x = x * cos - y * sin;
            double rotated_y = x * sin + y * cos;

            return new Point(rotated_x + center.X, rotated_y + center.Y);
        }
    }
}
