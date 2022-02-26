namespace YL.Utils.Delegate
{
    public class SingletonUtil<T> where T : class, new()
    {
        private static T _instance;
        private static readonly object _locker = new object();

        public static T GetInstance()
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }

        public static T GetInstanceLock()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null) { _instance = new T(); }
                }
            }
            return _instance;
        }
    }
}