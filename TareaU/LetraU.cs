using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaU
{
    class LetraU
    {
        List<Parte> partes = new List<Parte>();
        public LetraU(float x, float y, float z, float w, float h, float d) {
            //Primer palo
            partes.Add(new Parte(x, y, z, w, h, d));

            //Segundo palo
            partes.Add(new Parte(x + w * 2, y, z, w, h, d));

            //Base
            partes.Add(new Parte(x, y, z, w * 2, h/4, d));

        }

        public void Dibujar(int vertexBufferObject, int elementBufferObject)
        {
            foreach (Parte parte in partes)
            {
                parte.Dibujar(vertexBufferObject, elementBufferObject);
            }

        }
    }
}
