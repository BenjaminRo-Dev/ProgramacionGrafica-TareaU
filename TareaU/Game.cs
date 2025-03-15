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

        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;


        float[] getVertices(float x, float y, float z)
        {
            // Vértices para la letra "U"
            return new float[]
            {
                //Rectangulo 1
                -0.8f + x,  0.8f + y, 0.0f + z,  // arriba izq
                -0.8f + x, -0.8f + y, 0.0f + z,  // abajo izq (vertical)
                -0.6f + x, -0.8f + y, 0.0f + z,  // abajo der (horizontal)
                -0.6f + x,  0.8f + y, 0.0f + z,  // arriba der (horizontal)
            
                //Rectangulo 2
                -0.6f + x,  -0.8f + y, 0.0f + z, // abajo izq
                -0.6f + x,  -0.6f + y, 0.0f + z, // arriba izq
                0.6f + x,  -0.6f + y, 0.0f + z,  // arriba der
                0.6f + x,  -0.8f + y, 0.0f + z,  // abajo der

                //Rectangulo 3
                0.6f + x,  0.8f + y, 0.0f + z,  // arriba izq
                0.6f + x,  -0.8f + y, 0.0f + z,  // abajo izq
                0.8f + x,  -0.8f + y, 0.0f + z,  // abajo der
                0.8f + x,  0.8f + y, 0.0f + z,  // arriba der

            };
        }


        // Índices para formar los triángulos de la letra "U"
        uint[] uIndices = {
            //Rectangulo 1
            0, 1, 3,  // First triangle (top left to internal corner)
            1, 2, 3,  // Second triangle (top half)

            //Rectangulo 2
            4, 5, 6,  // First triangle (top left to internal corner)
            4, 7, 6,  // Second triangle (top half)

            //Rectangulo 3
            8, 9, 10,  // First triangle (top left to internal corner)
            8, 11, 10  // Second triangle (top half)
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
            // Mueve la letra "U" a la izquierda/derecha con las teclas A/D
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                x -= 0.01f;  // Desplazamiento a la izquierda
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                x += 0.01f;  // Desplazamiento a la derecha
            }

            // Actualiza los vértices con la nueva posición
            float[] updatedVertices = getVertices(x,0,0);

            // Actualiza los datos del buffer con los nuevos vértices
            GL.BindBuffer(BufferTarget.ArrayBuffer, lVertexBufferObject);
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
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);


            // Configurar la letra "L"
            lVertexBufferObject = GL.GenBuffer();
            lVertexArrayObject = GL.GenVertexArray();
            lElementBufferObject = GL.GenBuffer();

            GL.BindVertexArray(lVertexArrayObject);
            GL.BindBuffer(BufferTarget.ArrayBuffer, lVertexBufferObject);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, lElementBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, getVertices(0,0,0).Length * sizeof(float), getVertices(0,0,0), BufferUsageHint.StaticDraw);
            GL.BufferData(BufferTarget.ElementArrayBuffer, uIndices.Length * sizeof(uint), uIndices, BufferUsageHint.StaticDraw);
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
            //GL.BindVertexArray(vertexArrayObject);
            //GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);


            // Dibujar la letra "L"
            GL.BindVertexArray(lVertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, uIndices.Length, DrawElementsType.UnsignedInt, 0);


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
