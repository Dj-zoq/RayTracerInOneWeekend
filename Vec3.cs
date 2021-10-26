using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    class Vec3
    {
        private double[] arr = new double[3];

        public double this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value;  }
        }

        public Vec3() { }
        public Vec3(double a, double b, double c)
        {
            arr[0] = a;
            arr[1] = b;
            arr[2] = c;
        }

        public void Print()
        {
            Console.WriteLine($"{arr[0]} {arr[1]} {arr[2]}");
        }   
        public double Length()
        {
            return Math.Sqrt(Math.Pow(arr[0], 2) + Math.Pow(arr[1], 2) + Math.Pow(arr[2], 2));
        }
        public static Vec3 operator -(Vec3 v) => new Vec3(-v[0], -v[1], -v[2]);
        public static Vec3 operator +(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1[0] + v2[0], v1[1] + v2[1], v1[2] + v2[2]);
        }
        public static Vec3 operator -(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1[0] - v2[0], v1[1] - v2[1], v1[2] - v2[2]);
        }
        public static Vec3 operator *(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1[0] * v2[0], v1[1] * v2[1], v1[2] * v2[2]);
        }
        public static Vec3 operator *(Vec3 v, double s)
        {
            return new Vec3(v[0] * s, v[1] *s, v[2] *s);
        }
        public static Vec3 operator *(double s, Vec3 v)
        {
            return v * s;
        }
        public static Vec3 operator /(Vec3 v, double s)
        {
            return (1/s) * v;
        }
        public static double Dot(Vec3 v1, Vec3 v2)
        {
            return v1[0] * v2[0] + v1[1] * v2[1] + v1[2] * v2[2];
        }
        public static Vec3 Cross(Vec3 v1, Vec3 v2)
        {
            double x = v1[1] * v2[2] - v1[2] * v2[1];
            double y = v1[2] * v2[0] - v1[0] * v2[2];
            double z = v1[0] * v2[1] - v1[1] * v2[0];

            return new Vec3(x, y, z);
        }
        public static Vec3 UnitVector(Vec3 v)
        {
            return v / v.Length();
        } 
        
    }
}
