using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Console;

[DebuggerDisplay("Name: {Name}, X: {X}, Y: {Y}")]
public class Location
{
    public Location(ColoredString name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }

    public ColoredString Name { get; set; }
    public bool OnlyOne => Children[1] == null;
    public Location[] Children { get; set; } = new Location[2];
    public int X { get; set; }
    public int Y { get; set; }

    internal static void Traverse(List<Location> locations, Location location, Location currentLocation, ConsoleColor sceneForegroundColor)
    {
        var myX = CursorLeft;
        var myY = CursorTop;

        MoveCursor(-(location.Name.Length / 2), 0);
        if(location == currentLocation)
            Write("X");
        else
            Graphics.WriteColored(location.Name, sceneForegroundColor);
        
        var children = location.Children.Where(c => c != null).ToList();
        foreach (var child in children)
        {
            SetCursorPosition(myX, myY);
            if (child.X == location.X)
            {
                MoveCursor(0, -1);
                Write("|");
                MoveCursor(-1, -1);
            }
            else if (child.X < location.X)
            {
                MoveCursor(-1, -1);
                Write(@"\");

                MoveCursor(-2, -1);
            }
            else
            {
                MoveCursor(1, -1);
                Write("/");

                MoveCursor(0, -1);
            }

            Traverse(locations, child, currentLocation, sceneForegroundColor);
        }
    }
    
    private static void MoveCursor(int x, int y)
    {
        SetCursorPosition(CursorLeft + x, CursorTop + y);
    }
}