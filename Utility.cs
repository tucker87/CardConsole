using System.Collections.Generic;
using System.Linq;
using static System.Console;
public static class Utility
{
    public static int GetIndex<T>(IReadOnlyCollection<T> list)
    {
        while (true)
        {
            if (!int.TryParse(ReadKey().KeyChar.ToString(), out int index))
                WriteLine("Learn to type!");
            else if (index < 1 || index > list.Where(x => x != null).Count())
                WriteLine("Number not in the list!");
            else
                return index - 1;
        }
    }

    public static Enemy AskTarget(Game game)
    {
        if (game.Scene is CombatScene scene)
        {
            Graphics.DrawPrompt("Choose a Target:");
            var index = GetIndex(scene.Enemies);
            return scene.Enemies[index];
        }
        else
            throw new System.Exception("Can't Ask for an Enemy target on a non-combat scene!");
    }
}