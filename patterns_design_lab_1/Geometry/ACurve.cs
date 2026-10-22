namespace patterns_design_lab_1.Geometry
{
    internal abstract class ACurve(IPoint a, IPoint b) : ICurve
    {
        protected IPoint a = a;
        protected IPoint b = b;

        public abstract void GetPoint(double t, out IPoint p);
    }
}
