using Newtonsoft.Json.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace HitachiQA.Helpers
{
    public static class ExtensionMethods
    {
        public static void NullGuard([NotNull] this object? obj, string paramName = "")
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static JObject ToJObject(this object obj) => JObject.FromObject(obj);
        public static JToken ToJToken(this object obj) => JToken.FromObject(obj);
        public static JArray ToJArray(this object obj) => JArray.FromObject(obj);

        public static T ToObject<T>(this object obj)
        {
            if (obj.GetType()==typeof(T))
            {
                return (T)obj;
            }
            if (typeof(T) == typeof(string))
            {
                return (T)(object)JToken.FromObject(obj).ToString();

            }
            return JToken.FromObject(obj).ToObject<T>() ?? throw new NullReferenceException();
        }

        public static Dictionary<string, string?>? GetDictionaryByIndex(this List<Dictionary<string, string?>> dictionaryListWithIndexKey, int index)
        {
            return dictionaryListWithIndexKey.GetDictionaryByIndex(index.ToString());

        }
        public static Dictionary<string, string?>? GetDictionaryByIndex(this List<Dictionary<string, string?>> dictionaryListWithIndexKey, string index)
        {
            return dictionaryListWithIndexKey.FirstOrDefault(dict => dict.TryGetValue("index", out string? k) && k == index);

        }

        public static bool ShouldSerialize(this PropertyInfo prop, object parent)
        {
            var method = parent.GetType().GetMethod($"ShouldSerialize{prop.Name}");
            if (method != null)
            {
                return (bool?)method.Invoke(parent, null) ?? throw new NullReferenceException($"Should serialize returned null {parent.GetType().FullName}.{prop.Name}");
            }
            return true;
        }

    }
}
