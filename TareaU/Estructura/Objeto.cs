using OpenTK.Mathematics;
using TareaU;

public class Objeto : ObjetoGrafico
{
    public List<Parte> Partes;

    public Objeto(Vector3 posicion, Vector3 escala, Vector3 rotacion, List<Parte> partes)
        : base(posicion, escala, rotacion)
    {
        Partes = partes;
        
        foreach (var parte in Partes)
        {
            parte.Posicion = Posicion;
            parte.Escala = Escala;
            parte.Rotacion = Rotacion;
        }
    }

    public override void Dibujar(Shader shader)
    {
        foreach (var parte in Partes)
        {
            parte.Dibujar(shader);
        }
    }

    public override void Actualizar()
    {
        foreach (var parte in Partes)
        {
            parte.Posicion = Posicion;
            parte.Escala = Escala;
            parte.Rotacion = Rotacion;
            parte.Actualizar();
        }
    }

    public override void Rotar(Vector3 rotacion)
    {
        throw new NotImplementedException();
    }

    public override void Mover(Vector3 posicion)
    {
        Posicion = posicion;
        foreach (var parte in Partes)
        {
            parte.Posicion = Posicion;
        }
    }

    public override void Escalar(Vector3 escala)
    {
        Escala = escala;
        foreach (var parte in Partes)
        {
            parte.Escala = Escala;
        }
    }

}