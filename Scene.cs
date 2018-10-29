using System;
using System.Collections.Generic;

public abstract class Scene
{
    public Action<Game> BaseAction { get; set; }
    public List<Element> Elements { get; set; }
}