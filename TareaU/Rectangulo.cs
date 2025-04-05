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

        public enum Cara
        {
            Frontal,   // Frente
            Echada,    // Superior
            Costado    // Lateral
        }

        public enum Color
        {
            Rojo = 1,
            Verde = 2,
            Azul = 3
        }

        public Rectangulo(float x, float y, float z, float w, float h, float d, Cara cara, Color color)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
            this.h = h;
            this.d = d;

            float r = 0.0f;
            float g = 0.0f;
            float b = 0.0f;

            switch (color)
            {
                case Color.Rojo:
                    r = 0.9f;
                    break;
                case Color.Verde:
                    g = 0.5f;
                    break;
                case Color.Azul:
                    b = 0.3f;
                    break;
            }

            switch (cara)
            {
                case Cara.Frontal:
                    // Cara de frente (XY plane)
                    vertices = new Vertice[]
                    {
                        new Vertice(x,      y,      z,      r, g, b),   // Abajo izquierda
                        new Vertice(x + w,  y,      z,      r, g, b),   // Abajo derecha
                        new Vertice(x + w,  y + h,  z,      r, g, b),   // Arriba derecha
                        new Vertice(x,      y + h,  z,      r, g, b)    // Arriba izquierda
                    };
                    break;

                case Cara.Echada:
                    // Cara echada (XZ plane)
                    vertices = new Vertice[]
                    {
                        new Vertice(x,      y,      z,      r, g, b),   // Abajo izquierda
                        new Vertice(x + w,  y,      z,      r, g, b),   // Abajo derecha
                        new Vertice(x + w,  y,      z + d,  r, g, b),   // Arriba derecha
                        new Vertice(x,      y,      z + d,  r, g, b)    // Arriba izquierda
                    };
                    break;

                case Cara.Costado:
                    // Cara de costado (YZ plane)
                    vertices = new Vertice[]
                    {
                        new Vertice(x,      y,      z,      r, g, b),   // Abajo izquierda
                        new Vertice(x,      y,      z + d,  r, g, b),   // Abajo derecha
                        new Vertice(x,      y + h,  z + d,  r, g, b),   // Arriba derecha
                        new Vertice(x,      y + h,  z,      r, g, b)    // Arriba izquierda
                    };
                    break;
            }
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

            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].X += dx;
                vertices[i].Y += dy;
                vertices[i].Z += dz;
            }
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
            return new uint[]
            {
            0, 1, 2,
            2, 3, 0,
            };
        }
    }

}
