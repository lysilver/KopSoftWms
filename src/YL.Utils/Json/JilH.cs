using Jil;
using System.Collections.Generic;
using System.IO;

namespace YL.Utils.Json
{
    /// <summary>
    /// https://github.com/kevin-montrose/Jil Jil>Newtonsoft.Json
    /// </summary>
    public static class JilH
    {
        /// <summary>
        ///jilH在序列化、反序列化json比 Newtonsoftjson快
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string JilToJson(this object obj)
        {
            return JSON.Serialize(obj);
        }

        public static string JilToJsonW(this object obj)
        {
            using (var output = new StringWriter())
            {
                JSON.Serialize(obj, output);
                return output.ToString();
            }
        }

        public static string JilToJsonCamelCase(this object obj)
        {
            return JSON.Serialize(obj, Options.CamelCase);
        }

        public static string JilToJson(this object obj, Options options = null)
        {
            return JSON.Serialize(obj, options);
        }

        public static T JilToObject<T>(this string json)
        {
            using (var input = new StringReader(json))
            {
                var result = JSON.Deserialize<T>(input);
                return result;
            }
        }

        public static T JilToObject<T>(this StreamReader streamReader)
        {
            return JSON.Deserialize<T>(streamReader);
        }

        public static List<T> JilToList<T>(this string json)
        {
            using (var input = new StringReader(json))
            {
                var result = JSON.Deserialize<List<T>>(input);
                return result;
            }
        }
    }
}