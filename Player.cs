using System;

public class Player
{
    public int Health = 20;
    public Hand Hand { get; set; } = new Hand();

    internal void Heal(int amount)
    {
        Health += amount;
    }

    internal void Hit(int amount)
    {
        Health -= amount;
    }
}