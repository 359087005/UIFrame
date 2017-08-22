using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HBFrameWork
{
    public class UIManager : Singleton<UIManager>
    {
        public override void Init()
        {
            Debug.Log("UIManager: Singleton<UIManager> Init");
        }
    }
}
