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

        public Game(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.Enable(EnableCap.DepthTest);
            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            vista = Matrix4.CreateTranslation(0.0f, 0.0f, -60.0f);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / (float)Size.Y, 0.1f, 100.0f);

            escenario = new Escenario("escenario");
            grafico = escenario;

            Auxiliar.CargarObjetoJson(escenario, "letraU");

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
