using System;

public class Card
{
    public string Name { get; set; }
    public Action<Board, Card> Effect { get; set; }
    public Enemy Target { get; set; }

    public Card(string name, Action<Board, Card> effect, Func<Board, Enemy> getTarget = null)
    {
        Name = name;
        Effect = effect;
        if(getTarget != null)
            GetTargetFunc = getTarget;
    }

    private Func<Board, Enemy> GetTargetFunc { get; set; } = b => null;

    public void GetTarget(Board board)
    {
        Target = GetTargetFunc(board);
    }

}