using OpenTK.Mathematics;
using TareaU;

public class Objeto : ObjetoGrafico
{
    public Dictionary<string, Parte> Partes;

    public Objeto(string nombre, Dictionary<string, Parte> partes)
    {
        Nombre = nombre;
        Partes = partes;

        foreach (var parte in Partes.Values)
        {
            parte.Posicion = Posicion;
            parte.Escala = Escala;
            parte.Rotacion = Rotacion;
        }
    }

    public override void Dibujar(Shader shader)
    {
        foreach (var parte in Partes.Values)
            parte.Dibujar(shader);
    }

    public override void Rotar(Vector3 angulos, Vector3? centro = null)
    {
        Centro = centro ?? CalcularCentro();
        Rotacion = angulos;
        foreach (var parte in Partes.Values)
        {
            parte.Rotar(Rotacion, Centro);
        }
    }

    public override void Posicionar(Vector3 posicion)
    {
        Posicion = posicion;
        foreach (var parte in Partes.Values)
        {
            parte.Posicionar(Posicion);
        }
    }

    public override void Escalar(float escala, Vector3? centro = null)    
    {
        Centro = CalcularCentro();
        foreach (var parte in Partes.Values)
        {
            parte.Escalar(escala, Centro);
        }
    }

    public override Vector3 CalcularCentro()
    {
        var vertices = Partes.Values
            .SelectMany(parte => parte.Caras.Values)
            .SelectMany(cara => cara.Vertices.Values)
            .ToList();

        return new Vector3(
            vertices.Average(v => v.posicion.X),
            vertices.Average(v => v.posicion.Y),
            vertices.Average(v => v.posicion.Z)
        );
    }
}