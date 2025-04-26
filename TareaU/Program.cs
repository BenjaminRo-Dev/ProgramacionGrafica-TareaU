// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using OpenTK.Mathematics;
using TareaU;


// ...existing code...

// Obtén el objeto "LetraU" desde la clase LetraU
// var miObjeto = LetraU.ObjetosU()["LetraU"];

// // Serializa el objeto
// var dto = new ObjetoDTO(miObjeto);
// string json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
// Console.WriteLine(json);

// ...existing code...y
using (Game game = new Game(1700, 900, "Programacion gráfica  - UAGRM"))
{
    game.Run();
}