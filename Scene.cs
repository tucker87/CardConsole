using System.Collections.Generic;

public class Scene
{
    public Scene(List<Element> elements)
    {
        Elements = elements;
    }

    public List<Element> Elements { get; }
}