using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ZedUtils
{
    /// <summary>
    /// This class is used to initialize any kind of dependency other methods might need
    /// </summary>
    public static class DependencyHandler
    {
        internal static Dictionary<string, Assembly> Libs = new();

        /// <summary>
        /// Initialize the JsonDependency with your own methods
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="deserializer"></param>
        public static void InitJson(Func<object, string> serializer, Func<string, Type, object> deserializer)
        {
            JsonDependency.Init(serializer, deserializer);
        }

    }

    /// <summary>
    /// Used by string.JsonDeserialize and object.JsonSerialize. Must be initialized with <c>DependencyHandler.InitJson</c> beforehand
    /// </summary>
    public static class JsonDependency
    {
        internal static void Init(Func<object, string> serializer, Func<string, Type, object> deserializer)
        {
            Serializer = serializer;
            Deserializer = deserializer;
        }
        private static Func<object, string> Serializer = (target) => throw new Exception("Json hasn't been initialized yet");
        private static Func<string, Type, object> Deserializer = (json,type) => throw new Exception("Json hasn't been initialized yet");

        public static string Serialize<T>(T target) => target != null ? Serializer(target) : Serializer("");
        public static T Deserialize<T>(string json) => (T)Deserializer(json, typeof(T));
    }
}
