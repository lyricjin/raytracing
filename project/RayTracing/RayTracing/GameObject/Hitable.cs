using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing.GameObject
{
    class HitResult
    {
        public static HitResult UnHited = new HitResult(false, 0, Vector3.Zero, Vector3.Zero);
        public bool IsHited;
        public Vector3 HitPoint;
        public Vector3 Normal;
        public double Length;

        public HitResult(bool isHited, double length, Vector3 hitPoint, Vector3 normal)
        {
            IsHited = isHited;
            Length = length;
            HitPoint = hitPoint;
            Normal = normal;
        }
    }

    abstract class Hitable
    {
        public abstract HitResult Hit(Ray ray);
    }
}
