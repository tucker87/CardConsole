using System;
using System.Collections.Generic;

public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public List<Action<Game>> Actions { get; set; } = new List<Action<Game>>();

    public Enemy(string name, int health, params Action<Game>[] actions)
    {
        Name = name;
        Health = health;
        Actions.AddRange(actions);
    }

    public void Hit(int amount)
    {
        Health -= amount;
    }
}