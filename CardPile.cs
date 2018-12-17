using System;
using System.Collections.Generic;
using System.Linq;

public class CardPile
{
    public Hand Hand { get; set; }
    public List<Card> Cards { get; set; }

    public void Shuffle()
    {
        var r = new Random();
        Cards.OrderBy(_ => r.Next()).ToList();
    }
}