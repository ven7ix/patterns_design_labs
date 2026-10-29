using patterns_design_lab_1.Geometry;
using patterns_design_lab_1.UserInterface;

namespace patterns_design_lab_1.Visual.Shemes
{
    internal class DashedScheme(IGetGraphics graphics, Pen pen) : ICurveVisualizationScheme
    {
        readonly IGetGraphics graphics = graphics;
        readonly Pen pen = pen;

        public void DrawSegment(IPoint start, IPoint end)
        {
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            graphics.Get().DrawLine(pen, (float)start.X, (float)start.Y, (float)end.X, (float)end.Y);
        }

        public void DrawStartPoint(IPoint point)
        {
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            graphics.Get().DrawRectangle(pen, (float)point.X, (float)point.Y, 10, 10);
        }

        public void DrawEndPoint(IPoint point)
        {
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            graphics.Get().DrawRectangle(pen, (float)point.X, (float)point.Y, 10, 10);
        }
    }
}
