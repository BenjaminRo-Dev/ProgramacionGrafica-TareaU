using System.Diagnostics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

namespace TareaU
{
    class Game : GameWindow
    {
        Shader shader;

        private int vertexBufferObject;
        private int elementBufferObject;
        private int vertexArrayObject;

        private Matrix4 modelo;
        private Matrix4 vista;
        private Matrix4 proyeccion;


        Rectangulo rectangulo = new Rectangulo(-2, -2, 0, 4, 4, -5);


        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        // This function runs on every update frame.
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            float distancia = 0.0005f;

            if (KeyboardState.IsKeyDown(Keys.A))
                rectangulo.Mover(-distancia, 0, 0);     //izquierda

            if (KeyboardState.IsKeyDown(Keys.D))
                rectangulo.Mover(distancia, 0, 0);      // derecha

            if (KeyboardState.IsKeyDown(Keys.W))
                rectangulo.Mover(0, distancia, 0);      // arriba

            if (KeyboardState.IsKeyDown(Keys.S))
                rectangulo.Mover(0, -distancia, 0);     // abajo

            if (KeyboardState.IsKeyDown(Keys.Q))
                rectangulo.Mover(0, 0, distancia);      // adelante

            if (KeyboardState.IsKeyDown(Keys.E))
                rectangulo.Mover(0, 0, -distancia);     // atrás

            float[] updatedVertices = rectangulo.getVertices();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);

            GL.BufferData(BufferTarget.ArrayBuffer, updatedVertices.Length * sizeof(float), updatedVertices, BufferUsageHint.StaticDraw);

            base.OnUpdateFrame(e);
        }


        protected override void OnLoad()
        {   
            base.OnLoad();
            //Dibujar los vertices
            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            //1. Generar el buffer
            vertexBufferObject = GL.GenBuffer();       
            vertexArrayObject = GL.GenVertexArray();    
            elementBufferObject = GL.GenBuffer();      

            GL.BindVertexArray(vertexArrayObject);                                  
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);                
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);        



            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.BufferData(BufferTarget.ArrayBuffer, rectangulo.getVertices().Length * sizeof(float), rectangulo.getVertices(), BufferUsageHint.StaticDraw);
            GL.BufferData(BufferTarget.ElementArrayBuffer, rectangulo.getIndices().Length * sizeof(uint), rectangulo.getIndices(), BufferUsageHint.StaticDraw);

            
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            //3D:
            modelo = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.0f));    //Vista en diferente angulo
            vista = Matrix4.CreateTranslation(0.0f, 0.0f, -10.0f);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / Size.Y, 0.1f, 100.0f);



        }

        Stopwatch _timer = Stopwatch.StartNew();
        //Dibuja la escena en la pantalla
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            shader.Use();


            double timeValue = _timer.Elapsed.TotalSeconds;    
            float greenValue = (float)Math.Sin(timeValue) / 2.0f + 0.5f;
            int vertexColorLocation = GL.GetUniformLocation(shader.Handle, "ourColor");
            GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);


            GL.BindVertexArray(vertexArrayObject);      
            GL.DrawElements(PrimitiveType.Triangles, rectangulo.getIndices().Length, DrawElementsType.UnsignedInt, 0);

            //Enviar las matrices al shader:
            shader.SetMatrix4("model", modelo);
            shader.SetMatrix4("view", vista);
            shader.SetMatrix4("projection", proyeccion);


            SwapBuffers();


        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }
    }
}
