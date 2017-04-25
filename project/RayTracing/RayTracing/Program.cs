using System;

namespace RayTracing
{
    class HitResult
    {
        public bool Available;
        public Vector3 HitPoint;
        public Vector3 Normal;

        public HitResult(bool available, Vector3 hitPoint, Vector3 normal)
        {
            Available = available;
            HitPoint = hitPoint;
            Normal = normal;
        }
    }

    class Sphere
    {
        private Vector3 _center;
        private double _radius;

        public Sphere(Vector3 center, double radius)
        {
            _center = center;
            _radius = radius;
        }

        public HitResult Hit(Ray ray)
        {
            return new HitResult(true, _center, _center * _radius);
        }
    }

    class Program
    {
        static Vector3 GetColor(Sphere sphere, Ray ray)
        {
            double t = 0.5 * (ray.Direction.Y + 1.0);
            Vector3 color = (1.0 - t) * (new Vector3(1.0 * 255, 1.0 * 255, 1.0 * 255)) +
                                    t * new Vector3(0.5 * 255, 0.7 * 255, 1.0 * 255);
            color = new Vector3((int)color.X, (int)color.Y, (int)color.Z);
            return color;
        }

        static void Main(string[] args)
        {
            Camera camera = new Camera(4f, 2f, 2f);
            Sphere sphere = new Sphere(new Vector3(0, 0, -1.0), 0.5);
            PPMMap map = new PPMMap(400, 200);
            for (int row = 0; row < map.Height; row++)
            {
                for (int col = 0; col < map.Width; col++)
                {
                    Ray ray = camera.GetRay((double)col / map.Width, (double)row / map.Height);
                    map.SetColor(col, row, GetColor(sphere, ray));
                }
            }
            map.Save("raytracing.ppm");
            Console.WriteLine("done.");
            Console.ReadKey();
        }
    }
}
