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
        
        private int vertexArrayObject;


        //Vertices de un triangulo
        private readonly float[] vertices =
        {
            //x, y, z
            -0.5f, -0.5f, 0.0f, //abajo izquierda
             0.5f, -0.5f, 0.0f, //abajo derecha
             0.0f,  0.5f, 0.0f  //arriba
        };


        //private int _vertexArrayObject;


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
            //Generar el buffer
            vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);

            //Cargar los vertices en el buffer
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            //Dibujar los vertices
            //shader = new Shader("shader.vert", "shader.frag");
            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject); //Vincular el vertex array object

            //Copiar nuestros vertices en un buffer que OpenGL puede usar
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            //Definiendo la forma de los vertices
                                //pos 0, 3 elementos, tipo float, no normalizado, distancia entre atributos del vertice, offset 0
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            //shader.Use();
            // 3. now draw the object
            //someOpenGLFunctionThatDrawsOurTriangle();

            


            //GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            //Code goes here
        }

        //OnRenderFrame se ejecuta cada vez que se renderiza un frame
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Dibujar el triangulo
            shader.Use();
            GL.BindVertexArray(vertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

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
