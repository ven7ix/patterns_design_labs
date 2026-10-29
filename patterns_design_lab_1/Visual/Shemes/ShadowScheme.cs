using patterns_design_lab_1.Geometry;

namespace patterns_design_lab_1.Visual.Shemes
{
    internal class ShadowScheme(ICurveVisualizationScheme component, ICurveVisualizationScheme shadow_component, IPoint offset) : ICurveVisualizationScheme
    {
        readonly ICurveVisualizationScheme component = component;
        readonly ICurveVisualizationScheme shadow_component = shadow_component;
        readonly IPoint offset = offset;

        public void DrawEndPoint(IPoint point)
        {
            shadow_component.DrawEndPoint(point.Add(offset));
            component.DrawEndPoint(point);
        }

        public void DrawSegment(IPoint start, IPoint end)
        {
            shadow_component.DrawSegment(start.Add(offset), end.Add(offset));
            component.DrawSegment(start, end);
        }

        public void DrawStartPoint(IPoint point)
        {
            shadow_component.DrawStartPoint(point.Add(offset));
            component.DrawStartPoint(point);
        }
    }
}
