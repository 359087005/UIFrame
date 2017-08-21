using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTwo : MonoBehaviour {
    private Button btn;
    void Start()
    {
        btn = transform.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(OnClickBtn);
    }
    void OnClickBtn()
    {
        GameObject go = Instantiate(Resources.Load("Prefab/ButtonOne")) as GameObject;
        TestOne tt = go.GetComponent<TestOne>();
        if (tt == null)
        {
            go.AddComponent<TestOne>();
        }
        Close();
    }

    void Close()
    {
        Destroy(gameObject);
    }
}
