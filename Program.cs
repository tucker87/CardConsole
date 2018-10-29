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
            game.Enemies.AddRange(new List<Enemy>{
                Library.Enemies["Slime"],
                Library.Enemies["Skeleton"],
            });

            game.Player.Hand.Cards.AddRange(new List<Card>{
                Library.Cards["Heal1"],
                Library.Cards["Heal2"],
                Library.Cards["Attack1"],
            });

            while (true)
            {
                Graphics.Draw(game);

                game.Scene.BaseAction(game);
            }
        }
    }
}
