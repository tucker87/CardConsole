using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Console;

[DebuggerDisplay("Name: {Name}, X: {X}, Y: {Y}")]
public class Location
{
    public Location(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }

    public string Name { get; set; }
    public Location Parent { get; set; }
    public bool OnlyOne => Children[1] == null;
    public List<Location> Connected { get; set; } = new List<Location>();
    public Location[] Children { get; set; } = new Location[2];
    public int X { get; set; }
    public int Y { get; set; }

    internal static void Traverse(Location location, Location currentLocation)
    {
        var myX = CursorLeft;
        var myY = CursorTop;

        MoveCursor(-(location.Name.Length / 2), 0);
        Write(location == currentLocation ? "X" : location.Name);
        var children = location.Children.Where(c => c != null).ToList();
        foreach(var child in children)
        {
            SetCursorPosition(myX, myY);            
            if(child.X == location.X)
            {
                MoveCursor(0, -1);
                Write("|");
                MoveCursor(-1, -1);
            }
            else if(child.X < location.X)
            {
                MoveCursor(-2, -1);
                Write(@"\");
                MoveCursor(-2, -1);
            }
            else
            {
                MoveCursor(2, -1);
                Write("/");
                MoveCursor(0, -1);
            }

            Traverse(child, currentLocation);
        }
    }

    private static void MoveCursor(int x, int y)
    {
        SetCursorPosition(CursorLeft + x, CursorTop + y);
    }
}