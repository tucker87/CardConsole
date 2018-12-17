using System;
using System.Collections.Generic;
using static System.Console;

namespace CardConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Scene = Library.Scenes["Map"];

            game.Player.Deck.Cards.AddRange(new List<Card>{
                Library.Cards["Heal1"],
                Library.Cards["Heal2"],
                Library.Cards["Attack1"],
                Library.Cards["Attack1"],
                Library.Cards["Attack1"],
                Library.Cards["Attack1"],
            });

            game.Player.Deck.Shuffle();

            while (true)
            {
                Graphics.Draw(game);

                game.Scene.BaseAction(game);
            }
        }
    }
}
