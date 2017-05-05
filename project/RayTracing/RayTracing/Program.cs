using System;
using System.Runtime.InteropServices;
using RayTracing.GameObject;

namespace RayTracing
{
    class Program
    {
        static Vector3 GetColor(Hitable world, Ray ray)
        {
            HitResult result = world.Hit(ray);
            Vector3 normal = result.Normal;
            if (result.IsHited)
                return new Vector3(0.5f * (normal.X + 1),
                                   0.5f * (normal.Y + 1),
                                   0.5f * (normal.Z + 1));

            return Camera.GetSkyColor(ray);
        }

        public static Camera Camera = new Camera(10f, 42f);
        static void Main(string[] args)
        {
            GameWorld world = new GameWorld();
            Sphere sphere1 = new Sphere(new Vector3(0, 0, 6f), 0.5f);
            Sphere sphere2 = new Sphere(new Vector3(-1.7, 1.4, 4.5), 0.5f);
            Sphere sphere3 = new Sphere(new Vector3(3.1, -0.5, 6f), 0.5f);
            Sphere sphereBig = new Sphere(new Vector3(0, -100, 6f), 99.5f);
            world.AddSphere(sphere1);
            world.AddSphere(sphere2);
            world.AddSphere(sphere3);
            world.AddSphere(sphereBig);

            PPMMap map = new PPMMap(480, 270);
            for (int row = 0; row < map.Height; row++)
            {
                for (int col = 0; col < map.Width; col++)
                {
                    Ray ray = Camera.GetRay((double)col / map.Width, (double)row / map.Height);
                    map.SetColor(col, row, GetColor(world, ray));
                }
            }
            map.Save("raytracing.ppm");
            Console.WriteLine("done.");
            Console.ReadKey();
        }
    }
}
