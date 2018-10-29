using static System.Console;
public abstract class Element
{
    public Element(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Prepare(Game game);
    public abstract void Draw(Game game);

    public void HomeCursor()
    {
        SetCursorPosition(X, Y);
    }
}