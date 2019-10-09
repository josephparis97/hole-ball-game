using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questionnairebtn : MonoBehaviour
{
    private Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(task);
    }

    // Update is called once per frame
    void task()
    {
        Application.OpenURL("https://forms.gle/Unij4LbPxHeDHeTK6");

        GameObject.Find("Gui").transform.GetChild(13).gameObject.SetActive(false);
        PlayerPrefs.SetInt("argent", PlayerPrefs.GetInt("argent") + 50);
    }
}
