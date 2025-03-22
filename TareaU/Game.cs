using System.Diagnostics;
using OpenTK.Graphics.OpenGL4;
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

        private int lVertexBufferObject;
        private int lElementBufferObject;
        private int lVertexArrayObject;

        LetraU u = new LetraU(0, 0, 0);

        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            float moveSpeed = 0.0005f;

            if (KeyboardState.IsKeyDown(Keys.A))
            {
                u.x -= moveSpeed;   //Izquierda
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                u.x += moveSpeed;  //Derecha
            }

            // Actualiza los vértices con la nueva posición
            float[] verticesActualizados = u.getVertices(u.x, 0, 0);

            // Actualiza los datos del buffer con los nuevos vértices
            GL.BindBuffer(BufferTarget.ArrayBuffer, lVertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, verticesActualizados.Length * sizeof(float), verticesActualizados, BufferUsageHint.StaticDraw);

            base.OnUpdateFrame(e);
        }

        protected override void OnLoad() //Esta funcion se ejecuta cuando se carga la ventana
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
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            lVertexBufferObject = GL.GenBuffer();
            lVertexArrayObject = GL.GenVertexArray();
            lElementBufferObject = GL.GenBuffer();

            GL.BindVertexArray(lVertexArrayObject);
            GL.BindBuffer(BufferTarget.ArrayBuffer, lVertexBufferObject);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, lElementBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, u.getVertices(0,0,0).Length * sizeof(float), u.getVertices(0,0,0), BufferUsageHint.StaticDraw);
            GL.BufferData(BufferTarget.ElementArrayBuffer, u.getIndices().Length * sizeof(uint), u.getIndices(), BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);


        }

        Stopwatch _timer = Stopwatch.StartNew();
        
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            shader.Use();
            
            //Hace que la figura parpadee:
            double timeValue = _timer.Elapsed.TotalSeconds;
            float greenValue = (float)Math.Sin(timeValue) / 20.0f + 0.5f;
            int vertexColorLocation = GL.GetUniformLocation(shader.Handle, "ourColor");
            GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);

            // Dibujar la figura
            GL.BindVertexArray(lVertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, u.getIndices().Length, DrawElementsType.UnsignedInt, 0);

            SwapBuffers();

        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs e) //se ejecuta cada vez que se redimensiona la ventana
        {
            base.OnFramebufferResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
            shader.Dispose();
        }
    }
}
