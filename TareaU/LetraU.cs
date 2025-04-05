using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaU
{
    class LetraU
    {
        List<Cuboide> cuboides = new List<Cuboide>();
        public LetraU(float x, float y, float z, float w, float h, float d) {
            //Primer palo
            cuboides.Add(new Cuboide(x, y, z, w, h, d));


            //Segundo palo
            cuboides.Add(new Cuboide(x + w * 2, y, z, w, h, d));

            //Base
            cuboides.Add(new Cuboide(x, y, z, w * 2, h/4, d));

        }

        public void Dibujar(int vertexBufferObject, int elementBufferObject)
        {
            foreach (Cuboide c in cuboides)
            {
                c.Dibujar(vertexBufferObject, elementBufferObject);
            }

        }
    }
}
