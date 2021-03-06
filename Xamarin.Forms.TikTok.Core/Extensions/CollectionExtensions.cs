using System;
using System.Collections.Generic;

namespace Xamarin.Forms.TikTok.Core.Extensions;

public static class CollectionExtensions
{
    public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate) {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        var retVal = 0;
        foreach (var item in items) {
            if (predicate(item)) return retVal;
            retVal++;
        }
        return -1;
    }

    public static int IndexOf<T>(this IEnumerable<T> items, T item)
    {
        return items.FindIndex(i => EqualityComparer<T>.Default.Equals(item, i));
    }
}