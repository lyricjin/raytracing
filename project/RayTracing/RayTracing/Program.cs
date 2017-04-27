using System;
using System.Runtime.InteropServices;
using RayTracing.GameObject;

namespace RayTracing
{
    class Program
    {
        static Vector3 GetSkyColor(Ray ray)
        {
            double t = 0.5 * (ray.Direction.Y + 1.0);
            Vector3 color = (1.0 - t) * (new Vector3(1.0, 1.0, 1.0)) +
                                    t * new Vector3(0.5, 0.7, 1.0);
            color = new Vector3(color.X, color.Y, color.Z);
            return color;
        }

        static Vector3 GetColor(Hitable world, Ray ray)
        {
            HitResult result = world.Hit(ray);
            Vector3 normal = result.Normal;
            if (result.IsHited)
                return new Vector3(0.5f * (normal.X + 1),
                                   0.5f * (normal.Y + 1),
                                   0.5f * (normal.Z + 1));

            return GetSkyColor(ray);
        }

        static void Main(string[] args)
        {
            Camera camera = new Camera(4f, 2f, 2f);

            GameWorld world = new GameWorld();
            Sphere sphere = new Sphere(new Vector3(0, 0, -2.0), 0.5);
            world.AddSphere(sphere);

            PPMMap map = new PPMMap(400, 200);
            for (int row = 0; row < map.Height; row++)
            {
                for (int col = 0; col < map.Width; col++)
                {
                    Ray ray = camera.GetRay((double)col / map.Width, (double)row / map.Height);
                    //                    map.SetColor(col, row, GetColor(world, ray));
                    map.SetColor(col, row, GetColor(sphere, ray));
                }
            }
            map.Save("raytracing.ppm");
            Console.WriteLine("done.");
            Console.ReadKey();
        }
    }
}
