using System;
using System.Collections.Generic;
using System.Linq;
using CardConsole;

public static class Library
{
    public static Dictionary<string, Card> Cards { get; set; } = new Dictionary<string, Card>
    {
        ["Heal1"] = new Card("Heal 1", (b, c) => b.Player.Heal(1)),
        ["Heal2"] = new Card("Heal 2", (b, c) => b.Player.Heal(2)),
        ["Attack1"] = new Card("Attack 1", (b, c) => c.Target.Hit(1), g => Utility.AskTarget(g))
    };
    public static Dictionary<string, Func<Enemy>> Enemies { get; set; } = new Dictionary<string, Func<Enemy>>
    {
        ["Slime"] = () => new Enemy("Slime", 2, g => g.Player.Hit(1), g => g.Player.Hit(2)),
        ["Skeleton"] = () => new Enemy("Skeleton", 3, g => g.Player.Hit(0), g => g.Player.Hit(1)),
    };

    public static Dictionary<string, Scene> Scenes { get; set; } = new Dictionary<string, Scene>
    {
        ["Map"] = new MapScene()
    };
}