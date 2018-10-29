using System;
using System.Collections.Generic;
using static System.Console;

namespace CardConsole
{
    class Program
    {

        public static Board Board { get; set; }

        static void Main(string[] args)
        {
            var scene = Library.Scenes[0];

            Board = new Board();
            Board.Enemies.AddRange(new List<Enemy>{
                Library.Enemies[0],
                Library.Enemies[1],
            });

            Board.Player.Hand.Cards.AddRange(new List<Card>{
                Library.Cards[0],
                Library.Cards[1],
                Library.Cards[2],
            });

            while (true)
            {
                Graphics.Draw(scene, Board);

                var card = AskCard();

                card.GetTarget(Board);
                card.Effect(Board, card);

                foreach (var enemy in Board.Enemies)
                    enemy.Actions.Random()(Board);
            }
        }
        
        public static Card AskCard()
        {
            var index = GetIndex(Board.Player.Hand.Cards);

            return Board.Player.Hand.Cards[index];
        }

        public static int GetIndex<T>(List<T> list)
        {
            while (true)
            {
                if (!int.TryParse(ReadLine(), out int index))
                    WriteLine("Learn to type!");
                else if (index < 0 || index > list.Count - 1)
                    WriteLine("Number not in the list!");
                else
                    return index;
            }
        }

        public static Enemy AskTarget()
        {
            WriteLine("Choose a Target:");
            var index = GetIndex(Board.Enemies);
            return Board.Enemies[index];
        }
    }
}
