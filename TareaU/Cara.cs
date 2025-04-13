using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace TareaU
{
    class Cara
    {
        public Vector3 Posicion { get; set; } // Posición inicial de la cara
        public Vector3 Escala { get; set; }   // Ancho, alto y profundidad
        public Vector3 Color { get; set; }   // Color RGB de la cara
        public Matrix4 Rotacion { get; set; } // Matriz de rotación para orientar la cara

        private Vertice[] vertices;

        public Cara(Vector3 posicion, Vector3 escala, Vector3 color)
        {
            Posicion = posicion;
            Escala = escala;
            Color = color;
            Rotacion = Matrix4.Identity; // Sin rotación por defecto

            // Crear los vértices en el plano base (XY)
            vertices = new Vertice[]
            {
                new Vertice(0, 0, 0, Color.X, Color.Y, Color.Z), // Abajo izquierda
                new Vertice(Escala.X, 0, 0, Color.X, Color.Y, Color.Z), // Abajo derecha
                new Vertice(Escala.X, Escala.Y, 0, Color.X, Color.Y, Color.Z), // Arriba derecha
                new Vertice(0, Escala.Y, 0, Color.X, Color.Y, Color.Z)  // Arriba izquierda
            };
        }

        public void Dibujar(int vertexBufferObject, int elementBufferObject)
        {
            // Aplicar la rotación y traslación a los vértices
            float[] updatedVertices = getVerticesTransformados();
            uint[] indices = getIndices();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, updatedVertices.Length * sizeof(float), updatedVertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void Mover(Vector3 desplazamiento)
        {
            Posicion += desplazamiento;
        }

        public void Rotar(Vector3 angulos)
        {
            // Crear una matriz de rotación a partir de los ángulos (en grados)
            Rotacion = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angulos.X)) *
                       Matrix4.CreateRotationY(MathHelper.DegreesToRadians(angulos.Y)) *
                       Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(angulos.Z));
        }

        private float[] getVerticesTransformados()
        {
            List<float> verticesList = new List<float>();

            foreach (Vertice vertice in vertices)
            {
                // Transformar el vértice usando la matriz de rotación y traslación
                Vector4 posicionTransformada = new Vector4(vertice.X, vertice.Y, vertice.Z, 1.0f);
                posicionTransformada = posicionTransformada * Rotacion;
                posicionTransformada.X += Posicion.X;
                posicionTransformada.Y += Posicion.Y;
                posicionTransformada.Z += Posicion.Z;

                // Agregar los datos transformados a la lista
                verticesList.Add(posicionTransformada.X);
                verticesList.Add(posicionTransformada.Y);
                verticesList.Add(posicionTransformada.Z);
                verticesList.Add(vertice.R);
                verticesList.Add(vertice.G);
                verticesList.Add(vertice.B);
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