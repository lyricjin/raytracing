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

        public Vector3 GetCenter()
        {
            return _center;
        }

        public double GetRadius()
        {
            return _radius;
        }

        public override HitResult Hit(Ray ray)
        {
            Vector3 rayToCenter = _center - ray.Origin;

            Vector3 rayToCenterNormalized = rayToCenter;
            rayToCenterNormalized.Normalize();

            // toCenter 和 ray.Direction 的 cos 值
            double cosAngle = Vector3.Dot(rayToCenterNormalized, ray.NomalizedDirection);
            // cos 值 > 0 ，才有机会相交
            if (cosAngle <= 0)
                return HitResult.UnHited;

            // ray 和 center 的距离
            double height = rayToCenter.Length() * Math.Sqrt(1 - cosAngle * cosAngle);
            // 距离超过半径，则不相交
            if (height > _radius)
                return HitResult.UnHited;

            // 求解最近的交点就是射中的点，normal则更是容易算了
            double totalLength = rayToCenter.Length() * cosAngle;
            double inSphereLength = Math.Sqrt(_radius * _radius - height * height);
            double outSphereLength = totalLength - inSphereLength;
            Vector3 hitPoint = ray.Origin + ray.NomalizedDirection * outSphereLength;
            Vector3 normal = hitPoint - _center;
            normal.Normalize();
            return new HitResult(true, outSphereLength, hitPoint, normal);
        }

        public static void Test()
        {
            Sphere sphere;
            Ray ray;
            HitResult result;

            sphere = new Sphere(new Vector3(0, 0, -1.0), 0.5);
            ray = new Ray(new Vector3(0, 0, 0), new Vector3(0, 0, -1));
            result = sphere.Hit(ray);

            Console.WriteLine("hited: " + result.IsHited);
            Console.WriteLine("point: " + result.HitPoint);
            Console.WriteLine("normal: " + result.Normal);
        }
    }
}
