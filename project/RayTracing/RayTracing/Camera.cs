using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    internal class Camera
    {
        private Vector3 _origin = Vector3.Zero;
        private double _width;
        private double _height;
        private double _depth;
        public Camera(double width, double height, double depth)
        {
            _width = width;
            _height = height;
            _depth = depth;
        }

        // uv 是从左上角开始的。
        // 因为我在扫描PPM图片的时候就是从左上角开始，逐行扫描的啊。
        // uv 范围 0~1
        public Ray GetRay(double u, double v)
        {
            Vector3 endPos = _origin + new Vector3(-_width / 2 + _width * u, _height / 2 - _height * v, -_depth);
            Vector3 direction = endPos - _origin;
            Ray ray = new Ray(_origin, direction);
            return ray;
        }
    }
}
