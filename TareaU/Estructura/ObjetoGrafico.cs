using OpenTK.Mathematics;
using TareaU;

public abstract class ObjetoGrafico
{
    public Vector3 Posicion { get; set; }
    public Vector3 Escala { get; set; }
    public Vector3 Rotacion { get; set; }

    protected ObjetoGrafico(Vector3 posicion, Vector3 escala, Vector3 rotacion )
    {
        Posicion = posicion;
        Escala = escala;
        Rotacion = rotacion;
    }

    public ObjetoGrafico()
    {
        Posicion = Vector3.Zero;
        Escala = Vector3.One;
        Rotacion = Vector3.Zero;
    }

    public abstract void Dibujar(Shader shader);

    public abstract void Actualizar();

    public void Mover(Vector3 posicion)
    {
        Posicion += posicion;
    }

    public void Escalar(Vector3 escala)
    {
        Escala += escala;
    }

    public abstract void Rotar(Vector3 rotacion);

    // public void Rotar(Vector3 rotacion)
    // {
    //     Rotacion += rotacion;
    //     Actualizar();
    // }

    

    

}