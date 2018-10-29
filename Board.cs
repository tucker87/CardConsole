using System.Collections.Generic;

public class Board 
{
    public Player Player { get; set; } = new Player();
    public List<Enemy> Enemies { get; set; } = new List<Enemy>();
}