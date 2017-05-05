using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class Ray
    {
        public static Ray Default = new Ray(Vector3.Zero, Vector3.Forward);
        public Vector3 Origin { get; }
        public Vector3 Direction { get; }
        public Vector3 NomalizedDirection { get; }

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
            direction.Normalize();
            NomalizedDirection = direction;
        }

        public Vector3 PointAtDistance(float distance)
        {
            Vector3 point = Origin + distance * Direction;
            return point;
        }
    }
}
