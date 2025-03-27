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

        private int vertexBufferObject;    //Bufer para guardar los vertices
        private int elementBufferObject;   //Bufer para guardar los indices de los vertices (que forman objetos)
        private int vertexArrayObject;     //Arreglo de vertices

        private Matrix4 modelo;
        private Matrix4 vista;
        private Matrix4 proyeccion;


        LetraU u = new LetraU(0, 0, 0, 4, 4, 0);


        // A simple constructor to let us set properties like window size, title, FPS, etc. on the window.
        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        // This function runs on every update frame.
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Ajusta el valor de desplazamiento para que la letra se mueva más lentamente
            float moveSpeed = 0.0005f;  // Reducido el valor de desplazamiento para que sea más suave

            if (KeyboardState.IsKeyDown(Keys.A))
                u.x -= moveSpeed;  // Desplazamiento a la izquierda
            
            if (KeyboardState.IsKeyDown(Keys.D))
                u.x += moveSpeed;  // Desplazamiento a la derecha
            
            if (KeyboardState.IsKeyDown(Keys.W))
                u.y += moveSpeed;  // Desplazamiento a arriba
            
            if (KeyboardState.IsKeyDown(Keys.S))
                u.y -= moveSpeed;  // Desplazamiento a abajo

            if (KeyboardState.IsKeyDown(Keys.Q))
                u.z += moveSpeed;  // Desplazamiento hacia adelante

            if (KeyboardState.IsKeyDown(Keys.E))
                u.z -= moveSpeed;  // Desplazamiento hacia atrás


            // Actualiza los vértices con la nueva posición
            float[] updatedVertices = u.getVertices(u.x, u.y, u.z);

            // Actualiza los datos del buffer con los nuevos vértices
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);//Vincula o enlaza el bufer de los nuevos vertices a los actuales
            //Actualiza los datos del bufer con los nuevos vertices:
            //          bufer que contiene los vertices, tamaño de los vertices, puntero a los vertices, modo de uso: (define 1 vez, se utiliza muchas veces)
            GL.BufferData(BufferTarget.ArrayBuffer, updatedVertices.Length * sizeof(float), updatedVertices, BufferUsageHint.StaticDraw); //

            //Ejecutar actualización de ventana
            base.OnUpdateFrame(e);
        }




        //Esta funcion se ejecuta cuando se carga la ventana
        protected override void OnLoad()
        {   
            base.OnLoad();
            //Dibujar los vertices
            shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");

            //1. Generar el buffer
            vertexBufferObject = GL.GenBuffer();        //Coordenadas del bufer de vertices
            vertexArrayObject = GL.GenVertexArray();    //Arreglo de vertices
            elementBufferObject = GL.GenBuffer();       //Coordenadas de los indices de los vertices

            //2. Vincular los buferes para que se puedan utilizar (en las siguientes operaciones) | Alistar los buferes
            GL.BindVertexArray(vertexArrayObject);                                      //vincular o alistar el vertex array object
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);                //vincular o alistar el buffer de vertices
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);        //vincular o alistar el buffer de elementos


            //3. Cargar los vertices en el buffer

            //Definiendo la forma de los vertices
            //0=indice del atributo del vertice, 3=xyz, tipo de dato (float), false= no normalizado, distancia entre atributos del vertice, 0= desplazamiento en bytes del primer atributo
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0); //Habilita el atributo del vertice en la ubicación 0

            //Cargar los datos de los vertices en el VBO (bufer de vertices)
            GL.BufferData(BufferTarget.ArrayBuffer, u.getVertices(0,0,0).Length * sizeof(float), u.getVertices(0,0,0), BufferUsageHint.StaticDraw);
            //Cargar los indices de los vertices en el EBO (bufer de elementos)
            GL.BufferData(BufferTarget.ElementArrayBuffer, u.getIndices().Length * sizeof(uint), u.getIndices(), BufferUsageHint.StaticDraw);

            //Colores de los vertices: 1 indice del atributo de vertice, 3=rgb, tipo de dato (float), false= no normalizado, distancia entre atributos del vertice, 3= desplazamiento en bytes del primer atributo
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);//Habilita el atributo del vertice en la ubicación 1

            //3D:
            modelo = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(55.0f));
            vista = Matrix4.CreateTranslation(0.0f, 0.0f, -10.0f);
            proyeccion = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / Size.Y, 0.1f, 100.0f);



        }

        Stopwatch _timer = Stopwatch.StartNew();
        //Dibuja la escena en la pantalla
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);       //Limpia el fotograma anterior para redibujar el nuevo

            //Activa el shader creado en OnLoad (para poder dibujar los objetos luego)
            shader.Use();


            double timeValue = _timer.Elapsed.TotalSeconds;     //Obtener el tiempo transcurrido desde que se inicializó el stopwatch
            float greenValue = (float)Math.Sin(timeValue) / 2.0f + 0.5f;            //Calcula el valor verde que varia con el tiempo utilizando seno
            int vertexColorLocation = GL.GetUniformLocation(shader.Handle, "ourColor");         //Obtiene la ubicación de la variable ourColor en el shader
            GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);         //Establece el color de la variable ourColor en el shader


            // Dibujar la letra
            GL.BindVertexArray(vertexArrayObject);      //Vincula o enlaza el vertex array object (creado en onload) para poder dibujar los vertices
            GL.DrawElements(PrimitiveType.Triangles, u.getIndices().Length, DrawElementsType.UnsignedInt, 0);   //Dibuja los elementos de los vertices

            //Enviar las matrices al shader:
            shader.SetMatrix4("model", modelo);
            shader.SetMatrix4("view", vista);
            shader.SetMatrix4("projection", proyeccion);



            SwapBuffers();      //Intercambia los buffers para mostrar el nuevo fotograma


        }

        //OnFramebufferResize se ejecuta cada vez que se redimensiona la ventana
        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        //OnUnload se ejecuta cuando se cierra la ventana
        protected override void OnUnload()
        {
            base.OnUnload();
            //GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(_vertexBufferObject);
            //GL.DeleteProgram(shader.Handle);
            //shader.Dispose();
        }
    }
}
