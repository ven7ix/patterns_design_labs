using patterns_design_lab_1.Geometry;

namespace patterns_design_lab_1.Visual.Shemes
{
    internal class DashedScheme(Graphics graphics) : ICurveVisualizationScheme
    {
        readonly Graphics graphics = graphics;

        public void DrawSegment(IPoint start, IPoint end)
        {
            using var black_pen = new Pen(Color.Black, 2)
            { 
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };

            graphics.DrawLine(black_pen, (float)start.X, (float)start.Y, (float)end.X, (float)end.Y);
        }

        public void DrawStartPoint(IPoint point)
        {
            using var black_pen = new Pen(Color.Black, 2);

            graphics.DrawRectangle(black_pen, (float)point.X, (float)point.Y, 10, 10);
        }

        public void DrawEndPoint(IPoint point)
        {
            using var black_pen = new Pen(Color.Black, 2);

            graphics.DrawRectangle(black_pen, (float)point.X, (float)point.Y, 10, 10);
        }
    }
}
