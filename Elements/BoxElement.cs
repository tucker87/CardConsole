using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

public class BoxElement : Element
{
    public BoxElement(int x, int y, int width, int height, Func<Game, string> title, Func<Game, IEnumerable<string>> content) 
        : base(x, y)
    {
        Width = width;
        Height = height;
        Text = new char[Height, Width];
        Title = title;
        Content = content;
    }

    public BoxElement(int x, int y, int width, int height, Func<Game, string> title, Func<Game, string> content) 
        :this(x, y, width, height, title, FuncList(content)){}

    public int Height { get; set; }
    public int Width { get; set; }
    
    public char[,] Text { get; set; }
    public Func<Game, string> Title { get; set; }
    public Func<Game, IEnumerable<string>> Content { get; set; }

    public override void Prepare(Game game)
    {
        FillBorder();
        FillTitle(game);
        FillContent(game);
    }

    public override void Draw(Game game)
    {
        for (var c = 0; c < Height; c++)
        {
            SetCursorPosition(X, Y + c);
            for (var i = 0; i < Width; i++)
                Console.Write(Text[c, i]);
        }
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

    public void FillTitle(Game game)
    {
        AddText(Title(game), 0);
    }

    public void FillContent(Game game)
    {
        var content = Content(game).ToList();
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

    private static Func<Game, IEnumerable<string>> FuncList(Func<Game, string> stringFunc)
    {
        return g => new List<string>{stringFunc(g)};
    }
}