using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace TareaU
{
    class Game : GameWindow
    {
        private Shader shader = null!;
        private Matrix4 vista;
        private Matrix4 proyeccion;
        private Objeto letraU = null!;
        private Objeto letraU2 = null!;
        private Objeto letraU3 = null!;
        private Cara cara = null!;
        private Cara cara2 = null!;
        private Escenario escenario = null!;
        public Game(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.Enable(EnableCap.DepthTest);

            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            vista = Matrix4.CreateTranslation(0.0f, 0.0f, -60.0f);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / (float)Size.Y, 0.1f, 100.0f);

            escenario = new Escenario();

            letraU = new Objeto("letraU", Vector3.Zero, Vector3.One, Vector3.Zero, partesU());
            letraU2 = new Objeto("letraU2", Vector3.Zero, Vector3.One, Vector3.Zero, partesU2());
            // letraU3 = new Objeto("letraU3", Vector3.Zero, Vector3.One, Vector3.Zero, partesU());

            // letraU = JsonLoader.Cargar("../../../datos/letraU.json");
            // letraU2 = JsonLoader.Cargar("../../../datos/letraU.json");
            // letraU3 = JsonLoader.Cargar("../../../datos/letraU.json");

            escenario.AgregarObjeto(letraU);
            escenario.AgregarObjeto(letraU2);
            // escenario.AgregarObjeto(letraU3);

            escenario.Objetos["letraU"].Posicionar(new Vector3(0, 0, 0));
            escenario.Objetos["letraU2"].Posicionar(new Vector3(0, 0, 0));
            // escenario.Objetos["letraU3"].Posicionar(new Vector3(10, 10, 0));

            


            // letraU.Posicionar(new Vector3(0, 0, 0));
            // letraU2.Posicionar(new Vector3(-20, 0, 0));
            // letraU3.Posicionar(new Vector3(10, 10, 0));

            

            centroParte1 = letraU.Partes["parte1"].CalcularCentro();

        }

        Vector3 centroParte1;

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
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            //Velocidad:
            float velocidad = 0.1f;

            // Rotar todo el escenario con flechas
            if (KeyboardState.IsKeyDown(Keys.Up))
                escenario.Rotar3(velocidad * new Vector3(-1, 0, 0));
                // escenario.Rotar(velocidad * new Vector3(-1,0,0), Vector3.Zero);
                // escenario.Rotar(velocidad * new Vector3(-1,0,0), Vector3.Zero);
            if (KeyboardState.IsKeyDown(Keys.Down))
                escenario.Rotar3(velocidad * new Vector3(1, 0, 0));
                // escenario.Rotar2(velocidad * new Vector3(1,0,0), Vector3.Zero);
                // escenario.Rotar(velocidad * new Vector3(1,0,0), Vector3.Zero);
            if (KeyboardState.IsKeyDown(Keys.Left))
                escenario.Rotar3(velocidad * new Vector3(0, 1, 0));
                // escenario.Rotar2(velocidad * new Vector3(0,1,0), Vector3.Zero);
                // escenario.Rotar(velocidad * new Vector3(0,1,0), Vector3.Zero);

            if (KeyboardState.IsKeyDown(Keys.Right))
                escenario.Rotar3(velocidad * new Vector3(0, -1, 0));
                // escenario.Rotar2(velocidad * new Vector3(0,-1,0), Vector3.Zero);
                // escenario.Rotar(velocidad * new Vector3(0,-1,0), Vector3.Zero);
            
            if (KeyboardState.IsKeyDown(Keys.W))
                // letraU2.Rotar2(velocidad * new Vector3(-1, 0, 0));
                letraU2.Rotar2(velocidad * new Vector3(-1, 0, 0), letraU2.CalcularCentro());
                // letraU2.SetRotacion(velocidad * new Vector3(-1, 0, 0), letraU2.CalcularCentro());

            if (KeyboardState.IsKeyDown(Keys.S))
                // letraU2.Rotar2(velocidad * new Vector3(1, 0, 0));
                letraU2.Rotar2(velocidad * new Vector3(1, 0, 0), letraU2.CalcularCentro());
                // letraU2.SetRotacion(velocidad * new Vector3(1, 0, 0), letraU2.Posicion);

            if (KeyboardState.IsKeyDown(Keys.A))
                // letraU2.Rotar2(velocidad * new Vector3(0, -1, 0));
                letraU2.Rotar2(velocidad * new Vector3(0, -1, 0), letraU2.CalcularCentro());
                // letraU2.SetRotacion(velocidad * new Vector3(0, -1, 0), letraU2.CalcularCentro());
                // letraU2.Rotar(velocidad * new Vector3(0, -1, 0), letraU2.Posicion);

            if (KeyboardState.IsKeyDown(Keys.D))
                // letraU2.Rotar2(velocidad * new Vector3(0, 1, 0));
                letraU2.Rotar2(velocidad * new Vector3(0, 1, 0), letraU2.CalcularCentro());
                // letraU2.SetRotacion(velocidad * new Vector3(0, 1, 0), letraU2.CalcularCentro());
            // if (KeyboardState.IsKeyDown(Keys.Q))
            //     letraU2.Rotar(velocidad * new Vector3(0, 0, -1), letraU2.Posicion);
            // if (KeyboardState.IsKeyDown(Keys.E))
            //     letraU2.Rotar(velocidad * new Vector3(0, 0, 1), letraU2.Posicion);
                
            // if (KeyboardState.IsKeyDown(Keys.P))
            //     // letraU2.Partes["parte1"].Rotar(velocidad * new Vector3(0, 0, -1), centroParte1);
            //     escenario.Objetos["letraU2"].Partes["parte1"].Rotar(velocidad * new Vector3(0, 0, -1), letraU2.Partes["parte1"].Posicion);
            // if (KeyboardState.IsKeyDown(Keys.O))
            //     letraU2.Partes["parte1"].Rotar(velocidad * new Vector3(0, 0, 1), letraU2.Partes["parte1"].Posicion);
            
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

        private Vector3[] verticesU()
        {
            return new[]
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
        }

        private Dictionary<string, Cara> carasParte1()
        {
            var vertices = verticesU();

            return new Dictionary<string, Cara>
            {
            { "delantera", new Cara(Color4.Indigo, vertices[0], vertices[1], vertices[2], vertices[3]) }, // Indigo
            { "trasera", new Cara(Color4.Green, vertices[4], vertices[5], vertices[6], vertices[7]) }, // Green
            { "superior", new Cara(Color4.Blue, vertices[3], vertices[2], vertices[6], vertices[7]) }, // Blue
            { "inferior", new Cara(Color4.Yellow, vertices[0], vertices[1], vertices[5], vertices[4]) }, // Yellow
            { "lateralIzquierdo", new Cara(Color4.Cyan, vertices[0], vertices[3], vertices[7], vertices[4]) }, // Cyan
            { "lateralDerecho", new Cara(Color4.Magenta, vertices[1], vertices[2], vertices[6], vertices[5]) } // Magenta
            };
        }

        private Dictionary<string, Cara> carasParte2()
        {
            var vertices = verticesU();

            return new Dictionary<string, Cara>
            {
                { "delantera", new Cara(Color4.Indigo, vertices[8], vertices[9], vertices[10], vertices[11]) }, // Indigo
                { "trasera", new Cara(Color4.Green, vertices[12], vertices[13], vertices[14], vertices[15]) }, // Green
                { "superior", new Cara(Color4.Blue, vertices[11], vertices[10], vertices[14], vertices[15]) }, // Blue
                { "inferior", new Cara(Color4.Yellow, vertices[8], vertices[9], vertices[13], vertices[12]) }, // Yellow
                { "lateralIzquierdo", new Cara(Color4.Cyan, vertices[8], vertices[11], vertices[15], vertices[12]) }, // Cyan
                { "lateralDerecho", new Cara(Color4.Magenta, vertices[9], vertices[10], vertices[14], vertices[13]) } // Magenta
            };
        }

        private Dictionary<string, Cara> carasParte3()
        {
            var vertices = verticesU();

            return new Dictionary<string, Cara>
            {
            { "delantera", new Cara(Color4.Indigo, vertices[16], vertices[17], vertices[18], vertices[19]) }, // Indigo
            { "trasera", new Cara(Color4.Green, vertices[20], vertices[21], vertices[22], vertices[23]) }, // Green
            { "superior", new Cara(Color4.Blue, vertices[19], vertices[18], vertices[22], vertices[23]) }, // Blue
            { "inferior", new Cara(Color4.Yellow, vertices[16], vertices[17], vertices[21], vertices[20]) }, // Yellow
            { "lateralIzquierdo", new Cara(Color4.Cyan, vertices[16], vertices[19], vertices[23], vertices[20]) }, // Cyan
            { "lateralDerecho", new Cara(Color4.Magenta, vertices[17], vertices[18], vertices[22], vertices[21]) } // Magenta
            };
        }

        private Dictionary<string, Parte> partesU()
        {
            var partes = new Dictionary<string, Parte>
            {
                { "parte1", new Parte("parte1", Vector3.Zero, Vector3.One, Vector3.Zero, carasParte1()) },
                { "parte2", new Parte("parte2", Vector3.Zero, Vector3.One, Vector3.Zero, carasParte2()) },
                { "parte3", new Parte("parte3", Vector3.Zero, Vector3.One, Vector3.Zero, carasParte3()) }
            };

            return partes;
        }

        private Vector3[] verticesU2()
        {
            return new[]
            {
            //Rectangulo parado delantero
            new Vector3(8, 10, 1),              //0
            new Vector3(8, 14, 1),              //1
            new Vector3(9, 14, 1),              //2
            new Vector3(9, 10, 1),              //3

            //Rectangulo parado trasero
            new Vector3(8, 10, -1),             //4
            new Vector3(8, 14, -1),             //5
            new Vector3(9, 14, -1),             //6
            new Vector3(9, 10, -1),             //7

            //Rectangulo acostado delantero
            new Vector3(9, 10, 1),              //8
            new Vector3(9, 11, 1),              //9
            new Vector3(11, 11, 1),             //10
            new Vector3(11, 10, 1),             //11

            //Rectangulo acostado trasero
            new Vector3(8, 10, -1),             //12
            new Vector3(8, 11, -1),             //13
            new Vector3(12, 11, -1),            //14
            new Vector3(12, 10, -1),            //15

            //Rectangulo parado delantero derecho
            new Vector3(11, 10, 1),             //16
            new Vector3(11, 14, 1),             //17
            new Vector3(12, 14, 1),             //18
            new Vector3(12, 10, 1),             //19

            //Rectangulo parado trasero derecho
            new Vector3(11, 10, -1),            //20
            new Vector3(11, 14, -1),            //21
            new Vector3(12, 14, -1),            //22
            new Vector3(12, 10, -1),            //23
            };
        }

        private Dictionary<string, Cara> carasParte21()
        {
            var vertices = verticesU2();

            return new Dictionary<string, Cara>
            {
            { "delantera", new Cara(Color4.Indigo, vertices[0], vertices[1], vertices[2], vertices[3]) }, // Indigo
            { "trasera", new Cara(Color4.Green, vertices[4], vertices[5], vertices[6], vertices[7]) }, // Green
            { "superior", new Cara(Color4.Blue, vertices[3], vertices[2], vertices[6], vertices[7]) }, // Blue
            { "inferior", new Cara(Color4.Yellow, vertices[0], vertices[1], vertices[5], vertices[4]) }, // Yellow
            { "lateralIzquierdo", new Cara(Color4.Cyan, vertices[0], vertices[3], vertices[7], vertices[4]) }, // Cyan
            { "lateralDerecho", new Cara(Color4.Magenta, vertices[1], vertices[2], vertices[6], vertices[5]) } // Magenta
            };
        }

        private Dictionary<string, Cara> carasParte22()
        {
            var vertices = verticesU2();

            return new Dictionary<string, Cara>
            {
                { "delantera", new Cara(Color4.Indigo, vertices[8], vertices[9], vertices[10], vertices[11]) }, // Indigo
                { "trasera", new Cara(Color4.Green, vertices[12], vertices[13], vertices[14], vertices[15]) }, // Green
                { "superior", new Cara(Color4.Blue, vertices[11], vertices[10], vertices[14], vertices[15]) }, // Blue
                { "inferior", new Cara(Color4.Yellow, vertices[8], vertices[9], vertices[13], vertices[12]) }, // Yellow
                { "lateralIzquierdo", new Cara(Color4.Cyan, vertices[8], vertices[11], vertices[15], vertices[12]) }, // Cyan
                { "lateralDerecho", new Cara(Color4.Magenta, vertices[9], vertices[10], vertices[14], vertices[13]) } // Magenta
            };
        }

        private Dictionary<string, Cara> carasParte23()
        {
            var vertices = verticesU2();

            return new Dictionary<string, Cara>
            {
            { "delantera", new Cara(Color4.Indigo, vertices[16], vertices[17], vertices[18], vertices[19]) }, // Indigo
            { "trasera", new Cara(Color4.Green, vertices[20], vertices[21], vertices[22], vertices[23]) }, // Green
            { "superior", new Cara(Color4.Blue, vertices[19], vertices[18], vertices[22], vertices[23]) }, // Blue
            { "inferior", new Cara(Color4.Yellow, vertices[16], vertices[17], vertices[21], vertices[20]) }, // Yellow
            { "lateralIzquierdo", new Cara(Color4.Cyan, vertices[16], vertices[19], vertices[23], vertices[20]) }, // Cyan
            { "lateralDerecho", new Cara(Color4.Magenta, vertices[17], vertices[18], vertices[22], vertices[21]) } // Magenta
            };
        }

        private Dictionary<string, Parte> partesU2()
        {
            var partes = new Dictionary<string, Parte>
            {
                { "parte1", new Parte("parte1", Vector3.Zero, Vector3.One, Vector3.Zero, carasParte21()) },
                { "parte2", new Parte("parte2", Vector3.Zero, Vector3.One, Vector3.Zero, carasParte22()) },
                { "parte3", new Parte("parte3", Vector3.Zero, Vector3.One, Vector3.Zero, carasParte23()) }
            };

            return partes;
        }


    }
}
