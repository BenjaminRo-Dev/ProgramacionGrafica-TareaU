using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaU
{
    class Vertice
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }

        public Vertice(float x, float y, float z, float r, float g, float b)
        {
            X = x;
            Y = y;
            Z = z;
            R = r;
            G = g;
            B = b;
        }

        public float[] ToArray()
        {
            return new float[] { X, Y, Z, R, G, B };
        }
    }
}
