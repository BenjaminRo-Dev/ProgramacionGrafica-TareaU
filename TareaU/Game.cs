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

        private Cara cara;
        private Parte parte;

        public Game(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.Enable(EnableCap.DepthTest);

            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            vista = Matrix4.CreateTranslation(0.0f, 0.0f, -40.0f);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / (float)Size.Y, 0.1f, 100.0f);
            

            Vector3 posicion = new Vector3(+10, +10, 0);
            Vector3 escala = new Vector3(2, 2, 2);
            Vector3 rotacion = new Vector3(0,45,0);

            // OpenTK.Mathematics.Vector3 p1 = new OpenTK.Mathematics.Vector3(-1, -1, 0);
            // OpenTK.Mathematics.Vector3 p4 = new OpenTK.Mathematics.Vector3(-1, 1, 0);
            // OpenTK.Mathematics.Vector3 p3 = new OpenTK.Mathematics.Vector3(1, 1, 0);
            // OpenTK.Mathematics.Vector3 p2 = new OpenTK.Mathematics.Vector3(1, -1, 0);

            // cara = new Cara(posicion, escala,Color4.Red, p1, p2, p3, p4);
            // // cara.Rotacion = new Vector3(0, 0, 0); // Ahora la rotación se maneja desde la clase Cara
            // cara.Cargar();

            var vertices = new[]
            {
                new Vector3(-1, -1, -1), // 0
                new Vector3(1, -1, -1),  // 1
                new Vector3(1, 1, -1),   // 2
                new Vector3(-1, 1, -1),  // 3
                new Vector3(-1, -1, 1),  // 4
                new Vector3(1, -1, 1),   // 5
                new Vector3(1, 1, 1),    // 6
                new Vector3(-1, 1, 1)    // 7
            };

            var caras = new List<Cara>
            {
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Indigo, vertices[0], vertices[1], vertices[2], vertices[3]), // Front
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Green, vertices[4], vertices[5], vertices[6], vertices[7]), // Back
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Blue, vertices[3], vertices[2], vertices[6], vertices[7]), // Top
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Yellow, vertices[0], vertices[1], vertices[5], vertices[4]), // Bottom
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Cyan, vertices[0], vertices[3], vertices[7], vertices[4]), // Left
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Magenta, vertices[1], vertices[2], vertices[6], vertices[5]) // Right
            };

            // foreach (var cara in caras)
            // {
            //     cara.Cargar();
            // }


            parte = new Parte(posicion, escala, rotacion, caras);
            // parte.Dibujar(shader); // Llamar al método Dibujar de la parte
        
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            shader.Use();
 
            shader.SetMatrix4("vista", vista);
            shader.SetMatrix4("proyeccion", proyeccion);


            // cara.Dibujar(shader);
            parte.Dibujar(shader); // Llamar al método Dibujar de la parte
            

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // parte.Rotacion += new Vector3(0, 1, 0); // Rotar la parte en el eje Y
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
