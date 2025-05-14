using System.Diagnostics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace TareaU
{
    class Game : GameWindow
    {
        private Shader shader = null!;
        private Matrix4 vista, proyeccion;
        private Escenario escenario = null!;
        private ObjetoGrafico grafico;

        private Accion accion;

        private Acciones1 acciones1;

        Stopwatch tiempoGlobal = new Stopwatch();

        public Game(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.Enable(EnableCap.DepthTest);
            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            vista = Matrix4.CreateTranslation(0.0f, 0.0f, -50.0f);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / (float)Size.Y, 0.1f, 100.0f);

            escenario = new Escenario("escenario");
            grafico = escenario;

            Auxiliar.CargarObjetoJson(escenario, "letraU");
            // escenario.Objetos["letraU"].Posicionar(new Vector3(0,0,0));
            
            tiempoGlobal.Start();
            acciones1 = new Acciones1( escenario.Objetos["letraU"] );

            Vector3 destino = new Vector3(5,0,0);
            accion = new Accion(1, escenario.Objetos["letraU"].Posicion, 2, destino);
            // Console.WriteLine(let.Posicion);
            // Console.WriteLine(escenario.Objetos["let"].Posicion);

            

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            shader.Use();
            shader.SetMatrix4("vista", vista);
            shader.SetMatrix4("proyeccion", proyeccion);

            escenario.Dibujar(shader);

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            Auxiliar.Teclas(KeyboardState, escenario, grafico);

            float tFrame = (float)e.Time;
            float tiempoActual = (float) tiempoGlobal.Elapsed.TotalSeconds;
            // Console.WriteLine(tiempoActual);
            // Console.WriteLine(tFrame);
            
            // escenario.Objetos["letraU"].Posicionar(accion.Mover(tiempoActual, tFrame));
            // acciones1.ObtenerAcciones();
            foreach (var accion in acciones1.ObtenerAcciones())
            {
                escenario.Objetos["letraU"].Posicionar(accion.Mover(tiempoActual, tFrame));
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
