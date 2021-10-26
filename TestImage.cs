using System;
using System.Collections.Generic;
using System.IO;

namespace RayTracer
{
    class TestImage
    {
        public static void RunFirst()
        {
            string path = $@"..\..\..\TestImages\FirstTest2.ppm";
            const int ImageWidth = 256;
            const int ImageHeight = 256;

            using (var file = new StreamWriter(path , false))
            {
                file.WriteLine($"P3\n{ImageWidth} {ImageHeight}\n255");
                for (int j = ImageHeight - 1; j >= 0; --j)
                {
                    for (int i = 0; i < ImageWidth; ++i)
                    {
                        double r = (double)i / (ImageWidth - 1);
                        double g = (double)j / (ImageHeight - 1);
                        double b = 0.25;

                        var col = new Color(r,g,b);

                        file.WriteLine(col.WriteColor());
                    }
                }

            }          
        }

        public static void SecondTest()
        {
            // Image
            const double AspectRetio = 16.0 / 9.0;
            const int ImageWidth = 400;
            const int ImageHeight = (int)(ImageWidth / AspectRetio);
            // Camera
            double ViewportHeight = 2.0;
            double ViewportWidth = AspectRetio * ViewportHeight;
            double FocalLength = 1.0;

            var Origin = new Point3(0, 0, 0);
            var Horizontal = new Vec3(ViewportWidth, 0, 0);
            var Vertical = new Vec3(0, ViewportHeight, 0);
            var LowerLeftCorner = Origin - Horizontal / 2 - Vertical / 2 - new Vec3(0, 0, FocalLength);

            string path = $@"..\..\..\TestImages\GGArveikia.ppm";

            using (var file = new StreamWriter(path, false))
            {
                file.WriteLine($"P3\n{ImageWidth} {ImageHeight}\n255");
                for (int j = ImageHeight - 1; j >= 0; --j)
                {
                    for (int i = 0; i < ImageWidth; ++i)
                    {

                        double u = (double)i / (ImageWidth - 1);
                        double v = (double)j / (ImageHeight - 1);

                        var r = new Ray(Origin, LowerLeftCorner + u*Horizontal + v*Vertical - Origin);

                        var PixelColor = Color.RayColor(r); 

   
                        file.WriteLine(PixelColor.WriteColor());
                    }
                }

            }

        }
    }
}
