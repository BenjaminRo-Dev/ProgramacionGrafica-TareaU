// See https://aka.ms/new-console-template for more information
using TareaU;

Console.WriteLine("Hello, World!");
using (Game game = new Game(1700, 900, "LearnOpenTK"))
{
    game.Run();
}