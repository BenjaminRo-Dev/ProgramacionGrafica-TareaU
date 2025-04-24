
using OpenTK.Compute.OpenCL;
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

        public Dictionary<string, Vertice> Vertices;

        public Vector3 Centro { get; set; }

        public Matrix4 Modelo = Matrix4.Identity;

        public Cara(Color4 color, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
        {
            Posicion = Vector3.Zero;
            Escala = Vector3.One;
            Rotacion = Vector3.Zero;
            Color = color;

            Vertices = new Dictionary<string, Vertice>
            {
                { "p1", new Vertice(p1, color) },
                { "p2", new Vertice(p2, color) },
                { "p3", new Vertice(p3, color) },
                { "p4", new Vertice(p4, color) }
            };

            this.Indices = new uint[6] { 0, 1, 2, 2, 3, 0 };
        }

        public Cara(Color4 color, Dictionary<string, Vector3> vertices)
        {
            Posicion = Vector3.Zero;
            Escala = Vector3.One;
            Rotacion = Vector3.Zero;
            Color = color;

            Vertices = new Dictionary<string, Vertice>();

            foreach (var vertice in vertices)
            {
                Vertices.Add(vertice.Key, new Vertice(vertice.Value, color));
            }

            this.Indices = new uint[6] { 0, 1, 2, 2, 3, 0 };
        }
        

        public void Cargar()
        {
            float[] datosVertices = Vertices.Values.SelectMany(v => new float[]
            {
                v.posicion.X, v.posicion.Y, v.posicion.Z,
                v.Color.R, v.Color.G, v.Color.B
            }).ToArray();

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

        public Vector3 CalcularCentro()
        {
            Vector3 suma = Vector3.Zero;

            foreach (var vertice in Vertices.Values)
            {
                suma += vertice.posicion;
            }

            Centro = suma / Vertices.Values.Count;
            return Centro;
        }

        
        public void Rotar(Vector3 angulos, Vector3? centro = null)
        {
            if (centro != null)
            {
                Centro = (Vector3)centro;
            }

            Rotacion += angulos;

            var matrizRotacion =
                Matrix4.CreateTranslation(-Centro) *
                Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angulos.X)) *
                Matrix4.CreateRotationY(MathHelper.DegreesToRadians(angulos.Y)) *
                Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(angulos.Z)) *
                Matrix4.CreateTranslation(Centro);

            Modelo *= matrizRotacion;

            foreach (var vertice in Vertices.Values)
            {
                var posicion = new Vector4(vertice.posicion, 1.0f);
                posicion = Vector4.TransformRow(posicion, matrizRotacion);
                vertice.posicion = posicion.Xyz;
            }

        }


        public void Liberar()
        {
            GL.DeleteVertexArray(vao);
            GL.DeleteBuffer(vbo);
            GL.DeleteBuffer(ebo);
        }



    }

}