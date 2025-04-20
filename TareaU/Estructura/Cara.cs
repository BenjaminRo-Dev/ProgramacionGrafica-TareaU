
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace TareaU
{
    public class Cara
    {
        public int vao, vbo, ebo;
        public Vector3 Posicion { get; set; }
        public Vector3 Escala { get; set; }
        public Vector3 Rotacion { get; set; }
        public Color4 Color { get; set; }

        private uint[] Indices;

        public Vertice[] Vertices;

        public Vector3 Centro { get; set; }

        public Matrix4 Modelo
        {
            get
            {
                return
                    Matrix4.CreateTranslation(-Centro) *
                    Matrix4.CreateScale(Escala) *
                    Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Rotacion.X)) *
                    Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Rotacion.Y)) *
                    Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Rotacion.Z)) *
                    Matrix4.CreateTranslation(Centro) *
                    Matrix4.CreateTranslation(Posicion);
            }
        }

        //TODO: configurar los indices para caras cuadradas y triangulares
        public Cara(Color4 color, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
        {
            Posicion = Vector3.Zero;
            Escala = Vector3.One;
            Rotacion = Vector3.Zero;
            Color = color;

            this.Vertices = new Vertice[4]
            {
                new Vertice(p1, color),
                new Vertice(p2, color),
                new Vertice(p3, color),
                new Vertice(p4, color)
            };

            this.Indices = new uint[6] { 0, 1, 2, 2, 3, 0 };
        }

        public void Cargar()
        {
            float[] datosVertices = Vertices.SelectMany(v => new float[]
            {
                v.posicion.X, v.posicion.Y, v.posicion.Z,
                v.Color.R, v.Color.G, v.Color.B
            }).ToArray();

            // uint[] indices = { 0, 1, 2, 2, 3, 0 };

            vao = GL.GenVertexArray();
            vbo = GL.GenBuffer();
            ebo = GL.GenBuffer();

            GL.BindVertexArray(vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, datosVertices.Length * sizeof(float), datosVertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, Indices.Length * sizeof(uint), Indices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            GL.BindVertexArray(0);
        }

        public void Dibujar(Shader shader)
        {
            shader.SetMatrix4("modelo", Modelo);

            GL.BindVertexArray(vao);
            GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void Liberar()
        {
            GL.DeleteVertexArray(vao);
            GL.DeleteBuffer(vbo);
            GL.DeleteBuffer(ebo);
        }

        public void CalcularCentro()
        {
            float minX = float.MaxValue, minY = float.MaxValue, minZ = float.MaxValue;
            float maxX = float.MinValue, maxY = float.MinValue, maxZ = float.MinValue;

            foreach (var punto in Vertices)
            {
                if (punto.posicion.X < minX) minX = punto.posicion.X;
                if (punto.posicion.Y < minY) minY = punto.posicion.Y;
                if (punto.posicion.Z < minZ) minZ = punto.posicion.Z;

                if (punto.posicion.X > maxX) maxX = punto.posicion.X;
                if (punto.posicion.Y > maxY) maxY = punto.posicion.Y;
                if (punto.posicion.Z > maxZ) maxZ = punto.posicion.Z;
            }

            float centroX = (minX + maxX) / 2;
            float centroY = (minY + maxY) / 2;
            float centroZ = (minZ + maxZ) / 2;

            Centro = new Vector3(centroX, centroY, centroZ);
        }

    }

}