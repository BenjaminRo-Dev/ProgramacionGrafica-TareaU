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
        private List<Cara> carasU;
        private List<Parte> partesU;

        public Game(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.Enable(EnableCap.DepthTest);

            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            vista = Matrix4.CreateTranslation(0.0f, 0.0f, -40.0f);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / (float)Size.Y, 0.1f, 100.0f);
            

            Vector3 posicion = new Vector3(0, 0, 0);
            Vector3 escala = new Vector3(1, 1, 1);
            Vector3 rotacion = new Vector3(0,90,0);

            Vector3 posicionU = new Vector3(0, 0, 0);
            Vector3 escalaU = new Vector3(3,3,3);
            Vector3 rotacionU = new Vector3(0,90,0);

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

            parte = new Parte(posicion, escala, rotacion, caras);
            
            

            var verticesU = new []
            {
                //Rectangulo parado delantero
                new Vector3(-2, 0, 1),              //0
                new Vector3(-2, 4, 1),              //1
                new Vector3(-1, 4, 1),              //2
                new Vector3(-1, 0, 1),              //3

                //Rectangulo parado trasero
                new Vector3(-2, 0, -1),             //4
                new Vector3(-2, 4, -1),             //5
                new Vector3(-1, 4, -1),             //6
                new Vector3(-1, 0, -1),             //7

                //Rectangulo acostado delantero
                new Vector3(-1, 0, 1),              //8
                new Vector3(-1, 1, 1),              //9
                new Vector3(1,  1, 1),               //10
                new Vector3(1,  0, 1),               //11

                //Rectangulo acostado trasero
                new Vector3(-2, 0, -1),             //12
                new Vector3(-2, 1, -1),             //13
                new Vector3(2,  1, -1),              //14
                new Vector3(2,  0, -1),              //15

                //Rectangulo parado delantero derecho
                new Vector3(1, 0, 1),               //16
                new Vector3(1, 4, 1),               //17
                new Vector3(2, 4, 1),               //18
                new Vector3(2, 0, 1),               //19

                //Rectangulo parado trasero derecho
                new Vector3(1, 0, -1),              //20
                new Vector3(1, 4, -1),              //21
                new Vector3(2, 4, -1),              //22
                new Vector3(2, 0, -1),              //23
            };

            var carasC1 = new List<Cara>
            {
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Indigo, verticesU[0], verticesU[1], verticesU[2], verticesU[3]), // Front
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Green, verticesU[4], verticesU[5], verticesU[6], verticesU[7]), // Back
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Blue, verticesU[3], verticesU[2], verticesU[6], verticesU[7]), // Top
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Yellow, verticesU[0], verticesU[1], verticesU[5], verticesU[4]), // Bottom
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Cyan, verticesU[0], verticesU[3], verticesU[7], verticesU[4]), // Left
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Magenta, verticesU[1], verticesU[2], verticesU[6], verticesU[5]) // Right
            };

            var carasC2 = new List<Cara>
            {
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Indigo, verticesU[8], verticesU[9], verticesU[10], verticesU[11]), // Front
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Green, verticesU[12], verticesU[13], verticesU[14], verticesU[15]), // Back
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Blue, verticesU[11], verticesU[10], verticesU[14], verticesU[15]), // Top
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Yellow, verticesU[8], verticesU[9], verticesU[13], verticesU[12]), // Bottom
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Cyan, verticesU[8], verticesU[11], verticesU[15], verticesU[12]), // Left
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Magenta, verticesU[9], verticesU[10], verticesU[14], verticesU[13]) // Right
            };

            var carasC3 = new List<Cara>
            {
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Indigo, verticesU[16], verticesU[17], verticesU[18], verticesU[19]), // Front
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Green, verticesU[20], verticesU[21], verticesU[22], verticesU[23]), // Back
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Blue, verticesU[19], verticesU[18], verticesU[22], verticesU[23]), // Top
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Yellow, verticesU[16], verticesU[17], verticesU[21], verticesU[20]), // Bottom
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Cyan, verticesU[16], verticesU[19], verticesU[23], verticesU[20]), // Left
                new Cara(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color4.Magenta, verticesU[17], verticesU[18], verticesU[22], verticesU[21]) // Right
            };

            partesU = new List<Parte>
            {
                new Parte(posicionU, escalaU, rotacionU, carasC1),
                new Parte(posicionU, escalaU, rotacionU, carasC2),
                new Parte(posicionU, escalaU, rotacionU, carasC3)
            };




        
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

            foreach (var parteU in partesU)
            {
                parteU.Dibujar(shader); // Llamar al método Dibujar de la parte
            }
            

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
