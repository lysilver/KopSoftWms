namespace YL.Utils.Extensions
{
    public static class GenericExt
    {
        public static T GetObj<T>(this T model)
        {
            //T result = default(T);
            T result = default;
            if (model is T)
            {
                result = (T)(object)model; //或 (T)((object)model);
            }
            return result;
        }

        public static T As<T>(this object obj)
           where T : class
        {
            return (T)obj;
        }
    }
}