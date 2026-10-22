using patterns_design_lab_1.Geometry;

namespace patterns_design_lab_1.Visual
{
    public interface ICurveVisualizationScheme
    {
        void DrawSegment(IPoint start, IPoint end);
        void DrawStartPoint(IPoint point);
        void DrawEndPoint(IPoint point);
    }
}
