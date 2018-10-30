using System;
using System.Collections.Generic;
using System.Linq;

public class MapScene : Scene
{
    public MapScene()
    {
        BaseAction = g => Navigate(g);

        Map = new MapElement(1, 10);

        BuildMap(Map.CurrentLocation);

        Elements = new List<Element> {
            Map,
            new BoxElement(1, 1, 30, 7, 
            g => "Legend", 
            g => new List<ColoredString>{
                new ColoredString("M : Monster", ConsoleColor.Red), 
                new ColoredString("E : Elite", ConsoleColor.Blue),
                new ColoredString("? : Unknown", ConsoleColor.DarkYellow),
                new ColoredString("$ : Shop", ConsoleColor.Yellow)})
        };
    }

    private MapElement Map { get; }

    private void Navigate(Game game)
    {

        Graphics.DrawPrompt($"Where would you like to go? 1. Left{(Map.CurrentLocation.OnlyOne ? "" : ", 2. Right")}");
        var index = Utility.GetIndex(Map.CurrentLocation.Children, game.Scene.ForegroundColor);
        Map.CurrentLocation = Map.CurrentLocation.Children[index];
        if(Map.CurrentLocation.Name == "E")
            game.Scene = new CombatScene();
    }

    private void BuildMap(Location currentLocation, int depth = 0, bool? leftBranch = null, Random r = null)
    {
        if (depth > 10)
            return;

        if (r == null)
            r = new Random();

        var onlyOne = r.Next(1, 75) < 50;

        var xOffset1 = leftBranch == false ? 0 : -1;
        var xOffset2 = leftBranch == true ? 0 : 1;

        SetChild(currentLocation, onlyOne ? 0 : xOffset1, 0, r);
        BuildMap(currentLocation.Children[0], depth + 1, true, r);

        
        if(!onlyOne || leftBranch == null)
        {
            SetChild(currentLocation, xOffset2, 1, r);
            BuildMap(currentLocation.Children[1], depth + 1, false, r);
        }
    }

    private void SetChild(Location currentLocation, int xOffset, int childIndex, Random r)
    {
        var locationAtNewPosition = Map.Locations.FirstOrDefault(l => l.X == currentLocation.X + xOffset && l.Y == currentLocation.Y - 1);
        if(locationAtNewPosition != null)
        {
            currentLocation.Children[childIndex] = locationAtNewPosition;
            return;
        }

        var type = RollType(r);
        var location = new Location(type, currentLocation.X + xOffset, currentLocation.Y - 1);
        Map.Locations.Add(location);
        currentLocation.Children[childIndex] = location;
    }

    private ColoredString RollType(Random r)
    {
        var roll = r.Next(1, 101);
        var type = new ColoredString("", ConsoleColor.White);

        if (roll <= 25) type = new ColoredString("M", ConsoleColor.Red);
        else if (roll <= 50) type = new ColoredString("E", ConsoleColor.Blue);
        else if (roll <= 75) type = new ColoredString("?", ConsoleColor.DarkYellow);
        else type = new ColoredString("$", ConsoleColor.Yellow);

        return type;
    }
}