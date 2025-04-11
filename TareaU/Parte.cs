using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaU
{
    class Parte
    {
        List<Cara> caras = new List<Cara>();
        public Parte(float x, float y, float z, float w, float h, float d)
        {

            // Frontal
            caras.Add(new Cara(x, y, z, w, h, d, Cara.Posicion.Frontal, Cara.Color.Azul));
            caras.Add(new Cara(x, y, z + d, w, h, d, Cara.Posicion.Frontal, Cara.Color.Azul));

            // Echada (Superior)
            caras.Add(new Cara(x, y, z, w, h, d, Cara.Posicion.Echada, Cara.Color.Verde));
            caras.Add(new Cara(x, y + h, z, w, h, d, Cara.Posicion.Echada, Cara.Color.Verde));

            // Costado (Lateral)
            caras.Add(new Cara(x, y, z, w, h, d, Cara.Posicion.Costado, Cara.Color.Rojo));
            caras.Add(new Cara(x + w, y, z, w, h, d, Cara.Posicion.Costado, Cara.Color.Rojo));

        }

        public void Dibujar(int vertexBufferObject, int elementBufferObject)
        {
            foreach (Cara cara in caras)
            {
                cara.Dibujar(vertexBufferObject, elementBufferObject);
            }
        }
    }
}
