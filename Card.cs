using System;

public class Card
{
    public string Name { get; set; }
    public Action<Game, Card> Effect { get; set; }
    public Enemy Target { get; set; }

    public Card(string name, Action<Game, Card> effect, Func<Game, Enemy> getTarget = null)
    {
        Name = name;
        Effect = effect;
        if(getTarget != null)
            GetTargetFunc = getTarget;
    }

    private Func<Game, Enemy> GetTargetFunc { get; set; } = g => null;

    public void GetTarget(Game game)
    {
        Target = GetTargetFunc(game);
    }
}