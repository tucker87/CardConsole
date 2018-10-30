using System;
using System.Linq;
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
        Console.Write(prompt);
        DrawInput();
    }

    public static void DrawError(string error)
    {
        Console.SetCursorPosition(0, 27);
        Console.Write(Repeat(' ', 120));
        Console.SetCursorPosition(0, 27);
        Console.Write(error);
        DrawInput();
    }

    public static void DrawInput()
    {
        Console.SetCursorPosition(0, 29);
        Console.Write(">" + Repeat(' ', 119));
        Console.SetCursorPosition(1, 29);
    }

    public static string Repeat(char c, int i)
    {
        return string.Join("", Enumerable.Repeat(c, i));
    }
}