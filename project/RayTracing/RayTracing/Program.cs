﻿using System;

namespace RayTracing
{
    class Program
    {
        static Vector3 GetColor(Ray ray)
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
