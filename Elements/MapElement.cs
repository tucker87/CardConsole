using System.Collections.Generic;
using static System.Console;

public class MapElement : Element
{
    public MapElement(int x, int y) : base(x, y)
    {
        CurrentLocation = new Location("S", 0, 0);
        Locations.Add(CurrentLocation);
    }

    public Location CurrentLocation { get; set; }
    public List<Location> Locations { get; set; } = new List<Location>();

    public override void Prepare(Game game)
    {
        
    }

    public override void Draw(Game game)
    {
        SetCursorPosition(60, 27);
        Location.Traverse(Locations[0], CurrentLocation);
    }
}