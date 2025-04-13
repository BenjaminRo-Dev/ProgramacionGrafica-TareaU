using OpenTK.Mathematics;
using TareaU;

public class LetraU : ObjetoGrafico
{
    private List<Parte> partes;

    public LetraU(Vector3 posicion, Vector3 rotacion, Vector3 escala)
        : base(posicion, rotacion, escala)
    {
        partes = new List<Parte>
        {
            // Parte izquierda
            new Parte(
                posicion + new Vector3(0, 0, 0),
                new Vector3(0, MathHelper.DegreesToRadians(45), 0), // Rotación en Y de 45 grados
                new Vector3(escala.X / 8, escala.Y, escala.Z/12) // Tamaño de la parte
            ),

            // Parte derecha
            new Parte(
                posicion + new Vector3(escala.X/2, 0, 0),
                Vector3.Zero, // Sin rotación
                new Vector3(escala.X / 8, escala.Y, escala.Z / 12) // Tamaño de la parte
            ),

            // // Parte inferior
            new Parte(
                posicion + new Vector3(0, 0, 0),
                Vector3.Zero, // Sin rotación
                new Vector3(escala.X/2, escala.Y / 4, escala.Z/12) // Tamaño de la parte
                
            )

            
        };
    }

    public override void Dibujar(int vertexBufferObject, int elementBufferObject)
    {
        foreach (var parte in partes)
        {
            parte.Posicion += Posicion; // Aplicar posición global
            parte.Rotacion += Rotacion; // Aplicar rotación global
            parte.Dibujar(vertexBufferObject, elementBufferObject);
        }
    }

    public override void Actualizar(double tiempo)
    {
        // Lógica para actualizar la letra U pa cuando se requiera
    }
}