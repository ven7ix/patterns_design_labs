using patterns_design_lab_1.Geometry;

namespace patterns_design_lab_1.Visual
{
    public class VisualCurve(ICurve curve, int point_count) : ICurve, IDrawable
    {
        readonly ICurve curve = curve;
        public readonly int point_count = point_count;

        public virtual void Draw(ICurveVisualizationScheme context)
        {
            List<IPoint> points = CalculatePoints();

            for (int i = 0; i < point_count; i++)
            {
                context.DrawSegment(points[i], points[i + 1]);
            }

            context.DrawStartPoint(points[0]);
            context.DrawEndPoint(points[point_count]);
        }

        protected virtual List<IPoint> CalculatePoints()
        {
            var points = new List<IPoint>(point_count);

            for (int i = 0; i <= point_count; i++)
            {
                double t = (double)i / point_count;
                GetPoint(t, out IPoint current_point);

                points.Add(current_point);
            }

            return points;
        }

        public void GetPoint(double t, out IPoint point)
        {
            curve.GetPoint(t, out point);
        }
    }
}
