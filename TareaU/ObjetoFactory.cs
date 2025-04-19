using OpenTK.Mathematics;
using TareaU;
public static class ObjetoFactory
{
    public static Objeto Convertir(ObjetoData data)
    {
        var posicion = new Vector3(data.posicion[0], data.posicion[1], data.posicion[2]);
        var escala = new Vector3(data.escala[0], data.escala[1], data.escala[2]);
        var rotacion = new Vector3(data.rotacion[0], data.rotacion[1], data.rotacion[2]);

        var partes = data.partes.Select(p => ConvertirParte(p)).ToList();

        return new Objeto(posicion, escala, rotacion, partes);
    }

    private static Parte ConvertirParte(ParteData data)
    {
        var posicion = new Vector3(data.posicion[0], data.posicion[1], data.posicion[2]);
        var escala = new Vector3(data.escala[0], data.escala[1], data.escala[2]);
        var rotacion = new Vector3(data.rotacion[0], data.rotacion[1], data.rotacion[2]);

        var vertices = data.vertices.Select(v => new Vector3(v[0], v[1], v[2])).ToList();

        var caras = data.caras.Select(c => new Cara(
            ColorFromString(c.color),
            vertices[c.indices[0]],
            vertices[c.indices[1]],
            vertices[c.indices[2]],
            vertices[c.indices[3]]
        )).ToList();


        return new Parte(posicion, escala, rotacion, caras);
    }

    private static Color4 ColorFromString(string color)
    {
        return color.ToLower() switch
        {
            "red" => Color4.Red,
            "green" => Color4.Green,
            "blue" => Color4.Blue,
            "yellow" => Color4.Yellow,
            "cyan" => Color4.Cyan,
            "magenta" => Color4.Magenta,
            "indigo" => Color4.Indigo,
            _ => Color4.White
        };
    }
}
