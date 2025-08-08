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
            return obj.ToJsonL();
        }
    }
}