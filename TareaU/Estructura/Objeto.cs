using OpenTK.Mathematics;
using TareaU;

public class Objeto : ObjetoGrafico
{
    public Dictionary<string, Parte> Partes;

    public Objeto(string nombre, Vector3 posicion, Vector3 escala, Vector3 rotacion, Dictionary<string, Parte> partes)
        : base(posicion, escala, rotacion)
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

    public override void Actualizar()
    {
        foreach (var parte in Partes.Values)
        {
            parte.Posicion = Posicion;
            parte.Escala = Escala;
            parte.Rotacion = Rotacion;
            parte.Centro = Centro;
            parte.Actualizar();
        }
    }

    public override void Rotar(Vector3 angulos, Vector3 centro)
    {
        Centro = centro;
        Rotacion = angulos;
        foreach (var parte in Partes.Values)
        {
            parte.Rotar(Rotacion, Centro);
        }
    }

    public void Rotar2(Vector3 angulos, Vector3? centro = null)
    {
        foreach (var parte in Partes.Values)
        {
            parte.Rotar2(angulos, centro);
        }
    }

    public void SetRotacion(Vector3 angulos, Vector3 centro)
    {
        // Rotacion = angulos;
        foreach (var parte in Partes.Values)
        {
            foreach (var cara in parte.Caras.Values)
            {
                // cara.Rotar(angulos, centro);
                cara.Centro = centro;
                cara.Rotacion += angulos;//Desde el objeto

            }
        }
    }
    public override void Posicionar(Vector3 posicion)
    {
        Posicion = posicion;
        foreach (var parte in Partes.Values)
        {
            parte.Posicionar(posicion);
        }
    }

    public override void Escalar(Vector3 escala)
    {
        Escala = escala;
        foreach (var parte in Partes.Values)
        {
            parte.Escala = Escala;
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