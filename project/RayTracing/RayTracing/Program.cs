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
            PPMMap map = new PPMMap(10, 10);
            map.Save("raytracing.ppm");
        }
    }
}
