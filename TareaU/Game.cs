using System.Diagnostics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace TareaU
{
    class Game : GameWindow
    {
        Shader shader;

        private int vertexBufferObject;    //Se encarga de almacenar los vertices
        private int elementBufferObject;   //Se encarga de almacenar los indices
        private int vertexArrayObject;

        LetraU u = new LetraU(0, 0, 0);


        // A simple constructor to let us set properties like window size, title, FPS, etc. on the window.
        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        // This function runs on every update frame.
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Ajusta el valor de desplazamiento para que la letra se mueva más lentamente
            float moveSpeed = 0.0005f;  // Reducido el valor de desplazamiento para que sea más suave

            if (KeyboardState.IsKeyDown(Keys.A))
            {
                u.x -= moveSpeed;  // Desplazamiento a la izquierda
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                u.x += moveSpeed;  // Desplazamiento a la derecha
            }

            // Actualiza los vértices con la nueva posición
            float[] updatedVertices = u.getVertices(u.x, 0, 0);

            // Actualiza los datos del buffer con los nuevos vértices
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, updatedVertices.Length * sizeof(float), updatedVertices, BufferUsageHint.StaticDraw);

            base.OnUpdateFrame(e);
        }




        //Esta funcion se ejecuta cuando se carga la ventana
        protected override void OnLoad()
        {   
            base.OnLoad();
            //Dibujar los vertices
            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            //1. Generar el buffer
            vertexBufferObject = GL.GenBuffer();
            vertexArrayObject = GL.GenVertexArray();
            elementBufferObject = GL.GenBuffer();

            //2. Vincular el buffer
            GL.BindVertexArray(vertexArrayObject);                                      //Vincular el vertex array object
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);                //Vincular el buffer de vertices
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);        //Vincular el buffer de elementos


            //3. Cargar los vertices en el buffer

            //Definiendo la forma de los vertices
            //pos 0, 3 elementos, tipo float, no normalizado, distancia entre atributos del vertice, offset 0
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.BufferData(BufferTarget.ArrayBuffer, u.getVertices(0,0,0).Length * sizeof(float), u.getVertices(0,0,0), BufferUsageHint.StaticDraw);
            GL.BufferData(BufferTarget.ElementArrayBuffer, u.getIndices().Length * sizeof(uint), u.getIndices(), BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);



        }

        Stopwatch _timer = Stopwatch.StartNew();
        //OnRenderFrame se ejecuta cada vez que se renderiza un frame
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Dibujar el triangulo
            shader.Use();

            // update the uniform color
            
            double timeValue = _timer.Elapsed.TotalSeconds;
            float greenValue = (float)Math.Sin(timeValue) / 2.0f + 0.5f;
            int vertexColorLocation = GL.GetUniformLocation(shader.Handle, "ourColor");
            GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);


            // Dibujar la letra
            GL.BindVertexArray(vertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, u.getIndices().Length, DrawElementsType.UnsignedInt, 0);


            SwapBuffers();


        }

        //OnFramebufferResize se ejecuta cada vez que se redimensiona la ventana
        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        //OnUnload se ejecuta cuando se cierra la ventana
        protected override void OnUnload()
        {
            base.OnUnload();
            //GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(_vertexBufferObject);
            //GL.DeleteProgram(shader.Handle);
            shader.Dispose();
        }
    }
}
