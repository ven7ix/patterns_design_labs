using patterns_design_lab_1.Geometry;

namespace patterns_design_lab_1.Visual.Schemes
{
    internal class LabelScheme(ICurveVisualizationScheme component, string label, IGraphics graphics) : ICurveVisualizationScheme
    {
        readonly ICurveVisualizationScheme component = component;
        readonly string label = label;
        readonly IGraphics graphics = graphics;

        public void DrawEndPoint(IPoint point)
        {
            component.DrawEndPoint(point);
        }

        public void DrawSegment(IPoint start, IPoint end)
        {
            component.DrawSegment(start, end);
        }

        public void DrawStartPoint(IPoint point)
        {
            component.DrawStartPoint(point);

            using var font = new Font("Arial", 16);
            using var brush = new SolidBrush(Color.Black);
            graphics.DrawString(label, font, brush, (float)point.X + 10, (float)point.Y + 10);
        }
    }
}
