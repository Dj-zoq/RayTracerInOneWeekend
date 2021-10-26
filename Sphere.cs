using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    class Sphere
    {
        public static double HitSphere(Point3 center, double Radius, Ray r)
        {
            Vec3 oc = r.orig - center;
            double a = Math.Pow(r.dir.Length(), 2);
            double half_b =  Vec3.Dot(oc, r.dir);

            double c = Math.Sqrt(oc.Length()) - Radius * Radius;
            double discriminant = half_b * half_b -   a * c;
            if (discriminant < 0)
            {
                return -1.0;
            }
            else
            {
                return (-half_b - Math.Sqrt(discriminant)) /  a;
            }

        }

    }
}
