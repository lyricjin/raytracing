using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing.GameObject
{
    class Sphere : Hitable
    {
        private Vector3 _center;
        private double _radius;

        public Sphere(Vector3 center, double radius)
        {
            _center = center;
            _radius = radius;
        }

        public override HitResult Hit(Ray ray)
        {
            return new HitResult(true, _center, _center * _radius);
        }
    }
}
