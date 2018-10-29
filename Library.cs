using System.Collections.Generic;
using System.Linq;
using CardConsole;

public static class Library
{
    public static Dictionary<int, Card> Cards { get; set; } = new Dictionary<int, Card>
    {
        [0] = new Card("Heal 1", (b, c) => b.Player.Heal(1)),
        [1] = new Card("Heal 2", (b, c) => b.Player.Heal(2)),
        [2] = new Card("Attack 1", (b, c) => c.Target.Hit(1), b => Program.AskTarget())
    };
    public static Dictionary<int, Enemy> Enemies { get; set; } = new Dictionary<int, Enemy>
    {
        [0] = new Enemy("Slime", 2, b => b.Player.Hit(1), b => b.Player.Hit(2)),
        [1] = new Enemy("Skeleton", 3, b => b.Player.Hit(0), b => b.Player.Hit(1)),
    };

    public static Dictionary<int, Scene> Scenes { get; set; } = new Dictionary<int, Scene>
    {
        [0] = new Scene(new List<Element> {
            new Element(10, 15, 30, 10, b => "Player", b => new List<string> {$"HP: {b.Player.Health}"}.Concat(b.Player.Hand.Cards.Select((c, i) => $"{i}. {c.Name}"))),
            new Element(1, 1, 30, 10, b => "Enemies", b => b.Enemies.Select((e, i) => $"{i}. {e.Name} HP: {e.Health}")),
        })
    };
}