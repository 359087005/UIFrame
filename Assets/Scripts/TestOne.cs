using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestOne : MonoBehaviour {

    private Button btn;
	void Start ()
    {
        btn = transform.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(OnClickBtn);
	}
    void OnClickBtn()
    {
        GameObject go = Instantiate(Resources.Load("Prefab/ButtonTwo")) as GameObject;
        TestTwo tt = go.GetComponent<TestTwo>();
        if (tt == null)
        {
            go.AddComponent<TestTwo>();
        }
        Close();
    }

    void Close()
    {
        Destroy(gameObject);
    }
}
