using OpenTK.Mathematics;
using TareaU;

public abstract class ObjetoGrafico
{
    public Vector3 Posicion { get; set; }
    public Vector3 Escala { get; set; }
    public Vector3 Rotacion { get; set; }
    public Vector3 Centro { get; set;}
    public List<Parte> Partes { get; set; } = new List<Parte>();

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

    public abstract void Mover(Vector3 posicion);

    public abstract void Escalar(Vector3 escala);

    public abstract void Rotar(Vector3 rotacion);

    public abstract void CalcularCentroDeMasa();


    

    

}