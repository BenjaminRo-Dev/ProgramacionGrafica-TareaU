using OpenTK.Mathematics;

namespace TareaU
{
    public class Parte : ObjetoGrafico
    {
        List<Cara> Caras;


        public Parte(Vector3 posicion, Vector3 escala, Vector3 rotacion, List<Cara> caras)
            : base(posicion, escala, rotacion)
        {
            Caras = caras;

            foreach (var cara in Caras)
            {
                cara.Posicion = Posicion;
                cara.Escala = Escala;
                cara.Rotacion = Rotacion;
                cara.Cargar();
            }

        }



        public override void Dibujar(Shader shader)
        {
            // Aplicar la transformación de la parte
            Matrix4 modelo = Matrix4.CreateScale(Escala) *
                             Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Rotacion.X)) *
                             Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Rotacion.Y)) *
                             Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Rotacion.Z)) *
                             Matrix4.CreateTranslation(Posicion);


            shader.SetMatrix4("modelo", modelo); // Enviar la matriz de modelo al shader

            // Dibujar todas las caras de la parte foreach (var cara in caras)
            foreach (var cara in Caras){
                cara.Dibujar(shader);
            }
           
        }

        public override void Dibujar()
        {
            // Lógica para dibujar la parte (si es necesario)
        }

        public override void Actualizar(double tiempo)
        {
            // Lógica para actualizar la parte (si es necesario)
        }
    }
}