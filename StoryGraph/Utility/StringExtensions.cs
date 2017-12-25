using System.Collections.Generic;

namespace KVP.StoryGraph.Utility
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);
        public static bool IsNullOrWhitespace(this string s) => string.IsNullOrWhiteSpace(s);
        public static string Join(this IEnumerable<string> s, string seperator = "") => string.Join(seperator, s);
    }
}
