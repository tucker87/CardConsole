using System;

public class Player
{
    public int Health = 20;
    public int Mana = 3;
    public Hand Hand { get; set; } = new Hand();

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void Hit(int amount)
    {
        Health -= amount;
    }
}