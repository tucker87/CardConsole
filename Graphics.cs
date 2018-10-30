using System;
using static System.Console;

public class Graphics
{
    public static void Draw(Game game)
    {
        Clear();
        foreach (var element in game.Scene.Elements)
        {
            element.Prepare(game);
            element.Draw(game);
        }

        DrawPrompt(game.Scene.Prompt);
    }

    public static void DrawPrompt(string prompt)
    {
        Console.SetCursorPosition(0, 28);
        Console.WriteLine(prompt);
        Console.Write(">                  ");
        Console.SetCursorPosition(1, 29);
    }
}