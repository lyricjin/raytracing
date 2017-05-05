using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing.GameObject
{
    class GameWorld : Hitable
    {
        private List<Sphere> _spheres;

        public GameWorld()
        {
            _spheres = new List<Sphere>();
        }

        public void AddSphere(Sphere sphere)
        {
            _spheres.Add(sphere);
        }

        public void RemoveSphere(Sphere sphere)
        {
            _spheres.Remove(sphere);
        }

        public override HitResult Hit(Ray ray)
        {
            HitResult result = HitResult.UnHited;
            for (int i = 0; i < _spheres.Count; i++)
            {
                HitResult r = _spheres[i].Hit(ray);
                if (r.IsHited == true)
                {
                    if (result.IsHited == false)
                        result = r;
                    else if(result.Length >= r.Length)
                    {
                        result = r;
                    }
                }
            }
            return result;
        }
    }
}
