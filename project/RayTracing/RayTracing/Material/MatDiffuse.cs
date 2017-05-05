using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RayTracing.GameObject;

namespace RayTracing.Material
{
    class MatDiffuse : Material
    {
        // 这个应该算启发性的算法，以hitPoint为中心，随机一个点，这个点如果在球内部，
        // 则可以使用这个射线的反方向作为反弹射线的方向。
        // 这里是一个Cube，我觉得在Sphere里面随机应该更正确。
        public override Ray Scatter(Ray inRay, HitResult hitResult)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            while (true)
            {
                double x = -1 + 2 * rand.NextDouble();
                double y = -1 + 2 * rand.NextDouble();
                double z = -1 + 2 * rand.NextDouble();
                Vector3 deltaVec = new Vector3(x, y, z);
                deltaVec.Normalize();
                Vector3 randPos = hitResult.HitPoint + deltaVec * Sphere.GetRadius();
                if (PointIsInSphere(randPos))
                {
                    Vector3 scatterVec = hitResult.HitPoint - randPos;
                    return new Ray(hitResult.HitPoint, scatterVec);
                }
            }
        }

        bool PointIsInSphere(Vector3 pos)
        {
            Vector3 vec = pos - Sphere.GetCenter();
            if (vec.Length() <= Sphere.GetRadius())
                return true;
            return false;
        }
    }
}
