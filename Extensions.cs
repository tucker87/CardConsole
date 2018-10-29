using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    public static T Random<T>(this List<T> list)
    {
        return list.First();
    }
}