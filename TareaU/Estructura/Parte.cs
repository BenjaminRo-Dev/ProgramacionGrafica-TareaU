using OpenTK.Mathematics;

namespace TareaU
{
    public class Parte : ObjetoGrafico
    {
        public Dictionary<string, Cara> Caras;

        public Parte(string nombre, Dictionary<string, Cara> caras)
        {
            Nombre = nombre;
            Caras = caras;

            foreach (var cara in Caras.Values)
            {
                cara.Posicion = Posicion;
                cara.Escala = Escala;
                cara.Rotacion = Rotacion;
                cara.Cargar();
            }
        }


        public override void Dibujar(Shader shader)
        {
            foreach (var cara in Caras.Values)
            {
                cara.Dibujar(shader);
            }
        }


        public override void Rotar(Vector3 angulos, Vector3? centro = null)
        {
            Centro = centro ?? CalcularCentro();
            Rotacion = angulos;
            foreach (var cara in Caras.Values)
            {
                cara.Rotar(Rotacion, Centro);
            }
        }

        public override void Posicionar(Vector3 posicion)
        {
            Posicion = posicion;
            foreach (var cara in Caras.Values)
            {
                cara.Posicionar(Posicion);
            }
        }

        public override void Escalar(float escala, Vector3? centro = null)
        {
            Centro = centro ?? CalcularCentro();
            foreach (var cara in Caras.Values)
            {
                cara.Escalar(escala, Centro);
            }
        }

        public override Vector3 CalcularCentro()
        {
            var vertices = Caras.Values.SelectMany(c => c.Vertices.Values).ToList();
            return new Vector3(
                vertices.Average(v => v.posicion.X),
                vertices.Average(v => v.posicion.Y),
                vertices.Average(v => v.posicion.Z)
            );
        }

    }
}