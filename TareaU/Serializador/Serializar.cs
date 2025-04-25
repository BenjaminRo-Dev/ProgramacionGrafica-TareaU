using System.Text.Json;
using OpenTK.Mathematics;
using TareaU;

public class Serializar
{

    private static JsonSerializerOptions opciones = new JsonSerializerOptions
    {
        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
        WriteIndented = true
    };

    public static void SerializarGrafica<T>(T grafica, string? rutaArchivo = null)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(grafica, opciones);
            Console.WriteLine(jsonString);

            // File.WriteAllText(rutaArchivo, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al serializar el objeto: {ex.Message}");
        }
    }


    


}