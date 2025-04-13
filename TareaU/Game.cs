using System.Diagnostics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using OpenTK.Compute.OpenCL;

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
        private Escenario escenario;

        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }


        protected override void OnLoad()
        {   
            base.OnLoad();
            GL.Enable(EnableCap.DepthTest);
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


            modelo = Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(10.0f)) *
                Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(30.0f)) *
                Matrix4.CreateRotationZ((float)MathHelper.DegreesToRadians(0.00f));

            vista = Matrix4.CreateTranslation(0.0f, 0.0f, -40.0f);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / Size.Y, 0.1f, 100.0f);

            escenario = new Escenario();

            // Objeto letraU = new Objeto(new Vector3(+10, 0, 0), Vector3.Zero, new Vector3(10, 1, 1));
            Objeto letraU = new Objeto();
            letraU.AgregarParte(new Parte(
                new Vector3(-2.5f, 0, 0), // Parte inferior
                Vector3.Zero,
                new Vector3(4, 1, 1)
            ));
            letraU.AgregarParte(new Parte(
                new Vector3(-2.5f, 0, 0), // Parte izquierda
                Vector3.Zero,
                new Vector3(1, 5, 1)
            ));
            letraU.AgregarParte(new Parte(
                new Vector3(0.5f, 0, 0), // Parte derecha
                Vector3.Zero,
                new Vector3(1, 5, 1)
            ));
            
            escenario.AgregarObjeto(letraU);

            Objeto letraO = new Objeto();
            letraO.AgregarParte(new Parte(
                new Vector3(-12.5f, 0, 0), // Parte inferior
                Vector3.Zero,
                new Vector3(4, 1, 1)
            ));
            letraO.AgregarParte(new Parte(
                new Vector3(-12.5f, 5, 0), // Parte superior
                Vector3.Zero,
                new Vector3(4, 1, 1)
            ));
            letraO.AgregarParte(new Parte(
                new Vector3(-12.5f, 0, 0), // Parte izquierda
                Vector3.Zero,
                new Vector3(1, 5, 1)
            ));
            letraO.AgregarParte(new Parte(
                new Vector3(-9.5f, 0, 0), // Parte derecha
                Vector3.Zero,
                new Vector3(1, 5, 1)
            ));

            escenario.AgregarObjeto(letraO);

            Objeto letraUGen = Objeto.CrearObjetoGenerico(
                new Vector3(+10, 0, 0), // Posición
                Vector3.Zero,         // Rotación
                new Vector3(5, 5, 5)  // Escala
            );
            escenario.AgregarObjeto(letraUGen);
            
            

            // escenario.AgregarObjeto(new LetraU(new Vector3(10, 0, 0), Vector3.Zero, new Vector3(5, 5, 5)));
            // escenario.AgregarObjeto(new LetraU(new Vector3(-10, 0, 0), Vector3.Zero, new Vector3(5, 5, 5)));
            // escenario.AgregarObjeto(new Objeto(new Vector3(-10, 0, 0), Vector3.Zero, new Vector3(5, 5, 5)));
            

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            _time += 20.0 * e.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            shader.Use();

            // modelo = Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(_time));
            modelo = Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(_time));

            escenario.Dibujar(vertexBufferObject, elementBufferObject);

            //Enviar las matrices al shader:
            shader.SetMatrix4("model", modelo);
            shader.SetMatrix4("view", vista);
            shader.SetMatrix4("projection", proyeccion);

            SwapBuffers();

        }

        

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // Actualizar el escenario
            escenario.Actualizar(e.Time);
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
