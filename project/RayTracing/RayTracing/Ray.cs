using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class Ray
    {
        public Vector3 Origin { get; }
        public Vector3 Direction { get; }

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            direction.Normalize();
            Direction = direction;
        }

        public Vector3 PointAtDistance(float distance)
        {
            Vector3 point = Origin + distance * Direction;
            return point;
        }
    }
}
