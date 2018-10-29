using System;
using System.Collections.Generic;
using System.Linq;

public class MapScene : Scene
{
    public MapScene()
    {
        BaseAction = g => Navigate(g);

        var startLocation = new Location("X");

        Map = new MapElement(1, 10);

        BuildMap(Map.CurrentLocation);

        Elements = new List<Element> {
            Map,
            new BoxElement(1, 1, 30, 7, g => "Legend", g => new List<string>{"M : Monster", "E : Elite",  "? : Unknown", "$ : Shop"})
        };
    }

    private MapElement Map { get; }

    private void Navigate(Game game)
    {
        Graphics.DrawPrompt("Where would you like to go? 1. Left, 2. Right");
        var index = Utility.GetIndex(Map.CurrentLocation.Children);
        Map.CurrentLocation = Map.CurrentLocation.Children[index];
    }

    private void BuildMap(Location currentLocation, int depth = 0, Random r = null)
    {
        if (depth > 10)
            return;

        if (r == null)
            r = new Random();

        var type = RollType(r);
        if (type != "")
        {
            currentLocation.Children[0] = new Location(type);
            BuildMap(currentLocation.Children[0], depth + 1, r);
        }

        type = RollType(r);
        if (type != "")
        {
            currentLocation.Children[1] = new Location(type);
            BuildMap(currentLocation.Children[1], depth + 1, r);
        }
    }

    private string RollType(Random r)
    {
        var roll = r.Next(1, 101);
        var type = "";

        if (roll <= 20) type = "M";
        else if (roll <= 40) type = "E";
        else if (roll <= 60) type = "?";
        else if (roll <= 80) type = "$";
        else type = "";

        return type;
    }
}