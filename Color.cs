using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    class Color : Vec3
    {
        public Color(double r, double g, double b) : base(r,g,b) { }

        public String WriteColor()
        {
            var ir = (int)(this[0] * 255.099);
            var ig = (int)(this[1] * 255.099);
            var ib = (int)(this[2] * 255.099);

            return $"{ir} {ig} {ib}\n";  
        }

        public static Color RayColor(Ray r)
        {
            var t = Sphere.HitSphere(new Point3(0, 0, -1), 0.5, r);
            if (t > 0)
            {
                var N = Vec3.UnitVector(r.At(t) - new Vec3(0, 0, -1));
                var result = 0.5 * new Color(N[0] + 1, N[1] + 1, N[2] + 1);
                return new Color(result[0], result[1], result[2]);
            }

            Vec3 UnitDirection = Vec3.UnitVector(r.dir);
            t = 0.5 * (UnitDirection[1] + 1.0);
            Vec3 gg = (1.0 - t) * new Color(1.0, 1.0, 1.0) + t * new Color(0.5, 0.7, 1.0);
            return new Color(gg[0], gg[1], gg[2]);
            
        }


    }
}
