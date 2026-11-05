using patterns_design_lab_1.Geometry;
using Point = patterns_design_lab_1.Geometry.Point;

namespace patterns_design_lab_1.Visual.Shemes
{
    internal class MoveBySceme(ICurveVisualizationScheme component, IPoint delta) : ICurveVisualizationScheme
    {
        readonly ICurveVisualizationScheme component = component;
        readonly IPoint delta = delta;

        public void DrawEndPoint(IPoint point)
        {
            point = new Point(point.X + delta.X, point.Y + delta.Y);
            component.DrawEndPoint(point);
        }

        public void DrawSegment(IPoint start, IPoint end)
        {
            start = new Point(start.X + delta.X, start.Y + delta.Y);
            end = new Point(end.X + delta.X, end.Y + delta.Y);

            component.DrawSegment(start, end);
        }

        public void DrawStartPoint(IPoint point)
        {
            point = new Point(point.X + delta.X, point.Y + delta.Y);
            component.DrawStartPoint(point);
        }
    }
}
