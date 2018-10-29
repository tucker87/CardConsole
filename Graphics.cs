using System;
using static System.Console;

public class Graphics
{
    public static void Draw(Scene scene, Board board)
    {
        Clear();
        foreach (var element in scene.Elements)
        {
            element.Fill(board);
            for (var c = 0; c < element.Height; c++)
            {
                Console.SetCursorPosition(element.X, element.Y + c);
                for (var i = 0; i < element.Width; i++)
                {
                    Console.Write(element[c, i]);
                }
            }
        }

        Console.SetCursorPosition(0, 29);
        Console.Write(">");
    }
}