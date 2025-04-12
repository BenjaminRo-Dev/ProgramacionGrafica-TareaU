using OpenTK.Mathematics;

namespace TareaU
{
    class Parte : ObjetoGrafico
    {
        List<Cara> caras;

        public Parte(Vector3 posicion, Vector3 rotacion, Vector3 escala)
            : base(posicion, rotacion, escala)
        {
            caras = new List<Cara>();

            // Generar las 6 caras del cuboide
            // Cara frontal
            caras.Add(new Cara(
                posicion + new Vector3(0, 0, escala.Z / 2), // Posición relativa
                new Vector3(escala.X, escala.Y, 0), // Tamaño
                new Vector3(1, 0, 0) // Color rojo
            ));

            // Cara trasera
            Cara caraTrasera = new Cara(
                posicion + new Vector3(0, 0, -escala.Z / 2), // Posición relativa
                new Vector3(escala.X, escala.Y, 0), // Tamaño
                new Vector3(0, 1, 0) // Color verde
            );
            caraTrasera.Rotar(new Vector3(0, 0, 0)); // Rotar 0 grados en Y
            caras.Add(caraTrasera);


            // Cara superior
            Cara caraSuperior = new Cara(
                posicion + new Vector3(0, escala.Y, escala.Z/2), // Posición relativa
                new Vector3(escala.X, escala.Z, 0), // Tamaño
                new Vector3(0, 0, 1) // Color azul
            );
            caraSuperior.Rotar(new Vector3(-90, 0, 0)); // Rotar -90 grados en X
            caras.Add(caraSuperior);

            // Cara inferior
            Cara caraInferior = new Cara(
                posicion + new Vector3(0, 0, -escala.Z/2), // Posición relativa
                new Vector3(escala.X, escala.Z, 0), // Tamaño
                new Vector3(1, 1, 0) // Color amarillo
            );
            caraInferior.Rotar(new Vector3(90, 0, 0)); // Rotar 90 grados en X
            caras.Add(caraInferior);

            // Cara izquierda
            Cara caraIzquierda = new Cara(
                posicion + new Vector3(escala.X, 0, escala.Z/2), // Posición relativa
                new Vector3(escala.Z, escala.Y, 0), // Tamaño
                new Vector3(1, 0, 1) // Color magenta
            );
            caraIzquierda.Rotar(new Vector3(0, 90, 0)); // Rotar 90 grados en Y
            caras.Add(caraIzquierda);

            // Cara derecha
            Cara caraDerecha = new Cara(
                posicion + new Vector3(0, 0, -escala.Z/2), // Posición relativa
                new Vector3(escala.Z, escala.Y, 0), // Tamaño
                new Vector3(0, 1, 1) // Color cian
            );
            caraDerecha.Rotar(new Vector3(0, -90, 0)); // Rotar -90 grados en Y
            caras.Add(caraDerecha);
        }

        public override void Dibujar(int vertexBufferObject, int elementBufferObject)
        {
            // Dibujar todas las caras de la parte
            foreach (var cara in caras)
            {
                cara.Dibujar(vertexBufferObject, elementBufferObject);
            }
        }

        public override void Actualizar(double tiempo)
        {
            // Lógica para actualizar la parte (si es necesario)
        }
    }
}