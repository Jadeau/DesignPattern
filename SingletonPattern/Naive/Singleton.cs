using System;

namespace SingletonPattern.Naive
{
    public sealed class Singleton
    {
        private static Singleton _instance;

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called");
                if (_instance == null)
                {
                    _instance = new Singleton();
                }

                return _instance;
            }
        }

        public Singleton()
        {
            Logger.Log("Constructor called");
        }
    }
}
