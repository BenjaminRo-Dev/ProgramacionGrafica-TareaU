using System.Diagnostics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using TareaU.Animaciones.Datos;

namespace TareaU
{
    class Game : GameWindow
    {
        private Shader shader = null!;
        private Matrix4 vista, proyeccion;
        private Escenario escenario = null!;
        private ObjetoGrafico grafico;
        Ejecutor ejecutor;
        Stopwatch tiempoGlobal = new Stopwatch();

        public Game(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.Enable(EnableCap.DepthTest);
            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            // Posicionar la cámara en el cielo mirando hacia abajo
            Vector3 posicionCamara = new Vector3(0.0f, 50.0f, 0.0f); // Posición elevada
            Vector3 objetivo = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 arriba = new Vector3(0.0f, 0.0f, -1.0f);

            vista = Matrix4.LookAt(posicionCamara, objetivo, arriba);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / (float)Size.Y, 0.1f, 100.0f);

            // vista = Matrix4.CreateTranslation(0.0f, 0.0f, -50.0f);
            // proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / (float)Size.Y, 0.1f, 100.0f);

            escenario = new Escenario("escenario");
            grafico = escenario;

            // Auxiliar.CargarObjetoJson(escenario, "letraU");
            Objeto pista = new Objeto("Pista", Pista.partesU());
            Objeto auto1 = new Objeto("Auto1", Auto.partesU());
            Objeto auto2 = new Objeto("Auto2", Auto.partesU());

            auto1.Posicionar(new Vector3(11, 1, 10));
            auto1.Rotar(new Vector3(0,90,0));

            auto2.Posicionar(new Vector3(14, 1, 10));
            auto2.Rotar(new Vector3(0,90,0));

            escenario.AgregarObjeto(pista);
            escenario.AgregarObjeto(auto1);
            escenario.AgregarObjeto(auto2);
            
            
            //Cargar datos animaciones
            tiempoGlobal.Start();
    
            ejecutor = new Ejecutor(Grabacion.GetEscena(auto1, auto2));
            Task.Run(async () => await ejecutor.Iniciar());

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            shader.Use();
            shader.SetMatrix4("vista", vista);
            shader.SetMatrix4("proyeccion", proyeccion);

            escenario.Dibujar(shader);

            float tFrame = (float)e.Time;
            float tiempoActual = (float) tiempoGlobal.Elapsed.TotalSeconds;
            ejecutor.ActualizarTiempos(tiempoActual, tFrame);

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            Auxiliar.Teclas(KeyboardState, escenario, grafico);
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
