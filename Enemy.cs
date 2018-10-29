using System;
using System.Collections.Generic;

public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public List<Action<Board>> Actions { get; set; } = new List<Action<Board>>();

    public Enemy(string name, int health, params Action<Board>[] actions)
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