using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class PPMMap
    {
        private int _width;
        private int _height;

        public int Width
        {
            get
            {
                return _width;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
        }

        private Vector3[] _data;
        public PPMMap(int width, int height)
        {
            _width = width;
            _height = height;
            _data = new Vector3[width * height];
        }

        public void Save(string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write("P3\n");
            sw.Write("" + _width + " " + _height + "\n");
            sw.Write("255\n");
            for (int i = 0; i < _data.Length; i++)
            {
                Vector3 vec = _data[i];
                sw.Write("" + vec.X + "\t" + vec.Y + "\t" + 255 + "\n");
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
