using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HBFrameWork
{
    public abstract class Singleton<T> where T : class,new()
    {
        protected static T _Instance = null;
        public static T Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new T();
                return _Instance;
            }
        }

        protected Singleton()
        {
            //异常处理 初始化工作
            if (null != _Instance)
                throw new SingletonException("This" + (typeof(T)).ToString() + "Singleton is not null !");
                Init();
        }

        public virtual void Init()
        {
            Debug.Log("Singleton<T> Init");
        }
    }
}
