using System;
using System.Collections.Generic;
using System.Linq;

public class CombatScene : Scene
{
    public List<Enemy> Enemies { get; set; } = new List<Enemy>();
    public CombatScene(Game game)
    {
        BaseAction = g => AskPlay(g);
        Prompt = "Choose a Card: (E to end turn.)";

        game.Player.Hand.DiscardAll();
        game.Player.Deck.Shuffle();

        Enemies = new List<Enemy>
        {
            Library.Enemies["Slime"](),
            Library.Enemies["Skeleton"](),
        };

        Elements = new List<Element> {
            new BoxElement(1, 15, 30, 10,
            g => "Player",
            g => new List<ColoredString> {$"HP: {g.Player.Health}"}.Concat(g.Player.Hand.Cards.Select((c, i) => (ColoredString)$"{i+1}. {c.Name}"))),
            new BoxElement(1, 1, 30, 10,
                g => "Enemies",
                g => Enemies.Select((e, i) => (ColoredString)$"{i+1}. {e.Name} HP: {e.Health}")),
        };
    }

    public void AskPlay(Game game)
    {
        var card = AskCard(game.Player.Hand.Cards, game.Scene.ForegroundColor);

        if(card == null)
        {
            game.Player.Mana = 3;
            foreach (var enemy in Enemies)
                enemy.Actions.Random()(game);
        }
        else
        {
            card.GetTarget(game);
            card.Effect(game, card);

            if (Enemies.All(e => e.Health <= 0))
                game.Scene = Library.Scenes["Map"];
        }
    }

    public static Card AskCard(List<Card> cards, ConsoleColor sceneForegroundColor)
    {
        var index = Utility.GetIndex(cards, sceneForegroundColor, new List<char>{'e'});
        if(index >= 0)
            return cards[index];
        else
            return null;
    }
}