using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class Camera
    {
        // 默认原点在(0, 0, 0), 看向Z轴正向
        // 屏幕默认 16:9
        private Vector3 _origin = Vector3.Zero;
        private double _width;
        private double _height;
        private double _depth;

        public Camera(double depth, double fov)
        {
            _depth = depth;
            double halfFov = fov / 2;
            double radians = (Math.PI / 180) * halfFov;
            double tan = Math.Tan(radians);
            _height = _depth * tan * 2;
            _width = _height * 16 / 9;
        }

        // uv 是从左上角开始的。
        // 因为我在扫描PPM图片的时候就是从左上角开始，逐行扫描的啊。
        // uv 范围 0~1
        public Ray GetRay(double u, double v)
        {
            Vector3 endPos = _origin + new Vector3(-_width / 2 + _width * u, _height / 2 - _height * v, _depth);
            Vector3 direction = endPos - _origin;
            Ray ray = new Ray(_origin, direction);
            return ray;
        }

        public Vector3 GetSkyColor(Ray ray)
        {
            Ray hitTop = GetRay(0.5, 0.0);
            double y1 = ray.NomalizedDirection.Y;
            double y2 = hitTop.NomalizedDirection.Y;
            double t = 0.5 * (y1 / y2 + 1.0);
            Vector3 color = (1.0 - t) * (new Vector3(1.0, 1.0, 1.0)) +
                                    t * new Vector3(0.5, 0.7, 1.0);
            color = new Vector3(color.X, color.Y, color.Z);
            return color;
        }
    }
}
