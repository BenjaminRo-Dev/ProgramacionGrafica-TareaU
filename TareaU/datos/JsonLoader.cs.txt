using System.Text.Json;
using OpenTK.Mathematics;
using TareaU;

public static class JsonLoader
{
    public static Objeto Cargar(string rutaArchivo)
    {
        string json = File.ReadAllText(rutaArchivo);
        var root = JsonSerializer.Deserialize<Dictionary<string, ObjetoData>>(json);
        var objetoJson = root["objeto"];

        List<Parte> partes = new();

        foreach (var parteJson in objetoJson.partes)
        {
            List<Cara> caras = new();

            foreach (var caraJson in parteJson.caras)
            {
                var color = ColorFromName(caraJson.color);
                var v = parteJson.vertices.Select(ToVector3).ToList();
                
                // Crear cara usando los índices correctos
                caras.Add(new Cara(
                    color,
                    v[caraJson.indices[0]],
                    v[caraJson.indices[1]],
                    v[caraJson.indices[2]],
                    v[caraJson.indices[3]]
                ));
            }

            partes.Add(new Parte(
                ToVector3(parteJson.posicion),
                ToVector3(parteJson.escala),
                ToVector3(parteJson.rotacion),
                caras));
        }

        // Console.WriteLine(objetoJson.posicion[0]);
        // Console.WriteLine("Adasdasadasd");
        return new Objeto(
            ToVector3(objetoJson.posicion),
            ToVector3(objetoJson.escala), 
            ToVector3(objetoJson.rotacion), 
            partes);
    }

    private static Color4 ColorFromName(string name)
    {
        return name.ToLower() switch
        {
            "indigo" => Color4.Indigo,
            "green" => Color4.Green,
            "blue" => Color4.Blue,
            "yellow" => Color4.Yellow,
            "cyan" => Color4.Cyan,
            "magenta" => Color4.Magenta,
            _ => Color4.White
        };
    }
    private static Vector3 ToVector3(float[] arr)
    {
        return new Vector3(arr[0], arr[1], arr[2]);
    }

}
