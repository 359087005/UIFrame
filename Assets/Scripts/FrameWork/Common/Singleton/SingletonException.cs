using System;

namespace HBFrameWork
{
    public class SingletonException : Exception
    {
        public SingletonException(string msg) : base(msg)
        {
            //抛出异常
        }
    }
}
