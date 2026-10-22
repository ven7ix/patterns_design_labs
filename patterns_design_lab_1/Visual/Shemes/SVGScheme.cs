using System.Globalization;
using System.Text;
using patterns_design_lab_1.Geometry;

namespace patterns_design_lab_1.Visual.Shemes
{
    internal class SVGScheme(int width, int height, Color color, string segement_style) : ICurveVisualizationScheme
    {
        readonly int width = width;
        readonly int height = height;
        readonly Color color = color;
        readonly string segement_style = segement_style;

        readonly List<string> elements = [];

        public void DrawSegment(IPoint start, IPoint end)
        {
            elements.Add($"""<line x1="{Format(start.X)}" y1="{Format(start.Y)}" x2="{Format(end.X)}" y2="{Format(end.Y)}" stroke="{ToHex(color)}" {segement_style} />""");
        }

        public void DrawStartPoint(IPoint point)
        {
            elements.Add($"""<circle cx="{Format(point.X)}" cy="{Format(point.Y)}" r="5" fill="{ToHex(color)}" />""");
        }

        public void DrawEndPoint(IPoint point)
        {
            elements.Add($"""<circle cx="{Format(point.X)}" cy="{Format(point.Y)}" r="5" fill="{ToHex(color)}" />""");
        }

        static string ToHex(Color color)
        {
            return $"#{(color.ToArgb() & 0xFFFFFF):X6}";
        }

        static string Format(double value)
        {
            return value.ToString("0.###", CultureInfo.InvariantCulture);
        }

        public void Save(string file_path)
        {
            var file = new StringBuilder();

            _ = file.AppendLine("""<?xml version="1.0" encoding="UTF-8"?>""");
            _ = file.AppendLine($"""<svg xmlns="http://www.w3.org/2000/svg" width="{width}" height="{height}" viewBox="0 0 {width} {height}\">""");

            foreach(string element in elements)
            {
                _ = file.AppendLine("\t" + element);
            }

            _ = file.AppendLine("</svg>");

            File.WriteAllText(file_path, file.ToString(), Encoding.UTF8);
        }
    }
}
