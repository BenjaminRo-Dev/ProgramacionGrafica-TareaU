using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace TareaU
{
    class Game : GameWindow
    {
        private Shader shader;
        private Matrix4 vista;
        private Matrix4 proyeccion;
        private Objeto letraU;
        private Objeto robot;
        private Escenario escenario;
        public Game(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.Enable(EnableCap.DepthTest);

            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            vista = Matrix4.CreateTranslation(0.0f, 0.0f, -40.0f);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / (float)Size.Y, 0.1f, 100.0f);

            escenario = new Escenario();

            robot = JsonLoader.Cargar("../../../datos/robot.json");
            letraU = JsonLoader.Cargar("../../../datos/letraU.json");

            escenario.AgregarObjeto(letraU);
            escenario.AgregarObjeto(robot);

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            shader.Use();
 
            shader.SetMatrix4("vista", vista);
            shader.SetMatrix4("proyeccion", proyeccion);

            // letraU.Rotacion = new Vector3(45, 45, 90);
            // letraU.Actualizar();
            
            // letraU.Partes[0].Rotacion = new Vector3(180, 0, 0);
            // letraU.Partes[0].Actualizar();
            robot.Posicion = new Vector3(10, 10, 0);
            robot.Rotacion = new Vector3(45, 45, 0);
            robot.Actualizar();

            escenario.Rotar(new Vector3(180, 0, 0));

            escenario.Dibujar(shader);

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            // objetoCargado.Rotacion += new Vector3(0,45,0);
            foreach (var objeto in escenario.Objetos)
            {
                objeto.Actualizar();
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
            // cara.Liberar(); // Liberar los recursos de la cara
            // shader.Dispose(); // Liberar los recursos del shader
        }
    }
}
