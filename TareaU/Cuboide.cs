using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaU
{
    class Cuboide
    {
        List<Rectangulo> rectangulos = new List<Rectangulo>();
        public Cuboide(float x, float y, float z, float w, float h, float d)
        {

            // Frontal
            rectangulos.Add(new Rectangulo(x, y, z, w, h, d, Rectangulo.Cara.Frontal, Rectangulo.Color.Azul));
            rectangulos.Add(new Rectangulo(x, y, z + d, w, h, d, Rectangulo.Cara.Frontal, Rectangulo.Color.Azul));

            // Echada (Superior)
            rectangulos.Add(new Rectangulo(x, y, z, w, h, d, Rectangulo.Cara.Echada, Rectangulo.Color.Verde));
            rectangulos.Add(new Rectangulo(x, y + h, z, w, h, d, Rectangulo.Cara.Echada, Rectangulo.Color.Verde));

            // Costado (Lateral)
            rectangulos.Add(new Rectangulo(x, y, z, w, h, d, Rectangulo.Cara.Costado, Rectangulo.Color.Rojo));
            rectangulos.Add(new Rectangulo(x + w, y, z, w, h, d, Rectangulo.Cara.Costado, Rectangulo.Color.Rojo));

        }

        public void Dibujar(int vertexBufferObject, int elementBufferObject)
        {
            foreach (Rectangulo r in rectangulos)
            {
                r.Dibujar(vertexBufferObject, elementBufferObject);
            }
        }
    }
}
