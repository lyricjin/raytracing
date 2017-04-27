using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing.GameObject
{
    class HitResult
    {
        public bool IsHited;
        public Vector3 HitPoint;
        public Vector3 Normal;

        public HitResult(bool isHited, Vector3 hitPoint, Vector3 normal)
        {
            IsHited = isHited;
            HitPoint = hitPoint;
            Normal = normal;
        }
    }

    abstract class Hitable
    {
        public abstract HitResult Hit(Ray ray);
    }
}
