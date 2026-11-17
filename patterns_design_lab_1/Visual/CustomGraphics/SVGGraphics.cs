using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;

namespace patterns_design_lab_1.Visual.CustomGraphics
{
    internal class SVGGraphics(int width, int height) : IGraphics
    {
        readonly int width = width;
        readonly int height = height;
        readonly List<string> elements = [];

        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
        {
            elements.Add($"""
                <line x1="{F(x1)}" y1="{F(y1)}" x2="{F(x2)}" y2="{F(y2)}" 
                {Stroke(pen)} />
                """);
        }

        public void DrawRectangle(Pen pen, float x, float y, float width, float height)
        {
            elements.Add($"""
                <rect x="{F(x)}" y="{F(y)}" width="{F(width)}" height="{F(height)}" rx="0" ry="0" 
                {Stroke(pen)} />
                """);
        }

        public void DrawEllipse(Pen pen, float x, float y, float width, float height)
        {
            elements.Add($"""
                <ellipse cx="{F(x + width / 2)}" cy="{F(y + height / 2)}" rx="{F(width / 2)}" ry="{F(height / 2)}" 
                {Stroke(pen)} />
                """);
        }

        public void FillPolygon(Brush brush, PointF[] points)
        {
            if (brush is not SolidBrush solid_brush)
            {
                return;
            }

            string list = string.Join(" ", points.Select(p => $"{F(p.X)},{F(p.Y)}"));
            elements.Add($"""
                <polygon points="{list}" 
                fill="{ToHex(solid_brush.Color)}"
                />
                """);
        }

        public void DrawString(string? s, Font font, Brush brush, float x, float y)
        {
            throw new NotImplementedException();
        }

        static string Stroke(Pen pen)
        {
            string stroke_dasharray = "";
            if (pen.DashStyle != DashStyle.Solid)
            {
                stroke_dasharray = $"""
                    stroke-dasharray="{string.Join(" ", pen.DashPattern.Select(p => F(p * pen.Width)))}" 
                    """;
            }

            string pen_string = $"""
                stroke="{ToHex(pen.Color)}" 
                stroke-width="{F(pen.Width)}" 
                {stroke_dasharray}
                """;

            return pen_string;
        }

        public void Save(string file_path)
        {
            var file = new StringBuilder();

            _ = file.AppendLine("""<?xml version="1.0" encoding="UTF-8"?>""");
            _ = file.AppendLine($"""<svg xmlns="http://www.w3.org/2000/svg" width="{width}" height="{height}" viewBox="0 0 {width} {height}\">""");
            _ = file.AppendLine($"""{"\t"}<rect width="{width}" height="{height}" fill="white" />""");


            foreach (string element in elements)
            {
                _ = file.AppendLine("\t" + element);
            }

            _ = file.AppendLine("</svg>");

            File.WriteAllText(file_path, file.ToString(), Encoding.UTF8);
        }

        static string F(double value) => value.ToString("0.###", CultureInfo.InvariantCulture);

        static string ToHex(Color color) => $"#{color.ToArgb() & 0xFFFFFF:X6}";
    }
}
