using patterns_design_lab_1.Geometry;
using Point = patterns_design_lab_1.Geometry.Point;

namespace patterns_design_lab_1.Visual.Shemes
{
    internal class ShadowScheme(ICurveVisualizationScheme component, IPoint offset, Graphics graphics) : ICurveVisualizationScheme
    {
        readonly ICurveVisualizationScheme component = component;
        readonly IPoint offset = offset;
        readonly Graphics graphics = graphics;

        public void DrawEndPoint(IPoint point)
        {
            component.DrawEndPoint(point);
        }

        public void DrawSegment(IPoint start, IPoint end)
        {
            IPoint shadow_start = start.Add(offset);
            IPoint shadow_end = end.Add(offset);

            using Pen gray_pen = new(Color.Gray, 2);
            graphics.DrawLine(gray_pen, (float)shadow_start.X, (float)shadow_start.Y, (float)shadow_end.X, (float)shadow_end.Y);

            component.DrawSegment(start, end);
        }

        public void DrawStartPoint(IPoint point)
        {
            component.DrawStartPoint(point);
        }
    }
}
