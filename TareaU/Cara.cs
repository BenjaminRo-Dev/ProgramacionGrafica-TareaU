
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

        private Vertice[] vertices;

        public Matrix4 Modelo =>
            Matrix4.CreateScale(Escala) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Rotacion.X)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Rotacion.Y)) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Rotacion.Z)) *
            Matrix4.CreateTranslation(Posicion);

        public Cara(Vector3 posicion, Vector3 escala, Color4 color)
        {
            Posicion = posicion;
            Escala = escala;
            Rotacion = Vector3.Zero;
            Color = color;

            vertices = new Vertice[]
            {
            new Vertice(new Vector3(-0.5f, -0.5f, 0f), Color),
            new Vertice(new Vector3( 0.5f, -0.5f, 0f), Color),
            new Vertice(new Vector3( 0.5f,  0.5f, 0f), Color),
            new Vertice(new Vector3(-0.5f,  0.5f, 0f), Color),
            };
        }

        public void Cargar()
        {
            float[] datosVertices = vertices.SelectMany(v => new float[]
            {
                v.posicion.X, v.posicion.Y, v.posicion.Z,
                v.Color.R, v.Color.G, v.Color.B
            }).ToArray();

            uint[] indices = { 0, 1, 2, 2, 3, 0 };

            vao = GL.GenVertexArray();
            vbo = GL.GenBuffer();
            ebo = GL.GenBuffer();

            GL.BindVertexArray(vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, datosVertices.Length * sizeof(float), datosVertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

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
            GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
        }

        public void Liberar()
        {
            GL.DeleteVertexArray(vao);
            GL.DeleteBuffer(vbo);
            GL.DeleteBuffer(ebo);
        }

    }

}