using System;
using System.Collections.Generic;

public abstract class Scene
{
    public Action<Game> BaseAction { get; set; }
    public List<Element> Elements { get; set; }
    public string Prompt { get; set; }
    public ConsoleColor BackgroundColor {get;set;} = ConsoleColor.Black;
    public ConsoleColor ForegroundColor {get;set;} = ConsoleColor.White;
}