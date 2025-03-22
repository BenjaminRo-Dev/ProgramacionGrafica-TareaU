using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaU
{

    class LetraU
    {
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;

        public LetraU(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float[] getVertices(float x, float y, float z)
        {
            // Vértices para la letra "U"
            return new float[]
            {
                //Rectangulo 1
                -0.8f + x,  0.8f + y, 0.0f + z,  // arriba izq
                -0.8f + x, -0.8f + y, 0.0f + z,  // abajo izq (vertical)
                -0.6f + x, -0.8f + y, 0.0f + z,  // abajo der (horizontal)
                -0.6f + x,  0.8f + y, 0.0f + z,  // arriba der (horizontal)
            
                //Rectangulo 2
                -0.6f + x,  -0.8f + y, 0.0f + z, // abajo izq
                -0.6f + x,  -0.6f + y, 0.0f + z, // arriba izq
                0.6f + x,  -0.6f + y, 0.0f + z,  // arriba der
                0.6f + x,  -0.8f + y, 0.0f + z,  // abajo der

                //Rectangulo 3
                0.6f + x,  0.8f + y, 0.0f + z,  // arriba izq
                0.6f + x,  -0.8f + y, 0.0f + z,  // abajo izq
                0.8f + x,  -0.8f + y, 0.0f + z,  // abajo der
                0.8f + x,  0.8f + y, 0.0f + z,  // arriba der

            };
        }

        // Índices para formar los triángulos de la letra "U"
        public uint[] getIndices()
        {
            return new uint[]
            {
                //Rectangulo 1
                0, 1, 3,  // First triangle (top left to internal corner)
                1, 2, 3,  // Second triangle (top half)
                //Rectangulo 2
                4, 5, 6,  // First triangle (top left to internal corner)
                4, 7, 6,  // Second triangle (top half)
                //Rectangulo 3
                8, 9, 10,  // First triangle (top left to internal corner)
                8, 11, 10  // Second triangle (top half)
            };
        }
    }
}
