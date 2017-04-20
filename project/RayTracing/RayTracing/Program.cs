using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class Program
    {
        static void Main(string[] args)
        {
            PPMMap map = new PPMMap(400, 200);
            for (int row = 0; row < map.Height; row++)
            {
                for (int col = 0; col < map.Width; col++)
                {
                    map.SetColor(col, row, new Vector3(255 * col / map.Width, 255 * row / map.Height, 0));
                }
            }
            map.Save("raytracing.ppm");
            Console.WriteLine("done.");
            Console.ReadKey();
        }
    }
}
