using System.Text.Json;

namespace ZedUtils.Extensions
{
    public static class Extensions
    {
        // Collections

        /// <summary>
        /// Executes an action using each item of the collection
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> i, Action<T> action)
        {
            foreach (T item in i)
            {
                action(item);
            }
        }
        /// <summary>
        /// Executes a function using the input <c>item</c>. If true, adds the item to the collection
        /// </summary>
        public static void TryAdd<T>(this List<T> i, T item, Func<T, bool> predicate)
        {
            if (predicate(item)) i.Add(item);
        }

        // Strings

        /// <summary>
        /// A faster alternative to <c>string.StartsWith</c>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool FastStartsWith(this string str, string value)
        {
            if (str.Length < value.Length) return false;
            for (int i = 0; i < value.Length; i++)
            {
                if (str[i] != value[i]) return false;
            }
            return true;
        }

        // Json

        /// <summary>
        /// Serialize this object using your defined serialization method in <c>DependencyHandler.InitJson</c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string JsonSerialize<T>(this T item)
        {
            return JsonDependency.Serialize<T>(item);
        }

        /// <summary>
        /// Deserialize this object using your defined deserialization method in <c>DependencyHandler.InitJson</c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T? JsonDeserialize<T>(this string s)
        {
            return JsonDependency.Deserialize<T>(s);
        }
    }
}
