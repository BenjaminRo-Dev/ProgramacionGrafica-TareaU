using OpenTK.Mathematics;

namespace TareaU
{
    public class Parte : ObjetoGrafico
    {
        public List<Cara> Caras;

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
            // CalcularCentroDeMasa();

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
            CalcularCentroDeMasa();
            Rotacion = rotacion;
            foreach (var cara in Caras)
            {
                cara.Centro = Centro;
                cara.Rotacion = Rotacion;
            }
        }

        public override void Mover(Vector3 posicion)
        {
            Posicion = posicion;
            foreach (var cara in Caras)
            {
                cara.Posicion = Posicion;
            }
        }

        public override void Escalar(Vector3 escala)
        {
            Escala = escala;
            foreach (var cara in Caras)
            {
                cara.Escala = Escala;
            }
        }

        public override void CalcularCentroDeMasa(){
            var vertices = Caras.SelectMany(c => c.Vertices).ToList();
            Centro = new Vector3(
                vertices.Average(v => v.posicion.X),
                vertices.Average(v => v.posicion.Y),
                vertices.Average(v => v.posicion.Z)
            );
        }





        public override void setPosicion(Vector3 posicion)
        {
            Posicion = posicion;
            foreach (var cara in Caras)
            {
                cara.Posicion = Posicion;
            }
        }

        public override void setEscala(Vector3 escala)
        {
            Escala = escala;
            foreach (var cara in Caras)
            {
                cara.Escala = Escala;
            }
        }

        public override void setRotacion(Vector3 rotacion)
        {
            Rotacion = rotacion;
            foreach (var cara in Caras)
            {
                cara.Rotacion = Rotacion;
            }
        }

        public override void setCentro(Vector3 centro)
        {
            Centro = centro;
            foreach (var cara in Caras)
            {
                cara.Centro = Centro;
            }
        }



    }
}