using System;

public struct ColoredString
{
    public ColoredString(string value, ConsoleColor color) : this()
    {
        Value = value;
        Color = color;
    }

    public string Value { get; set; }
    public ConsoleColor Color { get; set; }

    public int Length => Value.Length;

    public static implicit operator string(ColoredString cs)
    {
        return cs.Value;
    }

    public static implicit operator ConsoleColor(ColoredString cs)
    {
        return cs.Color;
    }

    public static implicit operator ColoredString(string s)
    {
        return new ColoredString(s, ConsoleColor.White);
    }

    public static implicit operator ColoredString(ColoredChar c)
    {
        return new ColoredString(c.Value.ToString(), c.Color);
    }

    public ColoredChar this[int i]
    {
        get => new ColoredChar(Value[i], Color);
    }
}