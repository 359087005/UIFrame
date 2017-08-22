using System;
using UnityEngine;

namespace HBFrameWork
{
    class ResourcesManager : Singleton<ResourcesManager>
    {
        public void Test()
        {
            Debug.Log("ResourcesManager: Singleton<ResourcesManager> Init");
        }
    }
}
