namespace patterns_design_lab_1.Geometry
{
    public interface ICurve
    {
        void GetPoint(double t, out IPoint point);
    }
}
