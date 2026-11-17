using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_design_lab_1.Geometry
{
    internal class MoveTo(ICurve component, IPoint target) : ICurve
    {
        readonly ICurve component = component;
        readonly IPoint target = target;

        public void GetPoint(double t, out IPoint point)
        {
            component.GetPoint(0, out IPoint origin);
            component.GetPoint(t, out IPoint p);

            point = p.Add(target.Add(origin.Multiply(-1)));
        }
    }
}
