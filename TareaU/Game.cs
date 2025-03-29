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

        private double _time;

        List<Rectangulo> rectangulos = new List<Rectangulo>();
        Cuboide cuboide = new Cuboide();


        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }


        protected override void OnLoad()
        {   
            base.OnLoad();
            //Dibujar los vertices
            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            //1. Generar el buffer
            vertexBufferObject = GL.GenBuffer();       
            elementBufferObject = GL.GenBuffer();      
            vertexArrayObject = GL.GenVertexArray();    

            GL.BindVertexArray(vertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            //3D:
            modelo = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.0f));    //Vista en diferente angulo
            vista = Matrix4.CreateTranslation(0.0f, 0.0f, -20.0f);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / Size.Y, 0.1f, 100.0f);

            //rectangulos.Add(new Rectangulo(-2, -2, 0, 2, 2, -5));
            //rectangulos.Add(new Rectangulo(2, -2, 0, 2, 2, -5));
            //rectangulos.Add(new Rectangulo(-2, 2, 0, 3, 3, -5));

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            _time += 16.0 * e.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit);

            shader.Use();

            modelo = Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(_time));
            modelo = Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(_time));

            //DibujarRectangulos();
            cuboide.Dibujar(vertexBufferObject, elementBufferObject);

            //Enviar las matrices al shader:
            shader.SetMatrix4("model", modelo);
            shader.SetMatrix4("view", vista);
            shader.SetMatrix4("projection", proyeccion);

            SwapBuffers();

        }

        private void DibujarRectangulos()
        {
            foreach (var rectangulo in rectangulos)
            {
                rectangulo.Dibujar(vertexBufferObject, elementBufferObject);
            }
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
