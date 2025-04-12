using OpenTK.Mathematics;

public abstract class ObjetoGrafico
{
    // Propiedades comunes
    public Vector3 Posicion { get; set; }
    public Vector3 Rotacion { get; set; }
    public Vector3 Escala { get; set; }

    // Constructor base
    protected ObjetoGrafico(Vector3 posicion, Vector3 rotacion, Vector3 escala)
    {
        Posicion = posicion;
        Rotacion = rotacion;
        Escala = escala;
    }

    // Métodos abstractos que deben implementar las clases derivadas
    public abstract void Dibujar(int vertexBufferObject, int elementBufferObject);
    public abstract void Actualizar(double tiempo);
}