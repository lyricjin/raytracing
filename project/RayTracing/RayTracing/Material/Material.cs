using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracing.GameObject;

namespace RayTracing.Material
{
    abstract class Material
    {
        protected Sphere Sphere;
        protected Vector3 Attenuation;

        public static T CreateMaterial<T>(Sphere sphere, Vector3 attenuation) where T : Material, new()
        {
            T mat = new T();
            mat.Sphere = sphere;
            mat.Attenuation = attenuation;
            return mat;
        }

        public abstract Ray Scatter(Ray inRay, HitResult hitResult);
    }
}
