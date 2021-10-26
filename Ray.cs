using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    class Ray
    {
        public Point3 orig { get; }
        public Vec3 dir { get; }

        public Ray() { }

        public Ray(Point3 p, Vec3 v)
        {
            orig = p;
            dir = v;
        }

        public Point3 At(double t)
        {
            var gg = (Point3)orig + t * dir;
            return new Point3(gg[0], gg[1], gg[2]);     
        }

    }
}
