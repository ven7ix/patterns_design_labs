using patterns_design_lab_1.Geometry;
using Point = patterns_design_lab_1.Geometry.Point;

namespace patterns_design_lab_1.Visual.Shemes
{
    public class ScaleScheme(ICurveVisualizationScheme component, IPoint center, double scale) : ICurveVisualizationScheme
    {
        protected readonly ICurveVisualizationScheme component = component;
        readonly IPoint center = center;
        public double Scale { get; set; } = scale;

        public void DrawEndPoint(IPoint point)
        {
            point = ScalePoint(point);

            component.DrawEndPoint(point);
        }

        public void DrawSegment(IPoint start, IPoint end)
        {
            start = ScalePoint(start);
            end = ScalePoint(end);

            component.DrawSegment(start, end);
        }

        public void DrawStartPoint(IPoint point)
        {
            point = ScalePoint(point);

            component.DrawStartPoint(point);
        }

        Point ScalePoint(IPoint point)
        {
            double x = center.X + (point.X - center.X) * Scale;
            double y = center.Y + (point.Y - center.Y) * Scale;

            return new Point(x, y);
        }
    }
}
