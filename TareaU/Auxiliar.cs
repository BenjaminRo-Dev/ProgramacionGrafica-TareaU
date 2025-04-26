using System.Text.Json;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using TareaU;

public class Auxiliar
{
    public static void CargarObjetoJson(Escenario escenario, string nombreObj)
    {
        string archivo = $"../../../datos/{nombreObj}.json";
        if (File.Exists(archivo))
        {
            string json = File.ReadAllText(archivo);
            var dto = JsonSerializer.Deserialize<ObjetoDTO>(json);
            var objeto = ObjetoMapper.ConvertirAObjeto(dto);
            escenario.AgregarObjeto(objeto);
        }
        else
            Console.WriteLine($"Archivo {nombreObj}.json no encontrado.");
    }

    public static void GuardarObjeto(Objeto objeto)
    {
        var dto = ObjetoMapper.ConvertirADTO(objeto);
        string json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText($"../../../datos/{objeto.Nombre}.json", json);
        Console.WriteLine($"Objeto guardado en datos/{objeto.Nombre}.json");
    }

    public static void Teclas(KeyboardState keyboardState, Escenario escenario, ObjetoGrafico grafico)
    {
        float velocidad = 0.1f;
        
        if (keyboardState.IsKeyDown(Keys.Escape))
            Environment.Exit(0);

        if (keyboardState.IsKeyDown(Keys.F1)) // Guardar objeto
            GuardarObjeto(escenario.Objetos["letraU2"]);

        if (keyboardState.IsKeyDown(Keys.F2)) // Cargar objeto
            CargarObjetoJson(escenario, "letraU2");

        // Rotaciones globales
        if (keyboardState.IsKeyDown(Keys.Up))
            grafico.Rotar(velocidad * new Vector3(-1, 0, 0));

        if (keyboardState.IsKeyDown(Keys.Down))
            grafico.Rotar(velocidad * new Vector3(1, 0, 0));

        if (keyboardState.IsKeyDown(Keys.Left))
            grafico.Rotar(velocidad * new Vector3(0, 1, 0));

        if (keyboardState.IsKeyDown(Keys.Right))
            grafico.Rotar(velocidad * new Vector3(0, -1, 0));

        // Rotaciones locales
        if (keyboardState.IsKeyDown(Keys.W))
            escenario.Objetos["letraU2"].Rotar(velocidad * new Vector3(-1, 0, 0), escenario.Objetos["letraU2"].CalcularCentro());

        if (keyboardState.IsKeyDown(Keys.S))
            escenario.Objetos["letraU2"].Rotar(velocidad * new Vector3(1, 0, 0), escenario.Objetos["letraU2"].CalcularCentro());

        if (keyboardState.IsKeyDown(Keys.A))
            escenario.Objetos["letraU2"].Rotar(velocidad * new Vector3(0, -1, 0), escenario.Objetos["letraU2"].CalcularCentro());

        if (keyboardState.IsKeyDown(Keys.D))
            escenario.Objetos["letraU2"].Rotar(velocidad * new Vector3(0, 1, 0), escenario.Objetos["letraU2"].CalcularCentro());

        // Posicionamiento
        if (keyboardState.IsKeyDown(Keys.Q))
            escenario.Objetos["letraU2"].Posicionar(new Vector3(-1, 0, 0) * velocidad / 4);

        if (keyboardState.IsKeyDown(Keys.E))
            escenario.Objetos["letraU2"].Posicionar(new Vector3(1, 0, 0) * velocidad / 4);

        if (keyboardState.IsKeyDown(Keys.Z))
            escenario.Objetos["letraU2"].Posicionar(new Vector3(0, -1, 0) * velocidad / 4);

        if (keyboardState.IsKeyDown(Keys.X))
            escenario.Objetos["letraU2"].Posicionar(new Vector3(0, 1, 0) * velocidad / 4);

        if (keyboardState.IsKeyDown(Keys.C))
            escenario.Objetos["letraU2"].Posicionar(new Vector3(0, 0, -1) * velocidad / 4);

        if (keyboardState.IsKeyDown(Keys.V))
            escenario.Objetos["letraU2"].Posicionar(new Vector3(0, 0, 1) * velocidad / 4);

        // Escalaciones
        if (keyboardState.IsKeyDown(Keys.L))
            escenario.Objetos["letraU2"].Escalar(1.001f);

        if (keyboardState.IsKeyDown(Keys.M))
            escenario.Objetos["letraU2"].Escalar(0.999f);

        if (keyboardState.IsKeyDown(Keys.P))
            escenario.Objetos["letraU2"].Partes["parte1"].Escalar(1.001f);

        if (keyboardState.IsKeyDown(Keys.O))
            escenario.Objetos["letraU2"].Partes["parte1"].Escalar(0.999f);

        if (keyboardState.IsKeyDown(Keys.Space))
            escenario.Escalar(1.001f);

        if (keyboardState.IsKeyDown(Keys.LeftShift))
            escenario.Escalar(0.999f);
    }
}