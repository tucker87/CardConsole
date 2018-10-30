using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
public static class Utility
{
    public static int GetIndex<T>(IReadOnlyCollection<T> list, ConsoleColor sceneForegroundColor, List<char> otherOptions = null)
    {
        while (true)
        {
            var key = ReadKey().KeyChar;
            if(otherOptions != null && otherOptions.Contains(key))
                return - otherOptions.IndexOf(key) - 1;
            if (!int.TryParse(key.ToString(), out int index))
                Graphics.DrawError("Learn to type!", sceneForegroundColor);
            else if (index < 1 || index > list.Where(x => x != null).Count())
                Graphics.DrawError("Number not in the list!", sceneForegroundColor);
            else
                return index - 1;
        }
    }

    public static Enemy AskTarget(Game game)
    {
        if (game.Scene is CombatScene scene)
        {
            Graphics.DrawPrompt("Choose a Target:");
            var index = GetIndex(scene.Enemies, game.Scene.ForegroundColor);
            return scene.Enemies[index];
        }
        else
            throw new System.Exception("Can't Ask for an Enemy target on a non-combat scene!");
    }
}