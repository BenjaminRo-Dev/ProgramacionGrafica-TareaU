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
        public Cuboide() {

            rectangulos.Add(new Rectangulo(-2, -2, 0, 2, 2, -5));
            rectangulos.Add(new Rectangulo(2, -2, 0, 2, 2, -5));
            rectangulos.Add(new Rectangulo(-2, 2, 0, 3, 3, -5));

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
