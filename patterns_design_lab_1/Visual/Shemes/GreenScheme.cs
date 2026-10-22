using patterns_design_lab_1.Geometry;

namespace patterns_design_lab_1.Visual.Shemes
{
    internal class GreenScheme(Graphics graphics) : ICurveVisualizationScheme
    {
        readonly Graphics graphics = graphics;

        public void DrawSegment(IPoint start, IPoint end)
        {
            using Pen green_pen = new(Color.Green, 2);

            graphics.DrawLine(green_pen, (float)start.X, (float)start.Y, (float)end.X, (float)end.Y);
        }

        public void DrawStartPoint(IPoint point)
        {
            using Pen green_pen = new(Color.Green, 2);

            graphics.DrawEllipse(green_pen, (float)point.X, (float)point.Y, 10, 10);
        }

        public void DrawEndPoint(IPoint point)
        {
            using SolidBrush green_brush = new(Color.Green);

            graphics.FillPolygon(green_brush, [new PointF((float)point.X, (float)point.Y), new PointF((float)point.X + 10, (float)point.Y), new PointF((float)point.X + 5, (float)point.Y + 10)]);
        }
    }
}
