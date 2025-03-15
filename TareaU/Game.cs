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


        //Vertices de un triangulo
        float[] vertices = {
             0.5f,  0.5f, 0.0f,  // top right
             0.5f, -0.5f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,  // bottom left
            -0.5f,  0.5f, 0.0f   // top left
        };

        uint[] indices = {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };


        // A simple constructor to let us set properties like window size, title, FPS, etc. on the window.
        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        // This function runs on every update frame.
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Check if the Escape button is currently being pressed.
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                // If it is, close the window.
                Close();
            }

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
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            //Definiendo la forma de los vertices
            //pos 0, 3 elementos, tipo float, no normalizado, distancia entre atributos del vertice, offset 0
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);



        }

        //OnRenderFrame se ejecuta cada vez que se renderiza un frame
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Dibujar el triangulo
            shader.Use();
            GL.BindVertexArray(vertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

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
