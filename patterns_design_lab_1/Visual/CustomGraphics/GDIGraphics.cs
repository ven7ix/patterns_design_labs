namespace patterns_design_lab_1.Visual.CustomGraphics
{
    internal class GDIGraphics(Graphics graphics) : IGraphics
    {
        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2) => graphics.DrawLine(pen, x1, y1, x2, y2);
        public void DrawRectangle(Pen pen, float x, float y, float w, float h) => graphics.DrawRectangle(pen, x, y, w, h);
        public void DrawEllipse(Pen pen, float x, float y, float w, float h) => graphics.DrawEllipse(pen, x, y, w, h);
        public void FillPolygon(Brush brush, PointF[] points) => graphics.FillPolygon(brush, points);
        public void DrawString(string? s, Font font, Brush brush, float x, float y) => graphics.DrawString(s, font, brush, x, y);
    }
}
