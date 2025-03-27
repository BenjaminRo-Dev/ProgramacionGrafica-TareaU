using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TareaU
{

    class LetraU
    {
        public float x = 0.0f;
        public float y = 0.0f;
        public float z = 0.0f;

        public float w = 0.0f;  //Ancho
        public float h = 0.0f;  //Alto
        public float d = 0.0f;  //Profundidad

        public LetraU(float x, float y, float z, float w, float h, float d)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
            this.h = h;
            this.d = d;
        }

        // setters de las dimensiones:
        public void setDimensiones(float w, float h, float d)
        {
            this.w = w;
            this.h = h;
            this.d = d;
        }



        public float[] getVertices(float x, float y, float z)
        {
            return
            [
                ////Posiciones                            Colores
                ////Rectangulo 1 
                //-0.8f + x,  0.8f + y, 0.0f + z,  1.0f, 0.0f, 0.0f,                       // arriba izq
                //-0.8f + x, -0.8f + y, 0.0f + z,  0.0f, 1.0f, 0.0f,                       // abajo izq (vertical)
                //-0.6f + x, -0.8f + y, 0.0f + z,  0.0f, 0.0f, 1.0f,                       // abajo der (horizontal)
                //-0.6f + x,  0.8f + y, 0.0f + z,  1.0f, 0.0f, 0.0f,                       // arriba der (horizontal)
            
                ////Rectangulo 2
                //-0.6f + x,  -0.8f + y, 0.0f + z, 1.0f, 0.0f, 0.0f,// abajo izq
                //-0.6f + x,  -0.6f + y, 0.0f + z, 0.0f, 1.0f, 0.0f,// arriba izq
                //0.6f + x,  -0.6f + y, 0.0f + z,  0.0f, 0.0f, 1.0f,// arriba der
                //0.6f + x,  -0.8f + y, 0.0f + z,  1.0f, 0.0f, 0.0f,// abajo der

                ////Rectangulo 3
                //0.6f + x,  0.8f + y, 0.0f + z,  1.0f, 0.0f, 0.0f,// arriba izq
                //0.6f + x,  -0.8f + y, 0.0f + z, 0.0f, 1.0f, 0.0f, // abajo izq
                //0.8f + x,  -0.8f + y, 0.0f + z, 0.0f, 0.0f, 1.0f, // abajo der
                //0.8f + x,  0.8f + y, 0.0f + z,  1.0f, 0.0f, 0.0f,// arriba der

                //Vertice 1:
                x-w/2, y+h/2, z+d/2, 1.0f, 0.0f, 0.0f, // arriba izq
                //Vertice 2:
                x+w/2, y+h/2, z+d/2, 1.0f, 0.0f, 0.0f, // arriba der
                //Vertice 3:
                x-w/2, y-h/2, z+d/2, 0.0f, 1.0f, 0.0f, // abajo izq
                //Vertice 4:
                x+w/2, y-h/2, z+d/2, 0.0f, 0.0f, 1.0f, // abajo der



            ];
        }

        // Índices para formar los triángulos de la letra "U"
        public uint[] getIndices()
        {
            return
            [
                0, 1, 2,  // First triangle (top left to internal corner)
                1, 2, 3,  // Second triangle (top half)


            //    //Rectangulo 1
            //    0, 1, 3,  // First triangle (top left to internal corner)
            //    1, 2, 3,  // Second triangle (top half)
            //    //Rectangulo 2
            //    4, 5, 6,  // First triangle (top left to internal corner)
            //    4, 7, 6,  // Second triangle (top half)
            //    //Rectangulo 3
            //    8, 9, 10,  // First triangle (top left to internal corner)
            //    8, 11, 10  // Second triangle (top half)
            ];
        }



    }
}
