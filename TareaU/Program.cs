// See https://aka.ms/new-console-template for more information
using TareaU;

Console.WriteLine("Hola, soy Benjamin Romero, y esta es mi tarea de OpenGL.");
using (Game game = new Game(1700, 900, "Programacion gráfica  - UAGRM"))
{
    game.Run();
}