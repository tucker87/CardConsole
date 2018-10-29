using static System.Console;

public class MapElement : Element
{
    public MapElement(int x, int y) : base(x, y)
    {
        CurrentLocation = new Location("X");
    }

    public Location CurrentLocation { get; set; }

    public override void Prepare(Game game)
    {
        
    }

    public override void Draw(Game game)
    {
        SetCursorPosition(60, 27);
        Location.Traverse(CurrentLocation);
    }
}