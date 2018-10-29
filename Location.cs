using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

public class Location
{
    public Location(string name)
    {
        Name = name;
    }
    public Location(string name, Location parent)
    {
        Name = name;
        Parent = parent;
    }

    public string Name { get; set; }
    public Location Parent { get; set; }

    internal Location AddChildren(Location left = null, Location right = null)
    {
        if (left != null)
        {
            left.Parent = this;
            Children[0] = left;
        }

        if (right != null)
        {
            right.Parent = this;
            Children[1] = right;
        }

        return this;
    }

    public List<Location> Connected { get; set; } = new List<Location>();

    internal static void Traverse(Location currentLocation)
    {
        var myX = CursorLeft;
        var myY = CursorTop;

        MoveCursor(-(currentLocation.Name.Length / 2), 0);
        Write(currentLocation.Name);
        SetCursorPosition(myX, myY);

        if (currentLocation.Children.Count(c => c != null) == 1)
        {
            MoveCursor(0, -1);
            Write("|");
            MoveCursor(-1, -1);
            Traverse(currentLocation.Children.First(c => c != null));
            return;
        }

        if (currentLocation.Children[0] != null)
        {
            MoveCursor(-2, -1);
            Write(@"\");
            MoveCursor(-2, -1);
            Traverse(currentLocation.Children[0]);
        }
        
        if (currentLocation.Children[1] != null)
        {
            SetCursorPosition(myX, myY);
            MoveCursor(2, -1);
            Write("/");
            MoveCursor(0, -1);
            Traverse(currentLocation.Children[1]);
        }
    }

    private static void MoveCursor(int x, int y)
    {
        SetCursorPosition(CursorLeft + x, CursorTop + y);
    }

    public Location[] Children { get; set; } = new Location[2];
}