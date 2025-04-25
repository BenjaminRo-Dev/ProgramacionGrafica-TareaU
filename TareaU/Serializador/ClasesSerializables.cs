using OpenTK.Mathematics;
using TareaU;

public class VerticeDTO
{
    public float[] Posicion { get; set; }
    public float[] Color { get; set; }

    public static VerticeDTO FromVertice(Vertice v) => new VerticeDTO
    {
        Posicion = new float[] { v.posicion.X, v.posicion.Y, v.posicion.Z },
        Color = new float[] { v.Color.R, v.Color.G, v.Color.B, v.Color.A }
    };

    public Vertice ToVertice() =>
        new Vertice(new Vector3(Posicion[0], Posicion[1], Posicion[2]),
                    new Color4(Color[0], Color[1], Color[2], Color[3]));
}

public class CaraDTO
{
    public Dictionary<string, VerticeDTO> Vertices { get; set; }
    public float[] Posicion { get; set; }
    public float[] Escala { get; set; }
    public float[] Rotacion { get; set; }
    public float[] Color { get; set; }
    public float[] Centro { get; set; }

    public CaraDTO() { }

    public CaraDTO(Cara cara)
    {
        Vertices = cara.Vertices.ToDictionary(
            kvp => kvp.Key,
            kvp => VerticeDTO.FromVertice(kvp.Value));
        Posicion = ToArray(cara.Posicion);
        Escala = ToArray(cara.Escala);
        Rotacion = ToArray(cara.Rotacion);
        Color = ToArray(cara.Color);
        Centro = ToArray(cara.Centro);
    }

    public static CaraDTO FromCara(Cara cara) => new CaraDTO(cara);

    static float[] ToArray(Vector3 v) => new[] { v.X, v.Y, v.Z };
    static float[] ToArray(Color4 c) => new[] { c.R, c.G, c.B, c.A };
}

public class ParteDTO
{
    public string Nombre { get; set; }
    public float[] Posicion { get; set; }
    public float[] Escala { get; set; }
    public float[] Rotacion { get; set; }

    public Dictionary<string, CaraDTO> Caras { get; set; }

    public ParteDTO() {}

    public ParteDTO(string nombre, Parte parte)
    {
        Nombre = nombre;
        Posicion = new float[] { parte.Posicion.X, parte.Posicion.Y, parte.Posicion.Z };
        Escala = new float[] { parte.Escala.X, parte.Escala.Y, parte.Escala.Z };
        Rotacion = new float[] { parte.Rotacion.X, parte.Rotacion.Y, parte.Rotacion.Z };
        Caras = parte.Caras.ToDictionary(c => c.Key, c => new CaraDTO(c.Value));
    }
}


public class ObjetoDTO
{
    public string Nombre { get; set; }
    public float[] Posicion { get; set; }
    public float[] Escala { get; set; }
    public float[] Rotacion { get; set; }

    public Dictionary<string, ParteDTO> Partes { get; set; }

    public ObjetoDTO() {}

    public ObjetoDTO(Objeto obj)
    {
        Nombre = obj.Nombre;
        Posicion = new float[] { obj.Posicion.X, obj.Posicion.Y, obj.Posicion.Z };
        Escala = new float[] { obj.Escala.X, obj.Escala.Y, obj.Escala.Z };
        Rotacion = new float[] { obj.Rotacion.X, obj.Rotacion.Y, obj.Rotacion.Z };

        Partes = obj.Partes.ToDictionary(p => p.Key, p => new ParteDTO(p.Key, p.Value));
    }
}



