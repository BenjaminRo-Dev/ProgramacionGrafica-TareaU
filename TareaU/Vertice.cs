using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace TareaU
{
    public class Vertice
    {
        public Vector3 posicion { get; set; }

        public Color4 Color { get; set; }

        public Vertice(Vector3 posicion,  Color4 color)
        {
            this.posicion = posicion;
            Color = color;
        }

        public float[] ToArray()
        {
            return new float[] { posicion.X, posicion.Y, posicion.Z, Color.R, Color.G, Color.B, Color.A };
        }
    }
}
