using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class Program
    {
        static Vector3 GetColor(Ray ray)
        {
            Vector3 color = new Vector3((int)(255 * Math.Abs(ray.Direction.X)),
                                        (int)(255 * Math.Abs(ray.Direction.Y)),
                                        (int)(255 * Math.Abs(ray.Direction.Z)));
            return color;
        }

        static void Main(string[] args)
        {
            Camera camera = new Camera(4f, 2f, 2f);
            PPMMap map = new PPMMap(400, 200);
            for (int row = 0; row < map.Height; row++)
            {
                for (int col = 0; col < map.Width; col++)
                {
                    Ray ray = camera.GetRay((double)col / map.Width, (double)row / map.Height);
                    map.SetColor(col, row, GetColor(ray));
                }
            }
            map.Save("raytracing.ppm");
            Console.WriteLine("done.");
            Console.ReadKey();
        }
    }
}
