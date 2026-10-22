namespace patterns_design_lab_1.Geometry
{
    public class CurveRotate(ICurve component, double angle, IPoint center) : ICurve
    {
        protected readonly ICurve component = component;
        readonly IPoint center = center;
        double cos = 1, sin = 0;
        public double Angle
        {
            get => angle;
            set
            {
                angle = value;
                double radian_angle = Angle * Math.PI / 180;
                cos = Math.Cos(radian_angle);
                sin = Math.Sin(radian_angle);
            }
        }

        public void GetPoint(double t, out IPoint point)
        {
            component.GetPoint(t, out point);

            double x = point.X - center.X;
            double y = point.Y - center.Y;

            double rotated_x = x * cos - y * sin;
            double rotated_y = x * sin + y * cos;

            point = new Point(rotated_x + center.X, rotated_y + center.Y);
        }
    }
}
