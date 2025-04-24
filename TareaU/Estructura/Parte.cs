using OpenTK.Mathematics;

namespace TareaU
{
    public class Parte : ObjetoGrafico
    {
        public Dictionary<string, Cara> Caras;

        public Parte(string nombre, Vector3 posicion, Vector3 escala, Vector3 rotacion, Dictionary<string, Cara> caras)
            : base(posicion, escala, rotacion)
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

        public override void Actualizar()
        {
            foreach (var cara in Caras.Values)
            {
                cara.Posicion = Posicion;
                cara.Escala = Escala;
                cara.Rotacion = Rotacion;
            }
        }

        public override void Rotar(Vector3 angulos, Vector3 centro)
        {
            Centro = centro;
            Rotacion = angulos;
            foreach (var cara in Caras.Values)
            {
                cara.Rotar(Rotacion, Centro);
            }
        }

        public void Rotar2(Vector3 angulos, Vector3? centro = null)
        {
            foreach (var cara in Caras.Values)
            {
                cara.Rotar2(angulos, centro);
                // cara.Rotar(angulos, (Vector3)centro);
            }
        }

        public void SetRotacion(Vector3 angulos)
        {
            Centro = CalcularCentro();
            Rotacion = angulos;
            foreach (var cara in Caras.Values)
            {
                cara.Rotacion = Rotacion;

            }
        }

        public override void Posicionar(Vector3 posicion)
        {
            Posicion = posicion;
            foreach (var cara in Caras.Values)
            {
                cara.Posicion = Posicion;
            }
        }

        public override void Escalar(Vector3 escala)
        {
            Escala = escala;
            foreach (var cara in Caras.Values)
            {
                cara.Escala = Escala;
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