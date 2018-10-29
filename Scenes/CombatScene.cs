using System;
using System.Collections.Generic;
using System.Linq;

public class CombatScene : Scene
{
    public CombatScene()
    {
        BaseAction = g => AskPlayCard(g);

        Elements = new List<Element> {
            new BoxElement(1, 15, 30, 10,
            g => "Player",
            g => new List<string> {$"HP: {g.Player.Health}"}.Concat(g.Player.Hand.Cards.Select((c, i) => $"{i+1}. {c.Name}"))),
            new BoxElement(1, 1, 30, 10,
                g => "Enemies",
                g => g.Enemies.Select((e, i) => $"{i+1}. {e.Name} HP: {e.Health}")),
        };
    }

    public static void AskPlayCard(Game game)
    {
        var card = AskCard(game.Player.Hand.Cards);

        card.GetTarget(game);
        card.Effect(game, card);

        foreach (var enemy in game.Enemies)
            enemy.Actions.Random()(game);
    }

    public static Card AskCard(List<Card> cards)
    {
        var index = Utility.GetIndex(cards);

        return cards[index];
    }
}