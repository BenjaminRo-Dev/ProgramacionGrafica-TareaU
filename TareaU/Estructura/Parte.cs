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
            foreach (var cara in Caras){
                cara.Dibujar(shader);
            }
        }

        public override void Actualizar()
        {
            foreach (var cara in Caras)
            {
                cara.Posicion = Posicion;
                cara.Escala = Escala;
                cara.Rotacion = Rotacion;
            }
        }

        public override void Rotar(Vector3 rotacion)
        {
            this.Rotacion = rotacion;
            foreach (var cara in Caras)
            {
                cara.Rotacion = Rotacion;
            }
        }

    }
}