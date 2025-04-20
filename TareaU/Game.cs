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
        private Objeto letraU2;
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
            letraU2 = JsonLoader.Cargar("../../../datos/letraU.json");

            letraU.setPosicion(new Vector3(0, 0, 0));
            letraU2.setPosicion(new Vector3(-10, -10, 0));

            // robot.CalcularCentroDeMasa();
            // letraU.CalcularCentroDeMasa();

            escenario.AgregarObjeto(letraU);
            escenario.AgregarObjeto(letraU2);
            // escenario.AgregarObjeto(robot);


        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            shader.Use();
 
            shader.SetMatrix4("vista", vista);
            shader.SetMatrix4("proyeccion", proyeccion);

            float velocidadRotacion = 45.0f; // Velocidad de rotación en grados por segundo


            // letraU.Rotar(new Vector3(letraU.Rotacion + new Vector3(0, velocidadRotacion * (float)e.Time, 0)));
            // letraU.Rotar(new Vector3(letraU.Rotacion + new Vector3(0, 0, velocidadRotacion * (float)e.Time)));
            letraU.Rotar(new Vector3(letraU.Rotacion + new Vector3(velocidadRotacion * (float)e.Time, 0, 0)));
            
                // letraU.Partes[0].Rotar(letraU.Partes[0].Rotacion + new Vector3(0, velocidadRotacion * (float)e.Time, 0));
                // letraU.Partes[0].Rotar(letraU.Partes[0].Rotacion + new Vector3(velocidadRotacion * (float)e.Time, 0, 0));
                // letraU.Partes[0].Rotar(letraU.Partes[0].Rotacion + new Vector3(0, 0, velocidadRotacion * (float)e.Time));

            
            

            escenario.Rotar(new Vector3(escenario.Rotacion + new Vector3(0, velocidadRotacion * (float)e.Time, 0)));
            // escenario.Rotar(new Vector3(escenario.Rotacion + new Vector3(0, 0, velocidadRotacion * (float)e.Time)));
            // escenario.Rotar(new Vector3(escenario.Rotacion + new Vector3(velocidadRotacion * (float)e.Time, 0, 0)));
            
            // escenario.Escalar(new Vector3(0.5f, 0.5f, 0.5f));
            // escenario.Mover(new Vector3(-10, 5, 0));
            // escenario.Actualizar();
            escenario.Dibujar(shader);
            

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
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
