using System;
using System.Collections.Generic;
using System.Linq;

public class Deck : CardPile
{
    public List<Card> Draw(int count = 1)
    {
        var drawnCards = Cards.Take(count);
        Cards = Cards.Skip(count).ToList();
        return drawnCards.ToList();
    }
}