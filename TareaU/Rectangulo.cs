using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;
using OpenTK.Graphics.OpenGL4;
using System.Drawing;

namespace TareaU
{

    class Rectangulo
    {
        public float x = 0.0f;
        public float y = 0.0f;
        public float z = 0.0f;

        public float w = 0.0f;
        public float h = 0.0f;
        public float d = 0.0f;

        Vertice[] vertices;

        public Rectangulo(float x, float y, float z, float w, float h, float d)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
            this.h = h;
            this.d = d;

            float r = 1.0f;
            float g = 0.0f;
            float b = 0.0f;

            vertices = new Vertice[]
            {
                new Vertice(x,      y,      z + d,      r, g, b),   // Abajo izquierda
                new Vertice(x + w,  y,      z + d,      r, g, b),   // Abajo derecha
                new Vertice(x + w,  y + h,  z + d,      r, g, b),   // Arriba derecha
                new Vertice(x,      y + h,  z + d,      r, g, b)    // Arriba izquierda
            };
        }

        public void Dibujar(int vertexBufferObject, int elementBufferObject)
        {
            float[] updatedVertices = getVertices();
            uint[] indices = getIndices();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, updatedVertices.Length * sizeof(float), updatedVertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }


        public void Mover(float dx, float dy, float dz)
        {
            this.x += dx;
            this.y += dy;
            this.z += dz;

            vertices[0].X += dx;
            vertices[0].Y += dy;
            vertices[0].Z += dz;

            vertices[1].X += dx;
            vertices[1].Y += dy;
            vertices[1].Z += dz;

            vertices[2].X += dx;
            vertices[2].Y += dy;
            vertices[2].Z += dz;

            vertices[3].X += dx;
            vertices[3].Y += dy;
            vertices[3].Z += dz;
        }





        public float[] getVertices()
        {

            List<float> verticesList = new List<float>();
            foreach (Vertice vertice in vertices)
            {
                verticesList.AddRange(vertice.ToArray());
            }
            return verticesList.ToArray();
            
        }

        public uint[] getIndices()
        {
            return
            [
                0, 1, 2,
                2, 3, 0,
            ];

        }

    }
}
