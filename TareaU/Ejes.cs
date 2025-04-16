using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace TareaU
{
    // public class Ejes : ObjetoGrafico
    // {
    //     private int vertexBufferObject;
    //     private int vertexArrayObject;

    //     public Ejes(Vector3 posicion, Vector3 rotacion, Vector3 escala)
    //         : base(posicion, rotacion, escala)
    //     {
    //         // Definir los vértices para los ejes X, Y y Z
    //         float[] vertices = new float[]
    //         {
    //             // Eje X (rojo)
    //             0.0f, 0.0f, 0.0f,  1.0f, 0.0f, 0.0f, // Origen
    //             escala.X, 0.0f, 0.0f,  1.0f, 0.0f, 0.0f, // Extremo en X

    //             // Eje Y (verde)
    //             0.0f, 0.0f, 0.0f,  0.0f, 1.0f, 0.0f, // Origen
    //             0.0f, escala.Y, 0.0f,  0.0f, 1.0f, 0.0f, // Extremo en Y

    //             // Eje Z (azul)
    //             0.0f, 0.0f, 0.0f,  0.0f, 0.0f, 1.0f, // Origen
    //             0.0f, 0.0f, escala.Z,  0.0f, 0.0f, 1.0f  // Extremo en Z
    //         };

    //         // Crear buffers para los vértices
    //         vertexBufferObject = GL.GenBuffer();
    //         vertexArrayObject = GL.GenVertexArray();

    //         GL.BindVertexArray(vertexArrayObject);

    //         GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
    //         GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

    //         // Configurar los atributos de los vértices
    //         GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
    //         GL.EnableVertexAttribArray(0);

    //         GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
    //         GL.EnableVertexAttribArray(1);
    //     }

    //     public override void Dibujar(int vertexBufferObject, int elementBufferObject)
    //     {
    //         // Dibujar las líneas de los ejes
    //         GL.BindVertexArray(vertexArrayObject);
    //         GL.DrawArrays(PrimitiveType.Lines, 0, 6); // 6 vértices (2 por eje)
    //     }

    //     public override void Actualizar(double tiempo)
    //     {
    //     }
    // }
}