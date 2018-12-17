using System;

public class Player
{
    public int Health = 20;
    public int Mana = 3;
    public Hand Hand { get; set; }
    public Deck Deck { get; set; }
    public Discard Deck { get; set; }

    public Player()
    {
        var hand = new Hand();
        var deck = new Deck();
        hand.Deck = deck;
        deck.Hand = hand;
        Hand = hand;
        Deck = deck;
    }

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void Hit(int amount)
    {
        Health -= amount;
    }
}