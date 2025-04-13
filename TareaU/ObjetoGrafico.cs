using OpenTK.Mathematics;

public abstract class ObjetoGrafico
{
    public Vector3 Posicion { get; set; }
    public Vector3 Rotacion { get; set; }
    public Vector3 Escala { get; set; }

    protected ObjetoGrafico(Vector3 posicion, Vector3 rotacion, Vector3 escala)
    {
        Posicion = posicion;
        Rotacion = rotacion;
        Escala = escala;
    }

    public ObjetoGrafico()
    {
        Posicion = Vector3.Zero;
        Rotacion = Vector3.Zero;
        Escala = Vector3.One;
    }

    public abstract void Dibujar(int vertexBufferObject, int elementBufferObject);
    public abstract void Actualizar(double tiempo);
}