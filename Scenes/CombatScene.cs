using System;
using System.Collections.Generic;
using System.Linq;

public class CombatScene : Scene
{
    public List<Enemy> Enemies { get; set; } = new List<Enemy>();
    public CombatScene()
    {
        BaseAction = g => AskPlayCard(g);
        Prompt = "Choose a Card:";

        Enemies = new List<Enemy>
        {
            Library.Enemies["Slime"](),
            Library.Enemies["Skeleton"](),
        };

        Elements = new List<Element> {
            new BoxElement(1, 15, 30, 10,
            g => "Player",
            g => new List<string> {$"HP: {g.Player.Health}"}.Concat(g.Player.Hand.Cards.Select((c, i) => $"{i+1}. {c.Name}"))),
            new BoxElement(1, 1, 30, 10,
                g => "Enemies",
                g => Enemies.Select((e, i) => $"{i+1}. {e.Name} HP: {e.Health}")),
        };
    }

    public void AskPlayCard(Game game)
    {
        var card = AskCard(game.Player.Hand.Cards);

        card.GetTarget(game);
        card.Effect(game, card);

        if (Enemies.All(e => e.Health <= 0))
            game.Scene = Library.Scenes["Map"];

        foreach (var enemy in Enemies)
            enemy.Actions.Random()(game);
    }

    public static Card AskCard(List<Card> cards)
    {
        var index = Utility.GetIndex(cards);

        return cards[index];
    }
}