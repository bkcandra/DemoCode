using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDChall.Core.Helpers
{
    public static class Extensions
    {

        public static T Merge<T, Key, Value>(this T left, params IDictionary<Key, Value>[] right)
        where T : IDictionary<Key, Value>, new()
        {
            var dict = new T();
            foreach (var src in (new List<IDictionary<Key, Value>> { left }).Concat(right))
                foreach (KeyValuePair<Key, Value> p in src)
                    dict[p.Key] = p.Value;
            return dict;
        }

        


    }
}
