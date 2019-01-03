using MDChall.Core.WebServices;
using MDChall.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MDChall.Core.Functions
{
    public static class DictionaryExtensions
    {
        // Works in C#3/VS2008:
        // Returns a new dictionary of this ... others merged leftward.
        // Keeps the type of 'this', which must be default-instantiable.
        // Example: 
        //   result = map.MergeLeft(other1, other2, ...)
        public static T MergeLeft<T, K, V>(this T me, params IDictionary<K, V>[] others)
            where T : IDictionary<K, V>, new()
        {
            T newMap = new T();
            foreach (IDictionary<K, V> src in
                (new List<IDictionary<K, V>> { me }).Concat(others))
            {
                // ^-- echk. Not quite there type-system.
                foreach (KeyValuePair<K, V> p in src)
                {
                    newMap[p.Key] = p.Value;
                }
            }
            return newMap;
        }


    }
    public class PassengerSearch
    {
        public static bool WildCardMatch(string pattern, string text, bool caseSensitive = false)
        {
            pattern = pattern.Replace(".", @"\.");
            pattern = pattern.Replace("?", ".");
            pattern = pattern.Replace("*", ".*?");
            pattern = pattern.Replace(@"\", @"\\");
            pattern = pattern.Replace(" ", @"\s");
            return new Regex(pattern, caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase).IsMatch(text);
        }

        public async Task<Dictionary<string, List<string>>> SearchPNLAsync(String query="")
        {
            var pasList = await MdApi.GetDictionaryAsync();

            if (String.IsNullOrEmpty(query) || query.Length <= 2)
                return pasList;

            var matchedKeys = pasList.Where(x => WildCardMatch(query.ToLowerInvariant(), x.Key.ToLowerInvariant()));

            var MatchedRecords = new Dictionary<String, List<String>>();
            foreach (var r in pasList)
            {
                var matched = r.Value.Where(x => WildCardMatch(query.ToLowerInvariant(), x.ToLowerInvariant()));
                if (matched.Count() > 0)
                    MatchedRecords.TryAdd(r.Key, matched.ToList());
            }
            return MatchedRecords.MergeLeft(matchedKeys.ToDictionary(x => x.Key, x => x.Value));
        }
    }
}
