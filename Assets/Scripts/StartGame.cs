using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HBFrameWork;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ResourcesManager.Instance.Test();
        UIManager.Instance.Init();

        GameObject go = Instantiate(Resources.Load("Prefab/ButtonOne")) as GameObject;
        TestOne tt = go.GetComponent<TestOne>();
        if (tt == null)
        {
            go.AddComponent<TestOne>();
        }
    }
}
