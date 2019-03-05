using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using YL.Utils.Check;
using YL.Utils.Extensions;

namespace YL.Utils.Json
{
    public class JsonDict
    {
        private static readonly IDictionary<string, string> _data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private static readonly Stack<string> _context = new Stack<string>();
        private string _currentPath;
        private static JsonTextReader _reader;

        public static IDictionary<string, string> GetKeyValues(string json, EncodingType type = EncodingType.UTF8)
        {
            try
            {
                CheckNull.ArgumentIsNullException(json, nameof(json));
                using (StreamReader streamReader = new StreamReader(json.ToBytes(type).ToStream()))
                {
                    _data.Clear();
                    _reader = new JsonTextReader(streamReader)
                    {
                        DateParseHandling = 0
                    };
                    JObject jObject = JObject.Load(_reader);
                    new JsonDict().VisitJObject(jObject);
                    return _data;
                }
            }
            catch (Exception)
            {
                throw new FormatException("json格式不正确");
            }
        }

        public static IDictionary<string, string> GetKeyValuesFromPath(string path, EncodingType type = EncodingType.UTF8)
        {
            try
            {
                CheckNull.ArgumentIsNullException(path, nameof(path));
                using (StreamReader streamReader = new StreamReader(path, BytesExt.GetEncoding(type)))
                {
                    _data.Clear();
                    _reader = new JsonTextReader(streamReader)
                    {
                        DateParseHandling = 0
                    };
                    JObject jObject = JObject.Load(_reader);
                    new JsonDict().VisitJObject(jObject);
                    return _data;
                }
            }
            catch (Exception)
            {
                throw new FormatException("json格式不正确");
            }
        }

        private void VisitJObject(JObject jObject)
        {
            foreach (var property in jObject.Properties())
            {
                EnterContext(property.Name);
                VisitProperty(property);
                ExitContext();
            }
        }

        private void VisitProperty(JProperty property)
        {
            VisitToken(property.Value);
        }

        private void VisitToken(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    VisitJObject(token.Value<JObject>());
                    break;

                case JTokenType.Array:
                    VisitArray(token.Value<JArray>());
                    break;

                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.String:
                case JTokenType.Boolean:
                case JTokenType.Bytes:
                case JTokenType.Raw:
                case JTokenType.Null:
                    VisitPrimitive(token.Value<JValue>());
                    break;

                default:
                    throw new FormatException("格式错误");
            }
        }

        private void VisitArray(JArray array)
        {
            for (int index = 0; index < array.Count; index++)
            {
                EnterContext(index.ToString());
                VisitToken(array[index]);
                ExitContext();
            }
        }

        private void VisitPrimitive(JValue data)
        {
            var key = _currentPath;

            if (_data.ContainsKey(key))
            {
                throw new FormatException(key);
            }
            _data[key] = data.ToString(CultureInfo.InvariantCulture);
        }

        private void EnterContext(string context)
        {
            _context.Push(context);
            _currentPath = string.Join(":", _context.Reverse());
        }

        private void ExitContext()
        {
            _context.Pop();
            _currentPath = string.Join(":", _context.Reverse());
        }
    }
}