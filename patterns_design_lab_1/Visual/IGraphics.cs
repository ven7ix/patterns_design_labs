namespace patterns_design_lab_1.Visual
{
    public interface IGraphics
    {
        void DrawLine(Pen pen, float x1, float y1, float x2, float y2);
        void DrawRectangle(Pen pen, float x, float y, float width, float height);
        void DrawEllipse(Pen pen, float x, float y, float width, float height);
        void FillPolygon(Brush brush, PointF[] points);
        void DrawString(string? s, Font font, Brush brush, float x, float y);
    }
}
