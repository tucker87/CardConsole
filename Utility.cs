using System.Collections.Generic;
using static System.Console;
public static class Utility
{
    public static int GetIndex<T>(IReadOnlyCollection<T> list)
    {
        while (true)
        {
            if (!int.TryParse(ReadLine(), out int index))
                WriteLine("Learn to type!");
            else if (index < 1 || index > list.Count)
                WriteLine("Number not in the list!");
            else
                return index - 1;
        }
    }

    public static Enemy AskTarget(Game game)
        {
            WriteLine("Choose a Target:");
            var index = GetIndex(game.Enemies);
            return game.Enemies[index];
        }
}