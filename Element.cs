using System;
using System.Collections.Generic;
using System.Linq;

public class Element
{
    public Element(int x, int y, int width, int height, Func<Board, string> title, Func<Board, IEnumerable<string>> content)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Text = new char[Height, Width];
        Title = title;
        Content = content;
    }
    public int Height { get; set; }
    public int Width { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public char[,] Text { get; set; }
    public Func<Board, string> Title { get; set; }
    public Func<Board, IEnumerable<string>> Content { get; set; }

    public void Fill(Board board)
    {
        FillBorder();
        FillTitle(board);
        FillContent(board);
    }
    public void FillBorder()
    {
        Text[0, 0] = '+';
        Text[Height - 1, 0] = '+';
        Text[0, Width - 1] = '+';
        Text[Height - 1, Width - 1] = '+';

        for (var c = 1; c < Height - 1; c++)
        {
            Text[c, 0] = '|';
            Text[c, Width - 1] = '|';
        }

        for (var r = 1; r < Width - 1; r++)
        {
            Text[0, r] = '-';
            Text[Height - 1, r] = '-';
        }
    }

    public void FillTitle(Board board)
    {
        AddText(Title(board), 0);
    }

    public void FillContent(Board board)
    {
        var content = Content(board).ToList();
        for (var i = 0; i < content.Count(); i++)
            AddText(content[i], i+1);
    }

    public void AddText(string text, int lineNumber)
    {
        for (var i = 0; i < text.Length; i++)
            Text[lineNumber, i + 2] = text[i];
    }

    public char this[int c, int r]
    {
        get => Text[c, r];
        set => Text[c, r] = value;
    }
}