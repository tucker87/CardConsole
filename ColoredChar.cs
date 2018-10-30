using System;

public struct ColoredChar
{
    public ColoredChar(char value, ConsoleColor color)
    {
        Value = value;
        Color = color;
    }
    public char Value { get; set; }
    public ConsoleColor Color { get; set; }

    public static implicit operator ColoredChar(char c)
    {
        return new ColoredChar(c, ConsoleColor.White);
    }

    
}