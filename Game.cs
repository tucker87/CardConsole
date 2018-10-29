using System.Collections.Generic;

public class Game 
{
    public Player Player { get; set; } = new Player();
    public List<Enemy> Enemies { get; set; } = new List<Enemy>();
    public Scene Scene { get; set; }
    public string Prompt { get; set; }
}